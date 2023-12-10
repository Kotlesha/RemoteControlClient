using RemoteControlClient.Controllers.ProcessingData;

namespace RemoteControlClient.Controllers
{
    public class Channels
    {
        public ImageChannel ImageChannel { get; private set; }
        public MouseChannel MouseChannel { get; private set; }
        public KeyboardChannel KeyboardChannel { get; private set; }
        public TextChannel TextChannel { get; private set; }
        public string Name { get; set; }
        public Channels()
        {
            ImageChannel = new();
            MouseChannel = new();
            KeyboardChannel = new();
            TextChannel = new();
        }

        public async Task<bool> TryConnectAsync(string host, int port)
        {
            bool imageChannelTryConnect = await ImageChannel.TryConnectAsync(host, port);
            bool MouseChannelTryConnect = await MouseChannel.TryConnectAsync(host, port);
            bool KeyboardChannelTryConnect = await KeyboardChannel.TryConnectAsync(host, port);
            bool TextChannelTryConnect = await TextChannel.TryConnectAsync(host, port);
            return imageChannelTryConnect && MouseChannelTryConnect && KeyboardChannelTryConnect && TextChannelTryConnect;
        }

        public void RepairCancellationTokens()
        {
            ImageChannel.RepairCancellationToken();
            MouseChannel.RepairCancellationToken();
            KeyboardChannel.RepairCancellationToken();
            TextChannel.RepairCancellationToken();
        }

        public void Stop()
        {
            ImageChannel.Stop();
            MouseChannel.Stop();
            KeyboardChannel.Stop();
            TextChannel.Stop();
        }
    }
}
