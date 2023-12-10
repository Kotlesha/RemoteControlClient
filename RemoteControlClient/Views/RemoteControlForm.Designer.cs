namespace RemoteControlClient.Views
{
    partial class RemoteControlForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoteControlForm));
            screenPictureBox = new PictureBox();
            OpenChat = new Button();
            ((System.ComponentModel.ISupportInitialize)screenPictureBox).BeginInit();
            SuspendLayout();
            // 
            // screenPictureBox
            // 
            screenPictureBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            screenPictureBox.BorderStyle = BorderStyle.FixedSingle;
            screenPictureBox.Location = new Point(0, 0);
            screenPictureBox.Name = "screenPictureBox";
            screenPictureBox.Size = new Size(1296, 740);
            screenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            screenPictureBox.TabIndex = 0;
            screenPictureBox.TabStop = false;
            screenPictureBox.MouseClick += screenPictureBox_MouseClick;
            screenPictureBox.MouseDoubleClick += screenPictureBox_MouseDoubleClick;
            screenPictureBox.MouseMove += screenPictureBox_MouseMove;
            // 
            // OpenChat
            // 
            OpenChat.Anchor = AnchorStyles.Bottom;
            OpenChat.Location = new Point(510, 750);
            OpenChat.Name = "OpenChat";
            OpenChat.Size = new Size(253, 28);
            OpenChat.TabIndex = 1;
            OpenChat.Text = "Отправить сообщение";
            OpenChat.UseVisualStyleBackColor = true;
            OpenChat.Click += OpenChat_Click;
            // 
            // RemoteControlForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1296, 790);
            Controls.Add(OpenChat);
            Controls.Add(screenPictureBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RemoteControlForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление удалённым рабочим столом";
            FormClosed += RemoteControlForm_FormClosed;
            Load += RemoteControlForm_Load;
            KeyDown += RemoteControlForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)screenPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox screenPictureBox;
        private Button OpenChat;
    }
}