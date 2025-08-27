using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;


namespace Trucking
{
    public partial class TruckingMain : Form
    {
        private readonly string defaultPath = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\doc\";
        private readonly string defaultPathSave = $@"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\doc\save\";
        private readonly DataTable tableOrg = null;
        private readonly DataTable tableBeznal = null;
        private readonly DataTable tableRKB = null;
        private string user = "";
        private int countRKB = 0;

        public TruckingMain()
        {
            InitializeComponent();

            panelHiding.BringToFront();

            try
            {
                tableOrg = OpenExcelFile(File.Exists(defaultPath + "org.xls") 
                    ? defaultPath + "org.xls" : defaultPath + "org.xlsx");
                tableBeznal = OpenExcelFile(File.Exists(defaultPath + "beznal.xls") 
                    ? defaultPath + "beznal.xls" : defaultPath + "beznal.xlsx");
                tableRKB = OpenExcelFile(File.Exists(defaultPath + "rkb.xls") 
                    ? defaultPath + "rkb.xls" : defaultPath + "rkb.xlsx");

                CheckOrg(); // Проверка совпадения названий из списка безнала с названиями из списка организаций

                FillComboBoxUsers(); // Заполнение комбобокса пользователей

                WindowState = FormWindowState.Normal;
                Activate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            panelUser.BringToFront();
        }
        
        private void RestartToolStripMenuItem_Click(object sender, EventArgs e)
        { // Перезагрузка программы
            Application.Restart();
            Environment.Exit(0);
        }
        
        private void FillComboBoxUsers()
        { // Заполнение comboBoxUsers названиями папок из папки "пользователи"
            List<string> dirs = new List<string>(Directory.EnumerateDirectories(defaultPath + @"пользователи\"));

            comboBoxUsers.Items.Clear();
            foreach (var dir in dirs)
            {
                comboBoxUsers.Items.Add(dir.Substring(dir.LastIndexOf(Path.DirectorySeparatorChar) + 1));
            }
            comboBoxUsers.SelectedIndex = 0;
        }

        private void CheckOrg()
        { // Проверка совпадения списка безнала, со списком организаций
            List<string> list = new List<string>();
            bool checkItem = false;
            foreach (DataRow itemBeznal in tableBeznal.Rows)
            {
                bool isItem = true;
                foreach (DataRow itemOrg in tableOrg.Rows)
                {
                    if (itemBeznal.Field<string>("organ") == itemOrg.Field<string>("name_org"))
                    {
                        isItem = false;
                    }
                }

                if (isItem)
                {
                    list.Add(itemBeznal.Field<string>("organ"));
                    checkItem = true;
                }
            }

            if (checkItem)
            {
                MessageBox.Show("В списке beznal присутствуют огранизации которых нет в списке организаций! " +
                    "Или же имена у них не совпадают:\n" + string.Join(Environment.NewLine, list), 
                    "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable OpenExcelFile(string path)
        { // Открытие Excel файла и занесение данных из него в DataTabel
            DataTable dataTable = null;
            DataTableCollection tableCollection = null;
            FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);

            // Магический для меня код, который заносит данные из Excel таблицы в reader, затем в db, после в tableCollection
            IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream);
            DataSet db = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (x) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = true
                }
            });
            tableCollection = db.Tables;
            //

            //Выборка листов (особо не нужна, т.к. пока пользуюсь только 1-ым листом, но мб в будущем пригодится)
            ToolStripComboBox1.Items.Clear();
            foreach (DataTable tabe in tableCollection)
            {
                ToolStripComboBox1.Items.Add(tabe.TableName);
            }
            ToolStripComboBox1.SelectedIndex = 0;
            //

            // Перенос из tableCollection по первому листу в dataTable
            dataTable = tableCollection[Convert.ToString(ToolStripComboBox1.SelectedItem)];
            //

            // Сортировка таблицы
            foreach (DataColumn Colimn in dataTable.Columns)
            {
                dataTable.DefaultView.Sort = $"{Colimn.ColumnName} DESC";
                break;
            }
            //

            // Создание колонки id, помещение в нулевую позицию, и заполнение от 0
            dataTable.Columns.Add("id", typeof(int));
            dataTable.Columns["id"].SetOrdinal(0);
            int idSequenceNumber = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                row.SetField("id", idSequenceNumber++);
            }
            // 

            stream.Close();
            reader.Close();

            return dataTable;
        }

        private void UserChoice_Click(object sender, EventArgs e)
        { // Выбор пользователя
            panelUser.SendToBack();
            panelHiding.SendToBack();

            user = comboBoxUsers.SelectedItem.ToString();

            ActiveForm.Text = ActiveForm.Text + " - " + user;

            panelMain.BringToFront();
        }
        
        private void ASToolStripMenuItem_Click(object sender, EventArgs e)
        { // Открытие окна формирования АКТОВ и СЧЕТОВ или РКБ, с заполнением комбобокса "Организаций"
            panelHiding.SendToBack();

            try
            {
                if (CheckRKB.Checked)
                {
                    comboBoxOrg.Items.Clear();
                    foreach (DataRow rkbItem in tableRKB.Rows)
                    {
                        if (rkbItem[1] == DBNull.Value)
                            continue;
                        else if(!DateTime.TryParse(rkbItem[1].ToString(), CultureInfo.GetCultureInfo("ru-RU"),
                            DateTimeStyles.None, out _))
                            continue;
                        else
                            countRKB++;
                    }

                    label12.Text = countRKB.ToString();

                    bool checkChar = false;
                    textBox1.Text = "";

                    foreach (DataRow heading in tableRKB.Rows)
                    {
                        string headingText = "";
                        if (heading[1] != DBNull.Value || heading[2] != DBNull.Value || heading[3] != DBNull.Value)
                        {
                            headingText = heading[1].ToString() + heading[2].ToString() + heading[3].ToString();
                            foreach (char item in headingText)
                            {
                                if (item == '-')
                                {
                                    checkChar = true;
                                    continue;
                                }
                                if (checkChar)
                                {
                                    if (item == ' ')
                                        break;
                                    textBox1.Text += item;
                                }
                            }
                        }
                        if (checkChar)
                            break;
                    }

                    comboBoxOrg.Items.Add(comboBoxRKB.Text);
                    comboBoxOrg.SelectedIndex = 0;
                    label11.Text = comboBoxRKB.Text;

                    checkCreateAll.Checked = true;
                    checkBoxOpenFolder.Checked = true;
                    dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month - 1, 1);
                }
                else
                {
                    List<string> list = new List<string>();
                    comboBoxOrg.Items.Clear();
                    foreach (DataRow beznalItem in tableBeznal.Rows)
                    {
                        list.Add(beznalItem.Field<string>("organ"));
                    }

                    list = list.Distinct().ToList();

                    foreach (var item in list)
                    {
                        if(item != null)
                            comboBoxOrg.Items.Add(item);
                    }

                    comboBoxOrg.Sorted = true;
                    comboBoxOrg.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка! Файл базы пуст!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            panelUser.SendToBack();
            panelActSchet.BringToFront();
        }

        private void ButtonCreateAS_Click(object sender, EventArgs e)
        { // Создание файлов и их печать
            panelHiding.BringToFront();

            bool createAll = true;
            int countLast = 0;
            DataRow[] financialArrayDataRowsTemp = tableRKB.Select();
            List<DataRow> financialListDataRows = new List<DataRow> { };
            foreach (var item in financialArrayDataRowsTemp)
            {
                financialListDataRows.Add(item);
            }

            try
            {
                string[] columnNames = { "id", "date", "vod", "money", "load", "unload" };
                for (int i = 0; i < tableRKB.Columns.Count; i++)
                {
                    tableRKB.Columns[i].ColumnName = columnNames[i];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка! Проверь на лишние колонки в таблице rkb!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                createAll = false;
            }

            while (createAll)
            {
                tableOrg.PrimaryKey = new DataColumn[] { tableOrg.Columns[0] };
                DataRow[] orgRowArray = tableOrg.Select($"name_org like '{comboBoxOrg.SelectedItem}'");
                DataRow orgRow = orgRowArray[0];
                DataRow[] financialArrayDataRows = null;

                if (CheckRKB.Checked)
                {
                    while (countLast < tableRKB.Rows.Count)
                    {
                        DataRow row = tableRKB.Rows[countLast];
                        if (DateTime.TryParse(row[1].ToString(), CultureInfo.GetCultureInfo("ru-RU"),
                            DateTimeStyles.None, out _)) // проверка на дату
                        {
                            break;
                        }
                        financialListDataRows.RemoveAt(0);
                        countLast++;
                    }
                    
                    financialArrayDataRows = new DataRow[tableRKB.Rows.Count - countLast];

                    for (int i = 0; i < financialListDataRows.Count; i++)
                    {
                        financialArrayDataRows[i] = financialListDataRows[i];
                    }
                    financialListDataRows.RemoveAt(0);
                }
                else
                {
                    financialArrayDataRows = tableBeznal.Select($"date >= '{dateTimePicker1.Value.Date:d/M/yyyy}' " +
                        $"AND date <= '{dateTimePicker2.Value.Date:d/M/yyyy}' AND organ = '{comboBoxOrg.Text}'");
                }

                if (checkCreateAll.Checked)
                {
                    if (!CheckRKB.Checked)
                    {
                        checkBoxPlus1Num.Checked = true;
                        if (financialArrayDataRows == null || financialArrayDataRows.Length == 0)
                        {
                            if (comboBoxOrg.SelectedIndex == comboBoxOrg.Items.Count - 1)
                                createAll = false;
                            else
                                comboBoxOrg.SelectedIndex += 1;
                            continue;
                        }
                    }
                    else
                    {
                        if(financialArrayDataRows.Length == 1)
                            createAll = false;
                    }
                }

                bool format = true;
                double sum = 0;
                
                foreach (DataRow row in financialArrayDataRows)
                {
                    sum += row.Field<double>("money");
                    if (CheckRKB.Checked)
                        break;
                }

                #region(WORD)

                while (true)
                { // Создание и заполение Word файла
                    if (checkBoxSchet.Checked == true)
                    {
                        if (checkBoxNotZero.Checked)
                        {
                            if (sum <= 0)
                            {
                                if (checkBoxNotifications.Checked == false)
                                    MessageBox.Show($"Сумма в счёте №Р-{textBox1.Text} {orgRow["name_org"]} ровна " +
                                        $"{sum}! Счёт не будет создан!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }

                        // Открытие шаблона
                        Word.Application wordApp = new Word.Application();
                        Word.Document wordDoc = wordApp.Documents.Open(File.Exists($@"{defaultPath}пользователи\{user}\schet.doc")
                            ? $@"{defaultPath}пользователи\{user}\{formatTrue("schet.doc")}"
                            : $@"{defaultPath}пользователи\{user}\{formatFalse("schet.docx")}"
                            , Type.Missing, true);
                        Word.FormFields fields = wordDoc.FormFields;
                        //

                        // Заполнение документа
                        fields["nom"].Result = textBox1.Text; //Номер счёта
                        fields["data_dost"].Result = dateTimePicker3.Text; //Дата на какое число
                        fields["name_org"].Result = orgRow["of_name_org"].ToString();//Заказчик:
                        fields["inn"].Result = orgRow["inn"].ToString();//ИНН
                        fields["kpp"].Result = orgRow["kpp"].ToString();//КПП
                        fields["adres"].Result = orgRow["adres"].ToString();//Адрес
                        fields["beznal"].Result = sum.ToString();//сумма
                        fields["beznal1"].Result = sum.ToString();//сумма
                        fields["beznal2"].Result = sum.ToString();//сумма
                        fields["beznal3"].Result = sum.ToString();//сумма итого
                        fields["beznal4"].Result = sum.ToString();//сумма пример: 1 000,00
                        fields["beznal5"].Result = RSDN.RusCurrency.Str(sum).ToString();//сумма текстом, пример: Одна тысяча рублей 00 копеек
                        fields["nom1"].Result = textBox1.Text;//Номер счёта
                        fields["data_dost1"].Result = dateTimePicker3.Text;//Дата на какое число
                        //

                        // Выбор название файла с форматом, в зависомости от изначального формата файла
                        string fileNameWord = "";
                        if (format)
                        {
                            fileNameWord = $@"{defaultPathSave}Счёт №Р-{textBox1
                            .Text} {orgRow["name_org"]} {sum}.doc";
                        }
                        else
                        {
                            fileNameWord = $@"{defaultPathSave}Счёт №Р-{textBox1
                            .Text} {orgRow["name_org"]} {sum}.docx";
                        };
                        //

                        // Сохранение файла
                        if (File.Exists(fileNameWord))
                        {
                            MessageBox.Show($"Такой файл \"{fileNameWord}\" уже существует! Файл будет сохранён, но с пометкой времени создания в начале файла"
                                , "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fileNameWord = $@"{defaultPathSave}({DateTime.Now.ToString("HHmmss")}) {fileNameWord.Split('\\').Last()}";
                            wordDoc.SaveAs(fileNameWord);
                        }
                        else
                            wordDoc.SaveAs(fileNameWord);
                        //

                        // Закрытие или отображение файла
                        if (checkBoxCloseDoc.Checked == true)
                        {
                            wordDoc.Close(false);
                            wordApp.Quit();
                        }
                        else
                            wordApp.Visible = true;
                        //

                        // Печать файла
                        if (checkBoxPrint.Checked == true)
                        {
                            ProcessStartInfo info = new ProcessStartInfo(fileNameWord)
                            {
                                Verb = "Print",
                                CreateNoWindow = true,
                                WindowStyle = ProcessWindowStyle.Hidden
                            };
                            Process.Start(info);
                        }
                        //
                    }
                    break;
                }

                #endregion

                #region(EXCEL)

                while (true)
                { // Создание и заполение Excel файла
                    if (checkBoxAct.Checked == true)
                    {
                        if (checkBoxNotZero.Checked && !CheckRKB.Checked)
                        {
                            if (sum <= 0)
                            {
                                if (checkBoxNotifications.Checked == false)
                                    MessageBox.Show($"Сумма в акте №РА-{textBox1.Text} {orgRow["name_org"]} ровна " +
                                    $"{sum}! Акт не будет создан!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }

                        // Открытие шаблона
                        Excel.Application excelApp = new Excel.Application();
                        Excel.Workbook excelDoc = excelApp.Workbooks.Open(File.Exists(
                              $@"{defaultPath}пользователи\{user}\act.xls")
                            ? $@"{defaultPath}пользователи\{user}\{formatTrue("act.xls")}"
                            : $@"{defaultPath}пользователи\{user}\{formatFalse("act.xlsx")}"
                            , Type.Missing, true);
                        Excel.Worksheet worksheet = (Excel.Worksheet)excelDoc.Worksheets.get_Item(1);
                        //

                        // Заполнение документа

                        worksheet.Range["B6"].Value = $"Заказчик: {orgRow["of_name_org"]}, " +
                                                      $"ИНН {orgRow["inn"]}, " +
                                                      $"КПП {orgRow["kpp"]}";
                            
                        int lineNumber = 9;
                        if (CheckRKB.Checked)
                        {
                            foreach (DataRow row in financialArrayDataRows)
                            {
                                worksheet.Range["B4"].Value = $"Акт №РА-{textBox1.Text}-А{textBox2.Text} от " +
                                                              $"{Convert.ToDateTime(row["date"]):dd MMMM yyyy} г.";
                                worksheet.Rows[lineNumber].Insert();
                                worksheet.get_Range($"C{lineNumber}", $"F{lineNumber}").Borders
                                         .get_Item(Excel.XlBordersIndex.xlEdgeTop)
                                         .LineStyle = Excel.XlLineStyle.xlContinuous; // Рисовка полосок между услугами
                                worksheet.Range[$"C{lineNumber}"].Value = $"{Convert.ToDateTime(row["date"]):dd/MM/yyyy} " +
                                                                          $"- Транспортные услуги " +
                                                                          $"- {row["vod"]} " +
                                                                          $"- {row["load"]} " +
                                                                          $"- {row["unload"]}";
                                worksheet.Range[$"D{lineNumber}"].Value = "1";
                                worksheet.Range[$"E{lineNumber}"].Value = "усл.";
                                worksheet.Range[$"F{lineNumber++}"].Value = $"{row["money"]}";
                                break;
                            }
                            worksheet.Range[$"C{lineNumber}"].Value = "Итого";
                            worksheet.Range[$"D{lineNumber}"].Value = $"1";
                            worksheet.Range[$"E{lineNumber}"].Value = "усл.";
                            worksheet.Range[$"F{lineNumber}"].Value = $"{sum}";
                            worksheet.Range[$"B{2 + lineNumber}"].Value = $"Всего оказано услуг на сумму: {RSDN.RusCurrency.Str(sum)}";
                        }
                        else
                        {
                            foreach (DataRow row in financialArrayDataRows)
                            {
                                worksheet.Range["B4"].Value = $"Акт №РА-{textBox1.Text} от " +
                                                              $"{dateTimePicker3.Value.Date:dd MMMM yyyy} г.";
                                worksheet.Rows[lineNumber].Insert();
                                worksheet.get_Range($"C{lineNumber}", $"F{lineNumber}").Borders
                                         .get_Item(Excel.XlBordersIndex.xlEdgeTop)
                                         .LineStyle = Excel.XlLineStyle.xlContinuous; // Рисовка полосок между услугами
                                worksheet.Range[$"C{lineNumber}"].Value = $"{Convert.ToDateTime(row["date"]):dd/MM/yyyy} " + // row.Field<DateTime>("date"):dd/MM/yyyy
                                                                          $"- {row["load"]} " +
                                                                          $"- {row["unload"]} " +
                                                                          $"- {row["vod"]}";
                                worksheet.Range[$"D{lineNumber}"].Value = "1";
                                worksheet.Range[$"E{lineNumber}"].Value = "усл.";
                                worksheet.Range[$"F{lineNumber++}"].Value = $"{row["money"]}";
                            }
                        worksheet.Range[$"C{lineNumber}"].Value = "Итого";
                        worksheet.Range[$"D{lineNumber}"].Value = $"{financialArrayDataRows.Length}";
                        worksheet.Range[$"E{lineNumber}"].Value = "усл.";
                        worksheet.Range[$"F{lineNumber}"].Value = $"{sum}";
                        worksheet.Range[$"B{2 + lineNumber}"].Value = $"Всего оказано услуг на сумму: {RSDN.RusCurrency.Str(sum)}";
                        }
                        //

                        // Выбор название файла с форматом, в зависомости от изначального формата файла
                        string fileNameExcel = "";
                        if(CheckRKB.Checked)
                        {
                            if (format)
                            {
                                fileNameExcel = $@"{defaultPathSave}Акт №РА-{textBox1
                                .Text}-А{textBox2.Text} {orgRow["name_org"]}.xls";
                            }
                            else
                            {
                                fileNameExcel = $@"{defaultPathSave}Акт №РА-{textBox1
                                .Text}-А{textBox2.Text} {orgRow["name_org"]}.xlsx";
                            }
                        }
                        else
                        {
                            if (format)
                            {
                                fileNameExcel = $@"{defaultPathSave}Акт №РА-{textBox1
                                .Text} {orgRow["name_org"]}.xls";
                            }
                            else
                            {
                                fileNameExcel = $@"{defaultPathSave}Акт №РА-{textBox1
                                .Text} {orgRow["name_org"]}.xlsx";
                            }
                        }
                        //

                        textBox2.Text = (int.Parse(textBox2.Text) + 1).ToString();

                        // Сохранение файла
                        if (File.Exists(fileNameExcel))
                        {
                            MessageBox.Show($"Такой файл \"{fileNameExcel}\" уже существует! " +
                                $"Файл будет сохранён, но с пометкой времени создания в начале файла"
                                , "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            fileNameExcel = $@"{defaultPathSave}({DateTime.Now.ToString("HHmmss")}) {fileNameExcel.Split('\\').Last()}";
                            excelDoc.SaveAs(fileNameExcel);
                        }
                        else
                            excelDoc.SaveAs(fileNameExcel);
                        //

                        // Закрытие или отображение файла
                        if (checkBoxCloseDoc.Checked == true)
                        {
                            excelDoc.Close(false);
                            excelApp.Quit();
                        }
                        else
                        {
                            excelApp.Visible = true;
                        }
                        //

                        // Печать файла
                        if (checkBoxPrint.Checked == true)
                        {
                            ProcessStartInfo info = new ProcessStartInfo(fileNameExcel)
                            {
                                Verb = "Print",
                                CreateNoWindow = true,
                                WindowStyle = ProcessWindowStyle.Hidden
                            };
                            Process.Start(info);
                            Process.Start(info);
                        }
                        //
                    }

                    if(CheckRKB.Checked)
                    {
                        Excel.Application excelApp = null;
                        Excel.Workbook workbook = null;
                        // Создаем экземпляр Excel
                        excelApp = new Excel.Application
                        {
                            Visible = false, // Скрываем интерфейс Excel
                            DisplayAlerts = false // Отключаем системные предупреждения
                        };

                        // Открываем книгу
                        workbook = excelApp.Workbooks.Open(File.Exists(defaultPath + "rkb.xls") 
                            ? defaultPath + "rkb.xls" : defaultPath + "rkb.xlsx");

                        // Получаем первый лист
                        Excel.Worksheet worksheet = workbook.Sheets[1];

                        // Выбираем строку
                        Excel.Range rowToDelete = worksheet.Rows[countLast + 2];

                        // Удаляем строку
                        rowToDelete.Delete();

                        // Сохраняем изменения
                        workbook.Save();
                        // Закрываем книгу и приложение
                        if (workbook != null)
                        {
                            workbook.Close(false);
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                        }
                        if (excelApp != null)
                        {
                            excelApp.Quit();
                            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                        }

                        // Очистка COM-объектов
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                    }

                    break;
                }

                #endregion

                if (checkBoxPlus1Num.Checked)
                {
                    if(!CheckRKB.Checked)
                        textBox1.Text = (int.Parse(textBox1.Text) + 1).ToString();
                }

                string formatFalse(string file)
                {
                    format = false;
                    return file;
                }
                string formatTrue(string file)
                {
                    format = true;
                    return file;
                }

                // Проверка на создание всех файлов по выбранным датам из списка
                if (!checkCreateAll.Checked)
                    createAll = false;
                else
                {
                    if (CheckRKB.Checked)
                    {
                        countRKB--;
                        label12.Text = countRKB.ToString();
                        if (label12.Text == "0")
                        {
                            stopCreateAll();
                            break;
                        }
                        checkBoxPlus1Num.Checked = true;
                        checkBoxNotifications.Checked = true;
                    }
                    else
                    {
                        if (comboBoxOrg.SelectedIndex == comboBoxOrg.SelectionLength)
                        {
                            stopCreateAll();
                            break;
                        }
                        comboBoxOrg.SelectedIndex += 1;
                        checkBoxPlus1Num.Checked = true;
                        checkBoxNotifications.Checked = true;
                    }
                }

                void stopCreateAll()
                {
                    createAll = false;
                    checkBoxNotifications.Checked = false;
                }
            }

            // Открытие папки
            if (checkBoxOpenFolder.Checked)
                Process.Start(defaultPathSave);
            //

            panelHiding.SendToBack();
        }

        private void CheckRKB_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckRKB.Checked)
            {
                checkBoxSchet.Checked = false;
                checkBoxSchet.Visible = false;
                checkBoxAct.Visible = false;
                checkBoxPrint.Visible = false;
                comboBoxOrg.Visible = false;
                label6.Visible = false;
                dateTimePicker3.Visible = false;
                label11.Visible = true;
                label12.Visible = true;
                checkBoxPlus1Num.Visible = false;
                textBox2.Visible = true;
                comboBoxRKB.Visible = true;
                FillComboBoxRKB();
            }
            else
            {
                checkBoxSchet.Checked = true;
                checkBoxSchet.Visible = true;
                checkBoxAct.Visible = true;
                checkBoxPrint.Visible = true;
                comboBoxOrg.Visible = true;
                label6.Visible = true;
                dateTimePicker3.Visible = true;
                label11.Visible = false;
                label12.Visible = false;
                checkBoxPlus1Num.Visible = true;
                textBox2.Visible = false;
                comboBoxRKB.Visible = false;
            }

            void FillComboBoxRKB()
            { // Заполнение comboBoxRKB
                DataTable tableRKBTempForComboBox = OpenExcelFile(File.Exists(defaultPath + "РКБ.xls")
                    ? defaultPath + "РКБ.xls" : defaultPath + "РКБ.xlsx");

                List<string> list = new List<string>();
                comboBoxRKB.Items.Clear();
                foreach (DataRow RKBTempItem in tableRKBTempForComboBox.Rows)
                {
                    list.Add(RKBTempItem.Field<string>("organ"));
                }

                list = list.Distinct().ToList();

                foreach (var item in list)
                {
                    if (item != null)
                        comboBoxRKB.Items.Add(item);
                }

                comboBoxRKB.SelectedIndex = 0;
            }
        }
    }
}
