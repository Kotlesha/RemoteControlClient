using RemoteControlClient.Controllers;
using RemoteControlClient.Models;

namespace RemoteControlClient.Views
{
    public partial class RemoteControlForm : Form
    {
        private Channels Channels;

        public RemoteControlForm(Channels channels)
        {
            InitializeComponent();
            Channels = channels;
            screenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            KeyPreview = true;
        }

        private async void RemoteControlForm_Load(object sender, EventArgs e) => await Channels.ImageChannel.StartStreamAsync(SetImage);

        private void RemoteControlForm_FormClosed(object sender, FormClosedEventArgs e) => Channels.Stop();

        private void SetImage(Bitmap image) => screenPictureBox.Image = image;

        private async Task SendMouseResponsesAsync(MouseState mouseState, MouseEventArgs e)
        {
            var screenPictureBoxSize = screenPictureBox.ClientSize;
            var imageSize = screenPictureBox.Image.Size;
            var point = Channels.MouseChannel.ScaleCoordinates(screenPictureBoxSize.Width, screenPictureBox.Height, imageSize.Width, imageSize.Height, e.Location.X, e.Location.Y);
            await Channels.MouseChannel.SendMouseResponsesAsync(imageSize.Width, imageSize.Height, point.X, point.Y, mouseState);
        }

        private async void screenPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) await SendMouseResponsesAsync(MouseState.MouseLeft, e);
            if (e.Button == MouseButtons.Right) await SendMouseResponsesAsync(MouseState.MouseRight, e);
        }

        private async void screenPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (screenPictureBox.Image is null)
            {
                return;
            }

            await SendMouseResponsesAsync(MouseState.MouseMove, e);
        }

        private async void screenPictureBox_MouseDoubleClick(object sender, MouseEventArgs e) => await SendMouseResponsesAsync(MouseState.MouseDoubleClick, e);


        private async void OpenChat_Click(object sender, EventArgs e)
        {
            bool result = await Channels.TextChannel.AskPermissionOnMessaging(Channels.Name);

            if (!result)
            {
                MessageBox.Show("Пользователь отказал в организации чата!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            TextChatForm form = new(Channels.TextChannel, Channels.Name);
            form.ShowDialog();
        }

        private async void RemoteControlForm_KeyDown(object sender, KeyEventArgs e)
        {
            await Channels.KeyboardChannel.SendKeyPressAsync((int)e.KeyCode);
        }
    }

}