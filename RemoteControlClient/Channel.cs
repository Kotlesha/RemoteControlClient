using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RemoteControlClient
{
    public abstract class Channel
    {
        public TcpClient TcpClient { get; private set; }
        public CancellationTokenSource Cts { get; private set; }
        public int BufferSize { get; private set; }

        public Channel(int bufferSize = 8_096)
        {
            TcpClient = new();
            Cts = new();
            BufferSize = bufferSize;
        }

        public async Task<bool> TryConnectAsync(string host, int port)
        {
            if (TcpClient.Connected) return true;

            try { await TcpClient.ConnectAsync(host, port); }
            catch (SocketException) { return false; }
            return true;
        }

        private async Task SendMessageAsync(string message)
        {
            NetworkStream stream = TcpClient.GetStream();
            byte[] buffer = Encoding.UTF8.GetBytes(message);
            await stream.WriteAsync(buffer, Cts.Token);
            await stream.FlushAsync();
        }

        private async Task<Response> ReceiveMessageAsync()
        {
            NetworkStream stream = TcpClient.GetStream();
            byte[] buffer = new byte[BufferSize];

            using MemoryStream ms = new();
            int bytesRead;
            string data;
            do
            {
                bytesRead = await stream.ReadAsync(buffer.AsMemory(0, BufferSize));
                data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                await ms.WriteAsync(buffer.AsMemory(0, bytesRead));
            } while (!data.Contains('}'));

            string jsonResponse = Encoding.UTF8.GetString(ms.ToArray());
            Response response = JsonSerializer.Deserialize<Response>(jsonResponse);
            return response;
        }

        protected async Task<Response> TransmitMessageAsync<T>(int idOperation, T item)
        {
            string jsonData = JsonSerializer.Serialize(item);
            Request request = new() { IdOperation = idOperation, JsonData = jsonData };
            string jsonRequest = JsonSerializer.Serialize(request);
            await SendMessageAsync(jsonRequest);
            Response response = await ReceiveMessageAsync();
            return response;
        }

        public void Stop() => Cts.Cancel();

        public void RepairCancellationToken() => Cts = new();
    }
}
