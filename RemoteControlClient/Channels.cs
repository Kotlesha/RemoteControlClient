using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RemoteControlClient
{
    public class Channels
    {
        public ImageChannel ImageChannel { get; private set; }
        public MouseChannel MouseChannel { get; private set; }

        public Channels()
        {
            ImageChannel = new ImageChannel();
            MouseChannel = new MouseChannel();
        }

        public async Task<bool> TryConnectAsync(string host, int port)
        {
            bool imageChannelTryConnect = await ImageChannel.TryConnectAsync(host, port);
            bool MouseChannelTryConnect = await MouseChannel.TryConnectAsync(host, port);
            return imageChannelTryConnect && MouseChannelTryConnect;
        }

        public void RepairCancellationTokens()
        {
            ImageChannel.RepairCancellationToken();
            MouseChannel.RepairCancellationToken();
        }

        public void Stop()
        {
            ImageChannel.Stop();
            MouseChannel.Stop();
        }
    }
}
