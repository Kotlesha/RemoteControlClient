namespace RemoteControlClient
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
            ((System.ComponentModel.ISupportInitialize)screenPictureBox).BeginInit();
            SuspendLayout();
            // 
            // screenPictureBox
            // 
            screenPictureBox.Dock = DockStyle.Fill;
            screenPictureBox.Location = new Point(0, 0);
            screenPictureBox.Name = "screenPictureBox";
            screenPictureBox.Size = new Size(1297, 718);
            screenPictureBox.TabIndex = 0;
            screenPictureBox.TabStop = false;
            screenPictureBox.MouseMove += screenPictureBox_MouseMove;
            // 
            // RemoteControlForm
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1297, 718);
            Controls.Add(screenPictureBox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RemoteControlForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление удалённым рабочим столом";
            FormClosed += RemoteControlForm_FormClosed;
            Load += RemoteControlForm_Load;
            ((System.ComponentModel.ISupportInitialize)screenPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox screenPictureBox;
    }
}