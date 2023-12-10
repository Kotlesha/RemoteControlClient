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
                MessageBox.Show("����� ������������ ������ ��������� ��� ������� 5 ��������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                userLogin.Focus();
                return;
            }

            if (!IpAddressOperations.IsValidIPv4Address(ipAdressServerTextBox.Text))
            {
                MessageBox.Show("������������ ip-�����. ����������, ���������, �������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ipAdressServerTextBox.Focus();
                return;
            }

            channels.RepairCancellationTokens();
            var tryConnectStatus = await channels.TryConnectAsync(ipAdressServerTextBox.Text, (int)portNumberNumericUpDown.Value);

            if (!tryConnectStatus)
            {
                MessageBox.Show("������ �� ��������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConnectToServer.Focus();
                return;
            }

            var permissionToScreenBroadcasting = await channels.ImageChannel.AskPermissionOnScreenBroadcastingAsync(userLogin.Text);

            if (!permissionToScreenBroadcasting)
            {
                MessageBox.Show("������������ ������ ���� ����������� �� ����������!", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
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