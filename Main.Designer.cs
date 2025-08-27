namespace Trucking
{
    partial class TruckingMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TruckingMain));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SendEmailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelUser = new System.Windows.Forms.Panel();
            this.comboBoxRKB = new System.Windows.Forms.ComboBox();
            this.CheckRKB = new System.Windows.Forms.CheckBox();
            this.comboBoxUsers = new System.Windows.Forms.ComboBox();
            this.userChoice = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMail = new System.Windows.Forms.Panel();
            this.ButtonSendMail = new System.Windows.Forms.Button();
            this.checkBoxSendAllOrSingl = new System.Windows.Forms.CheckBox();
            this.dataGridViewListOrgToSend = new System.Windows.Forms.DataGridView();
            this.panelActSchet = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxNotifications = new System.Windows.Forms.CheckBox();
            this.checkBoxNotZero = new System.Windows.Forms.CheckBox();
            this.checkCreateAll = new System.Windows.Forms.CheckBox();
            this.checkBoxOpenFolder = new System.Windows.Forms.CheckBox();
            this.checkBoxPlus1Num = new System.Windows.Forms.CheckBox();
            this.ButtonCreateAS = new System.Windows.Forms.Button();
            this.checkBoxCloseDoc = new System.Windows.Forms.CheckBox();
            this.checkBoxPrint = new System.Windows.Forms.CheckBox();
            this.checkBoxSchet = new System.Windows.Forms.CheckBox();
            this.checkBoxAct = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker3 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxOrg = new System.Windows.Forms.ComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.ToolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.panelHiding = new System.Windows.Forms.Panel();
            this.labelLoad = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panelUser.SuspendLayout();
            this.panelMail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListOrgToSend)).BeginInit();
            this.panelActSchet.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panelHiding.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Excel|*.xls";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.RestartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(521, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ASToolStripMenuItem,
            this.SendEmailToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // ASToolStripMenuItem
            // 
            this.ASToolStripMenuItem.Name = "ASToolStripMenuItem";
            this.ASToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.ASToolStripMenuItem.Text = "AKT и СЧЁТ";
            this.ASToolStripMenuItem.Click += new System.EventHandler(this.ASToolStripMenuItem_Click);
            // 
            // SendEmailToolStripMenuItem
            // 
            this.SendEmailToolStripMenuItem.Name = "SendEmailToolStripMenuItem";
            this.SendEmailToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.SendEmailToolStripMenuItem.Text = "EMAIL рассылка";
            this.SendEmailToolStripMenuItem.Click += new System.EventHandler(this.SendEmailToolStripMenuItem_Click);
            // 
            // RestartToolStripMenuItem
            // 
            this.RestartToolStripMenuItem.Name = "RestartToolStripMenuItem";
            this.RestartToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.RestartToolStripMenuItem.Text = "Перезапустить";
            this.RestartToolStripMenuItem.Click += new System.EventHandler(this.RestartToolStripMenuItem_Click);
            // 
            // panelUser
            // 
            this.panelUser.Controls.Add(this.comboBoxRKB);
            this.panelUser.Controls.Add(this.CheckRKB);
            this.panelUser.Controls.Add(this.comboBoxUsers);
            this.panelUser.Controls.Add(this.userChoice);
            this.panelUser.Location = new System.Drawing.Point(10, 24);
            this.panelUser.Name = "panelUser";
            this.panelUser.Size = new System.Drawing.Size(494, 489);
            this.panelUser.TabIndex = 3;
            // 
            // comboBoxRKB
            // 
            this.comboBoxRKB.FormattingEnabled = true;
            this.comboBoxRKB.Location = new System.Drawing.Point(159, 355);
            this.comboBoxRKB.Name = "comboBoxRKB";
            this.comboBoxRKB.Size = new System.Drawing.Size(173, 21);
            this.comboBoxRKB.TabIndex = 6;
            this.comboBoxRKB.Visible = false;
            // 
            // CheckRKB
            // 
            this.CheckRKB.AutoSize = true;
            this.CheckRKB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.CheckRKB.Location = new System.Drawing.Point(218, 328);
            this.CheckRKB.Name = "CheckRKB";
            this.CheckRKB.Size = new System.Drawing.Size(54, 21);
            this.CheckRKB.TabIndex = 5;
            this.CheckRKB.Text = "РКБ";
            this.CheckRKB.UseVisualStyleBackColor = true;
            this.CheckRKB.CheckedChanged += new System.EventHandler(this.CheckRKB_CheckedChanged);
            // 
            // comboBoxUsers
            // 
            this.comboBoxUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxUsers.FormattingEnabled = true;
            this.comboBoxUsers.Location = new System.Drawing.Point(98, 170);
            this.comboBoxUsers.Name = "comboBoxUsers";
            this.comboBoxUsers.Size = new System.Drawing.Size(303, 28);
            this.comboBoxUsers.TabIndex = 4;
            // 
            // userChoice
            // 
            this.userChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userChoice.Location = new System.Drawing.Point(159, 242);
            this.userChoice.Name = "userChoice";
            this.userChoice.Size = new System.Drawing.Size(173, 57);
            this.userChoice.TabIndex = 3;
            this.userChoice.Text = "ВЫБРАТЬ";
            this.userChoice.UseVisualStyleBackColor = true;
            this.userChoice.Click += new System.EventHandler(this.UserChoice_Click);
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(2, 24);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(471, 479);
            this.panelMain.TabIndex = 6;
            // 
            // panelMail
            // 
            this.panelMail.Controls.Add(this.ButtonSendMail);
            this.panelMail.Controls.Add(this.checkBoxSendAllOrSingl);
            this.panelMail.Controls.Add(this.dataGridViewListOrgToSend);
            this.panelMail.Location = new System.Drawing.Point(3, 24);
            this.panelMail.Name = "panelMail";
            this.panelMail.Size = new System.Drawing.Size(513, 427);
            this.panelMail.TabIndex = 5;
            // 
            // ButtonSendMail
            // 
            this.ButtonSendMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonSendMail.Location = new System.Drawing.Point(12, 368);
            this.ButtonSendMail.Name = "ButtonSendMail";
            this.ButtonSendMail.Size = new System.Drawing.Size(123, 46);
            this.ButtonSendMail.TabIndex = 2;
            this.ButtonSendMail.Text = "ОТПРАВИТЬ";
            this.ButtonSendMail.UseVisualStyleBackColor = true;
            this.ButtonSendMail.Click += new System.EventHandler(this.ButtonSendMail_Click);
            // 
            // checkBoxSendAllOrSingl
            // 
            this.checkBoxSendAllOrSingl.AutoSize = true;
            this.checkBoxSendAllOrSingl.Checked = true;
            this.checkBoxSendAllOrSingl.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSendAllOrSingl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSendAllOrSingl.Location = new System.Drawing.Point(12, 331);
            this.checkBoxSendAllOrSingl.Name = "checkBoxSendAllOrSingl";
            this.checkBoxSendAllOrSingl.Size = new System.Drawing.Size(140, 22);
            this.checkBoxSendAllOrSingl.TabIndex = 1;
            this.checkBoxSendAllOrSingl.Text = "Отправить всем";
            this.checkBoxSendAllOrSingl.UseVisualStyleBackColor = true;
            // 
            // dataGridViewListOrgToSend
            // 
            this.dataGridViewListOrgToSend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewListOrgToSend.Location = new System.Drawing.Point(12, 13);
            this.dataGridViewListOrgToSend.Name = "dataGridViewListOrgToSend";
            this.dataGridViewListOrgToSend.Size = new System.Drawing.Size(456, 299);
            this.dataGridViewListOrgToSend.TabIndex = 0;
            // 
            // panelActSchet
            // 
            this.panelActSchet.Controls.Add(this.textBox2);
            this.panelActSchet.Controls.Add(this.label12);
            this.panelActSchet.Controls.Add(this.label11);
            this.panelActSchet.Controls.Add(this.checkBoxNotifications);
            this.panelActSchet.Controls.Add(this.checkBoxNotZero);
            this.panelActSchet.Controls.Add(this.checkCreateAll);
            this.panelActSchet.Controls.Add(this.checkBoxOpenFolder);
            this.panelActSchet.Controls.Add(this.checkBoxPlus1Num);
            this.panelActSchet.Controls.Add(this.ButtonCreateAS);
            this.panelActSchet.Controls.Add(this.checkBoxCloseDoc);
            this.panelActSchet.Controls.Add(this.checkBoxPrint);
            this.panelActSchet.Controls.Add(this.checkBoxSchet);
            this.panelActSchet.Controls.Add(this.checkBoxAct);
            this.panelActSchet.Controls.Add(this.textBox1);
            this.panelActSchet.Controls.Add(this.dateTimePicker3);
            this.panelActSchet.Controls.Add(this.dateTimePicker2);
            this.panelActSchet.Controls.Add(this.dateTimePicker1);
            this.panelActSchet.Controls.Add(this.label6);
            this.panelActSchet.Controls.Add(this.label5);
            this.panelActSchet.Controls.Add(this.label4);
            this.panelActSchet.Controls.Add(this.label3);
            this.panelActSchet.Controls.Add(this.label2);
            this.panelActSchet.Controls.Add(this.label1);
            this.panelActSchet.Controls.Add(this.comboBoxOrg);
            this.panelActSchet.Location = new System.Drawing.Point(3, 24);
            this.panelActSchet.Name = "panelActSchet";
            this.panelActSchet.Size = new System.Drawing.Size(499, 447);
            this.panelActSchet.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(185, 166);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(123, 24);
            this.textBox2.TabIndex = 24;
            this.textBox2.Text = "1";
            this.textBox2.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(155, 11);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 18);
            this.label12.TabIndex = 23;
            this.label12.Text = "0";
            this.label12.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(112, 11);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 18);
            this.label11.TabIndex = 22;
            this.label11.Text = "РКБ";
            this.label11.Visible = false;
            // 
            // checkBoxNotifications
            // 
            this.checkBoxNotifications.AutoSize = true;
            this.checkBoxNotifications.Location = new System.Drawing.Point(280, 410);
            this.checkBoxNotifications.Name = "checkBoxNotifications";
            this.checkBoxNotifications.Size = new System.Drawing.Size(153, 17);
            this.checkBoxNotifications.TabIndex = 20;
            this.checkBoxNotifications.Text = "Выключить уведомления";
            this.checkBoxNotifications.UseVisualStyleBackColor = true;
            // 
            // checkBoxNotZero
            // 
            this.checkBoxNotZero.AutoSize = true;
            this.checkBoxNotZero.Checked = true;
            this.checkBoxNotZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNotZero.Location = new System.Drawing.Point(280, 396);
            this.checkBoxNotZero.Name = "checkBoxNotZero";
            this.checkBoxNotZero.Size = new System.Drawing.Size(201, 17);
            this.checkBoxNotZero.TabIndex = 19;
            this.checkBoxNotZero.Text = "Не создавать нулевые документы";
            this.checkBoxNotZero.UseVisualStyleBackColor = true;
            // 
            // checkCreateAll
            // 
            this.checkCreateAll.AutoSize = true;
            this.checkCreateAll.Location = new System.Drawing.Point(105, 272);
            this.checkCreateAll.Name = "checkCreateAll";
            this.checkCreateAll.Size = new System.Drawing.Size(89, 17);
            this.checkCreateAll.TabIndex = 18;
            this.checkCreateAll.Text = "Создать всё";
            this.checkCreateAll.UseVisualStyleBackColor = true;
            // 
            // checkBoxOpenFolder
            // 
            this.checkBoxOpenFolder.AutoSize = true;
            this.checkBoxOpenFolder.Location = new System.Drawing.Point(165, 397);
            this.checkBoxOpenFolder.Name = "checkBoxOpenFolder";
            this.checkBoxOpenFolder.Size = new System.Drawing.Size(108, 17);
            this.checkBoxOpenFolder.TabIndex = 17;
            this.checkBoxOpenFolder.Text = "Открыть папку?";
            this.checkBoxOpenFolder.UseVisualStyleBackColor = true;
            // 
            // checkBoxPlus1Num
            // 
            this.checkBoxPlus1Num.AutoSize = true;
            this.checkBoxPlus1Num.Location = new System.Drawing.Point(141, 172);
            this.checkBoxPlus1Num.Name = "checkBoxPlus1Num";
            this.checkBoxPlus1Num.Size = new System.Drawing.Size(38, 17);
            this.checkBoxPlus1Num.TabIndex = 16;
            this.checkBoxPlus1Num.Text = "+1";
            this.checkBoxPlus1Num.UseVisualStyleBackColor = true;
            // 
            // ButtonCreateAS
            // 
            this.ButtonCreateAS.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ButtonCreateAS.Location = new System.Drawing.Point(12, 341);
            this.ButtonCreateAS.Name = "ButtonCreateAS";
            this.ButtonCreateAS.Size = new System.Drawing.Size(138, 48);
            this.ButtonCreateAS.TabIndex = 15;
            this.ButtonCreateAS.Text = "СОЗДАТЬ";
            this.ButtonCreateAS.UseVisualStyleBackColor = true;
            this.ButtonCreateAS.Click += new System.EventHandler(this.ButtonCreateAS_Click);
            // 
            // checkBoxCloseDoc
            // 
            this.checkBoxCloseDoc.AutoSize = true;
            this.checkBoxCloseDoc.Checked = true;
            this.checkBoxCloseDoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCloseDoc.Location = new System.Drawing.Point(12, 397);
            this.checkBoxCloseDoc.Name = "checkBoxCloseDoc";
            this.checkBoxCloseDoc.Size = new System.Drawing.Size(147, 17);
            this.checkBoxCloseDoc.TabIndex = 14;
            this.checkBoxCloseDoc.Text = "Закрывать документы?";
            this.checkBoxCloseDoc.UseVisualStyleBackColor = true;
            // 
            // checkBoxPrint
            // 
            this.checkBoxPrint.AutoSize = true;
            this.checkBoxPrint.Location = new System.Drawing.Point(12, 318);
            this.checkBoxPrint.Name = "checkBoxPrint";
            this.checkBoxPrint.Size = new System.Drawing.Size(62, 17);
            this.checkBoxPrint.TabIndex = 13;
            this.checkBoxPrint.Text = "Печать";
            this.checkBoxPrint.UseVisualStyleBackColor = true;
            // 
            // checkBoxSchet
            // 
            this.checkBoxSchet.AutoSize = true;
            this.checkBoxSchet.Checked = true;
            this.checkBoxSchet.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSchet.Location = new System.Drawing.Point(12, 295);
            this.checkBoxSchet.Name = "checkBoxSchet";
            this.checkBoxSchet.Size = new System.Drawing.Size(49, 17);
            this.checkBoxSchet.TabIndex = 12;
            this.checkBoxSchet.Text = "Счёт";
            this.checkBoxSchet.UseVisualStyleBackColor = true;
            // 
            // checkBoxAct
            // 
            this.checkBoxAct.AutoSize = true;
            this.checkBoxAct.Checked = true;
            this.checkBoxAct.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxAct.Location = new System.Drawing.Point(12, 272);
            this.checkBoxAct.Name = "checkBoxAct";
            this.checkBoxAct.Size = new System.Drawing.Size(44, 17);
            this.checkBoxAct.TabIndex = 11;
            this.checkBoxAct.Text = "Акт";
            this.checkBoxAct.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(12, 166);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(123, 24);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "1";
            // 
            // dateTimePicker3
            // 
            this.dateTimePicker3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker3.Location = new System.Drawing.Point(12, 232);
            this.dateTimePicker3.Name = "dateTimePicker3";
            this.dateTimePicker3.Size = new System.Drawing.Size(182, 24);
            this.dateTimePicker3.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CustomFormat = "";
            this.dateTimePicker2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker2.Location = new System.Drawing.Point(250, 101);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(182, 24);
            this.dateTimePicker2.TabIndex = 8;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "";
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Location = new System.Drawing.Point(31, 101);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(182, 24);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(9, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 18);
            this.label6.TabIndex = 6;
            this.label6.Text = "На какое число?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(9, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 18);
            this.label5.TabIndex = 5;
            this.label5.Text = "Номер";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(219, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "по";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(9, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 18);
            this.label3.TabIndex = 3;
            this.label3.Text = "с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(9, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "С какой по какую дату?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(9, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Организация";
            // 
            // comboBoxOrg
            // 
            this.comboBoxOrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxOrg.FormattingEnabled = true;
            this.comboBoxOrg.Location = new System.Drawing.Point(12, 32);
            this.comboBoxOrg.Name = "comboBoxOrg";
            this.comboBoxOrg.Size = new System.Drawing.Size(420, 26);
            this.comboBoxOrg.TabIndex = 0;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(33, 22);
            this.toolStripLabel1.Text = "Лист";
            // 
            // ToolStripComboBox1
            // 
            this.ToolStripComboBox1.Name = "ToolStripComboBox1";
            this.ToolStripComboBox1.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.ToolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // panelHiding
            // 
            this.panelHiding.Controls.Add(this.labelLoad);
            this.panelHiding.Controls.Add(this.panelUser);
            this.panelHiding.Location = new System.Drawing.Point(2, 0);
            this.panelHiding.Name = "panelHiding";
            this.panelHiding.Size = new System.Drawing.Size(489, 519);
            this.panelHiding.TabIndex = 4;
            // 
            // labelLoad
            // 
            this.labelLoad.AutoSize = true;
            this.labelLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLoad.Location = new System.Drawing.Point(141, 210);
            this.labelLoad.Name = "labelLoad";
            this.labelLoad.Size = new System.Drawing.Size(164, 29);
            this.labelLoad.TabIndex = 0;
            this.labelLoad.Text = "ЗАГРУЗКА...";
            // 
            // TruckingMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 531);
            this.Controls.Add(this.panelActSchet);
            this.Controls.Add(this.panelMail);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panelHiding);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "TruckingMain";
            this.Text = "Грузоперевозки";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelUser.ResumeLayout(false);
            this.panelUser.PerformLayout();
            this.panelMail.ResumeLayout(false);
            this.panelMail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewListOrgToSend)).EndInit();
            this.panelActSchet.ResumeLayout(false);
            this.panelActSchet.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panelHiding.ResumeLayout(false);
            this.panelHiding.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ASToolStripMenuItem;
        private System.Windows.Forms.Panel panelUser;
        private System.Windows.Forms.Button userChoice;
        private System.Windows.Forms.Panel panelActSchet;
        private System.Windows.Forms.ComboBox comboBoxOrg;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonCreateAS;
        private System.Windows.Forms.CheckBox checkBoxCloseDoc;
        private System.Windows.Forms.CheckBox checkBoxPrint;
        private System.Windows.Forms.CheckBox checkBoxSchet;
        private System.Windows.Forms.CheckBox checkBoxAct;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox ToolStripComboBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.CheckBox checkBoxPlus1Num;
        private System.Windows.Forms.Panel panelHiding;
        private System.Windows.Forms.Label labelLoad;
        private System.Windows.Forms.ToolStripMenuItem SendEmailToolStripMenuItem;
        private System.Windows.Forms.Panel panelMail;
        private System.Windows.Forms.DataGridView dataGridViewListOrgToSend;
        private System.Windows.Forms.Button ButtonSendMail;
        private System.Windows.Forms.CheckBox checkBoxSendAllOrSingl;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.ComboBox comboBoxUsers;
        private System.Windows.Forms.CheckBox checkBoxOpenFolder;
        private System.Windows.Forms.ToolStripMenuItem RestartToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkCreateAll;
        private System.Windows.Forms.CheckBox checkBoxNotZero;
        private System.Windows.Forms.CheckBox checkBoxNotifications;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox CheckRKB;
        private System.Windows.Forms.ComboBox comboBoxRKB;
    }
}

