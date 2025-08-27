using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace Trucking
{
    public partial class TruckingMain : Form
    {
        private string GetNameFile(bool conclusion = true, int num = 0)
        { // Выборка файлов из папки save
            string[] tempFilesXls = Directory.GetFiles(defaultPathSave, "*.xls", SearchOption.AllDirectories);
            string[] tempFilesXlsx = Directory.GetFiles(defaultPathSave, "*.xlsx", SearchOption.AllDirectories);
            string[] tempFilesDoc = Directory.GetFiles(defaultPathSave, "*.doc", SearchOption.AllDirectories);
            string[] tempFilesDocx = Directory.GetFiles(defaultPathSave, "*.docx", SearchOption.AllDirectories);

            string[] tempFiles = new string[tempFilesXls.Length + tempFilesXlsx.Length + tempFilesDoc.Length + tempFilesDocx.Length];
            int ii = 0;
            for (int i = 0; ii <= tempFiles.Length - 1; i++)
            {
                if (tempFilesXls != null && tempFilesXls.Length != 0 && i < tempFilesXls.Length)
                {
                    tempFiles[ii++] = tempFilesXls[i];
                }
                if (tempFilesXlsx != null && tempFilesXlsx.Length != 0 && tempFilesXlsx[i] != "" && i < tempFilesXlsx.Length)
                {
                    tempFiles[ii++] = tempFilesXlsx[i];
                }
                if (tempFilesDoc != null && tempFilesDoc.Length != 0 && tempFilesDoc[i] != "" && i < tempFilesDoc.Length)
                {
                    tempFiles[ii++] = tempFilesDoc[i];
                }
                if (tempFilesDocx != null && tempFilesDocx.Length != 0 && tempFilesDocx[i] != "" && i < tempFilesDocx.Length)
                {
                    tempFiles[ii++] = tempFilesDocx[i];
                }
            }

            string[] nameOrg = new string[tempFiles.Length];

            if (tempFiles.Length == 0)
            {
                dataGridViewListOrgToSend.DataSource = tempFiles;
                dataGridViewListOrgToSend.DataSource = null;

                ButtonSendMail.Enabled = false;

                return "0";
            }

            if (conclusion)
            {
                dataGridViewListOrgToSend.RowCount = nameOrg.Length;
                dataGridViewListOrgToSend.ColumnCount = 1;
            }

            for (int i = 0; i <= tempFiles.Length - 1; i++)
            {
                List<string> tempList1 = new List<string>();
                tempList1.AddRange(tempFiles[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

                List<string> tempList2 = new List<string>();
                if (conclusion)
                {
                    for (int j = 2; j <= tempList1.Count - 1; j++)
                        tempList2.Add(tempList1[j]);
                }
                else
                {
                    for (int j = 0; j <= tempList1.Count - 1; j++)
                    {
                        if (j == 0)
                        {
                            tempList2.Add(tempFiles[i].Split(new string[] { " " }, StringSplitOptions
                                .RemoveEmptyEntries)[j].Split(new string[] { "\\" }, StringSplitOptions
                                .RemoveEmptyEntries)[tempFiles[j].Split(new string[] { " " }, StringSplitOptions
                                                                 .RemoveEmptyEntries)[j].Split(new string[] { "\\" }, StringSplitOptions
                                                                 .RemoveEmptyEntries).Length - 1]);
                        }
                        else
                        {
                            tempList2.Add(tempList1[j]);
                        }
                    }

                }

                for (int k = 0; k <= tempList2.Count - 1; k++)
                    nameOrg[i] = nameOrg[i] + " " + tempList2[k].ToString();

                if (conclusion)
                {
                    dataGridViewListOrgToSend.Rows[i].Cells[0].Value = nameOrg[i].Trim();
                }
            }
            if (!conclusion)
            {
                return nameOrg[num].Trim();
            }
            return "";
        }

        private void ButtonSendMail_Click(object sender, EventArgs e)
        { // Формирование данных черновика для отправки файла(ов)
            bool notSentFile = false;

            if (checkBoxSendAllOrSingl.Checked)
            {
                panelHiding.BringToFront();

                int dataGridCount = 0;

                while (true)
                {
                    List<int> listIndex = new List<int>();
                    List<string> nameSendFile = new List<string>();

                    foreach (DataGridViewRow row in dataGridViewListOrgToSend.Rows)
                    {
                        string subjectMail = "";
                        List<string> nameFile = new List<string>();
                        string firstValueRow1 = "";

                        foreach (DataGridViewRow row1 in dataGridViewListOrgToSend.Rows) // Чтобы найти похожие файлы и добавить их в отправку
                        {
                            string tempRowStringValue = row1.Cells[0].Value.ToString().Split('.')[0].Trim();
                            if (int.TryParse(tempRowStringValue.Split(' ').Last(), out int notNeeded))
                            {
                                string temp = "";
                                foreach (string valueString in tempRowStringValue.Split(' '))
                                {
                                    if (!int.TryParse(valueString, out int notNeeded1))
                                    {
                                        temp = temp + " " + valueString;
                                    }
                                }
                                tempRowStringValue = temp.Trim();
                            }

                            if (row1.Index == 0)
                            {
                                firstValueRow1 = tempRowStringValue;
                            }

                            if (firstValueRow1 == tempRowStringValue)
                            {
                                nameFile.Add(GetNameFile(false, row1.Index)); // Добавление название файла в список
                                subjectMail = subjectMail + " " + row1.Cells[0].Value.ToString(); // Тема - Полное название файла по гриду
                                listIndex.Add(row1.Index); // Добавление индекса грида в список для перемещения файлов
                            }
                            ;
                        }
                        ;

                        string bodyMail = ""; // Тело - ??
                        try
                        {
                            string mailingAddressRecipient = GetMailingAddressRecipient(row.Cells[0].Value.ToString()); // Адрес для отправки - Из списка counterparties.xlsx

                            for (int j = 0; j < nameFile.Count; j++)
                            {
                                nameSendFile.Add(nameFile[j]);
                            }
                            ;

                            if (mailingAddressRecipient == "")
                                throw new ArgumentException($"{nameFile[0].Split('.')[0].Trim()} не найден в списке контрагентов!");

                            SendMail(nameFile, subjectMail, bodyMail, mailingAddressRecipient);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dataGridCount++;
                            notSentFile = true;
                            break;
                        }

                        break;
                    }

                    foreach (var item in nameSendFile)
                    {
                        if (notSentFile)
                            File.Move($"{defaultPathSave}{item}", $@"{defaultPath}не отправленные файлы\{item}");
                        else
                            File.Move($"{defaultPathSave}{item}", $@"{defaultPath}отправленные файлы\{item}");
                        dataGridCount = 0;
                    }

                    notSentFile = false;

                    if (GetNameFile() == "0")
                        break;
                }

                panelHiding.SendToBack();
            }
            else
            {
                panelHiding.BringToFront();

                List<string> nameFile1 = new List<string>
                {
                    GetNameFile(false, dataGridViewListOrgToSend.CurrentRow.Index)
                };
                string subjectMail = dataGridViewListOrgToSend.CurrentRow.Cells[0].Value.ToString(); // Тема - Полное название файла по гриду
                string bodyMail = ""; // Тело - ??
                try
                {
                    string mailingAddressRecipient = GetMailingAddressRecipient(
                        dataGridViewListOrgToSend.CurrentRow.Cells[0].Value.ToString()); // Адрес для отправки - Из списка counterparties.xlsx

                    if (mailingAddressRecipient == "")
                        throw new ArgumentException($"{nameFile1[0].Split('.')[0].Trim()} не найден в списке контрагентов!");

                    SendMail(nameFile1, subjectMail, bodyMail, mailingAddressRecipient);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    notSentFile = true;
                }

                if (GetNameFile() != "0")
                {
                    if (notSentFile)
                        File.Move($"{defaultPathSave}{nameFile1[0]}", $@"{defaultPath}не отправленные файлы\{nameFile1[0]}");
                    else
                        File.Move($"{defaultPathSave}{nameFile1[0]}", $@"{defaultPath}отправленные файлы\{nameFile1[0]}");
                }

                GetNameFile();

                panelHiding.SendToBack();
            }
        }

        private void SendMail(List<string> nameFile, string subjectMail, string bodyMail, string mailingAddressRecipient)
        { // Формирование черновика почты для отправки файла(ов) через Outlook
            Outlook.Application app = new Outlook.Application();
            Outlook.MailItem mailItem = app.CreateItem(Outlook.OlItemType.olMailItem);
            mailItem.Display(false);
            mailItem.Subject = $"{subjectMail}";
            mailItem.To = $"{mailingAddressRecipient}";
            mailItem.Body = $"{bodyMail}";
            for (int i = 0; i < nameFile.Count; i++)
            {
                mailItem.Attachments.Add($"{defaultPathSave}{nameFile[i]}");
            }
            mailItem.Close(Outlook.OlInspectorClose.olSave);
        }

        private void SendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        { // Заполнение dataGridViewListOrgToSend файлами из папки созданных
            panelHiding.SendToBack();

            ButtonSendMail.Enabled = true;

            dataGridViewListOrgToSend.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (GetNameFile() != "0")
                dataGridViewListOrgToSend.CurrentCell = dataGridViewListOrgToSend.Rows[0].Cells[0];

            panelMail.BringToFront();
        }

        private string GetMailingAddressRecipient(string nameOrg)
        { // Получения адресов электронной почты из файла для отправки файлов
            DataTable dataTable = OpenExcelFile(defaultPath + "Контрагенты список.xlsx");

            foreach (DataRow row in dataTable.Rows)
            {
                string result = nameOrg.Split('.')[0];
                string result1 = result.Split(' ').Last();
                if (int.TryParse(result1, out int i))
                {
                    string[] lines = result.Split(' ');
                    result = "";
                    for (i = 0; i < lines.Length; i++)
                    {
                        lines[i] = lines[i].Trim();
                        if (int.TryParse(lines[i], out int j))
                            lines[i] = "";
                        result += " " + lines[i];
                    }
                    result = result.Trim();

                    if (row.Field<string>("Организация") == result)
                    {
                        return row.Field<string>("Почта для отправки счетов");
                    }
                }
                else
                {
                    if (row.Field<string>("Организация") == result)
                    {
                        return row.Field<string>("Почта для отправки счетов");
                    }
                }
            }

            return "";
        }
    }
}
