namespace RemoteControlClient
{
    partial class ConnectToServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConnectToServerForm));
            panel1 = new Panel();
            label5 = new Label();
            userLogin = new TextBox();
            label4 = new Label();
            ipAdressServerTextBox = new TextBox();
            ConnectToServer = new Button();
            label3 = new Label();
            portNumberNumericUpDown = new NumericUpDown();
            label2 = new Label();
            ipAdressClientTextBox = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)portNumberNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(userLogin);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(ipAdressServerTextBox);
            panel1.Controls.Add(ConnectToServer);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(portNumberNumericUpDown);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(ipAdressClientTextBox);
            panel1.Location = new Point(12, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 326);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 84);
            label5.Name = "label5";
            label5.Size = new Size(111, 20);
            label5.TabIndex = 8;
            label5.Text = "Логин клиента";
            // 
            // userLogin
            // 
            userLogin.Location = new Point(13, 107);
            userLogin.Name = "userLogin";
            userLogin.Size = new Size(269, 26);
            userLogin.TabIndex = 7;
            userLogin.Text = "gfyuvh";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(13, 152);
            label4.Name = "label4";
            label4.Size = new Size(128, 20);
            label4.TabIndex = 6;
            label4.Text = "IP-адрес сервера";
            // 
            // ipAdressServerTextBox
            // 
            ipAdressServerTextBox.Location = new Point(13, 175);
            ipAdressServerTextBox.Name = "ipAdressServerTextBox";
            ipAdressServerTextBox.Size = new Size(269, 26);
            ipAdressServerTextBox.TabIndex = 5;
            ipAdressServerTextBox.Text = "192.168.100.6";
            // 
            // ConnectToServer
            // 
            ConnectToServer.Location = new Point(85, 279);
            ConnectToServer.Name = "ConnectToServer";
            ConnectToServer.Size = new Size(124, 28);
            ConnectToServer.TabIndex = 4;
            ConnectToServer.Text = "Подключиться";
            ConnectToServer.UseVisualStyleBackColor = true;
            ConnectToServer.Click += ConnectToServer_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 217);
            label3.Name = "label3";
            label3.Size = new Size(44, 20);
            label3.TabIndex = 3;
            label3.Text = "Порт";
            // 
            // portNumberNumericUpDown
            // 
            portNumberNumericUpDown.Location = new Point(13, 240);
            portNumberNumericUpDown.Maximum = new decimal(new int[] { 9000, 0, 0, 0 });
            portNumberNumericUpDown.Name = "portNumberNumericUpDown";
            portNumberNumericUpDown.Size = new Size(269, 26);
            portNumberNumericUpDown.TabIndex = 2;
            portNumberNumericUpDown.Value = new decimal(new int[] { 8888, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 16);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 1;
            label2.Text = "IP-адрес клиента";
            // 
            // ipAdressClientTextBox
            // 
            ipAdressClientTextBox.Location = new Point(13, 39);
            ipAdressClientTextBox.Name = "ipAdressClientTextBox";
            ipAdressClientTextBox.ReadOnly = true;
            ipAdressClientTextBox.Size = new Size(269, 26);
            ipAdressClientTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 10);
            label1.Name = "label1";
            label1.Size = new Size(174, 20);
            label1.TabIndex = 0;
            label1.Text = "Информация о клиенте";
            // 
            // ConnectToServerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 359);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ConnectToServerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Удалённый рабочий стол";
            FormClosed += ConnectToServerForm_FormClosed;
            Load += ConnectToServerForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)portNumberNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button ConnectToServer;
        private Label label3;
        private NumericUpDown portNumberNumericUpDown;
        private Label label2;
        private TextBox ipAdressClientTextBox;
        private Label label4;
        private TextBox ipAdressServerTextBox;
        private Label label5;
        private TextBox userLogin;
    }
}