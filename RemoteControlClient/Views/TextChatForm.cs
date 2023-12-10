using RemoteControlClient.Controllers.ProcessingData;

namespace RemoteControlClient.Views
{
    public partial class TextChatForm : Form
    {
        private static TextChannel TextChannel;
        private static string Name;

        public TextChatForm(TextChannel textChannel, string name)
        {
            InitializeComponent();
            TextChannel = textChannel;
            Name = name;
        }

        private async void Send_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textInput.Text.Trim()))
            {
                MessageBox.Show("Введена пустая строка!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textInput.Focus();
                return;
            }

            string response = await TextChannel.GetMessage(textInput.Text.Trim());
            chat.Items.Add($"{Name}: {textInput.Text.Trim()}");
            chat.Items.Add(response);
        }
    }
}
