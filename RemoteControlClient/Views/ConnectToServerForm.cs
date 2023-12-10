using RemoteControlClient.Controllers;

namespace RemoteControlClient.Views
{
    public partial class ConnectToServerForm : Form
    {
        private static Channels channels;

        public ConnectToServerForm()
        {
            InitializeComponent();
            channels = new();
            ipAdressClientTextBox.Text = IpAddressOperations.GetIpAddress();
        }

        private async void ConnectToServer_Click(object sender, EventArgs e)
        {
            if (userLogin.Text.Trim().Length < 5)
            {
                MessageBox.Show("Логин пользователя должен содержать как минимум 5 символов!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userLogin.Focus();
                return;
            }

            if (!IpAddressOperations.IsValidIPv4Address(ipAdressServerTextBox.Text))
            {
                MessageBox.Show("Неправильный ip-адрес. Пожалуйста, повторите, попытку!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ipAdressServerTextBox.Focus();
                return;
            }

            channels.RepairCancellationTokens();
            var tryConnectStatus = await channels.TryConnectAsync(ipAdressServerTextBox.Text, (int)portNumberNumericUpDown.Value);

            if (!tryConnectStatus)
            {
                MessageBox.Show("Сервер не доступен!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConnectToServer.Focus();
                return;
            }

            var permissionToScreenBroadcasting = await channels.ImageChannel.AskPermissionOnScreenBroadcastingAsync(userLogin.Text);

            if (!permissionToScreenBroadcasting)
            {
                MessageBox.Show("Пользователь отверг важе предложение на трансляцию!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConnectToServer.Focus();
                return;
            }

            channels.Name = userLogin.Text;
            RemoteControlForm form = new(channels);
            Hide();
            form.ShowDialog();
            Show();
        }

        private void ConnectToServerForm_Load(object sender, EventArgs e) => ActiveControl = userLogin;

        private void ConnectToServerForm_FormClosed(object sender, FormClosedEventArgs e) { }
    }
}