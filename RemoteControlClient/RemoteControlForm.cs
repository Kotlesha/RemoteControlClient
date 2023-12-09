using System.Windows.Forms;

namespace RemoteControlClient
{
    public partial class RemoteControlForm : Form
    {
        private Channels Channels;

        public RemoteControlForm(Channels channels)
        {
            InitializeComponent();
            Channels = channels;
            screenPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private async void RemoteControlForm_Load(object sender, EventArgs e) => await Channels.ImageChannel.StartStreamAsync(SetImage);

        private void RemoteControlForm_FormClosed(object sender, FormClosedEventArgs e) => Channels.Stop();

        private void SetImage(Bitmap image) => screenPictureBox.Image = image;

        private async void screenPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            await Channels.MouseChannel.SendMouseResponses(e.Location);
            await Task.Delay(500);
        }
    }

}