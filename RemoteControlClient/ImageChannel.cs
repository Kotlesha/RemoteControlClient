﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RemoteControlClient
{
    public class ImageChannel : Channel
    {
        public async Task<bool> AskPermissionOnScreenBroadcastingAsync(string name)
        {
            Response response = await TransmitMessageAsync(0, name);
            int code = Convert.ToInt32(response.ResultData);
            return code == 200;
        }

        private async Task<Bitmap> GetScreenshotsAsync()
        {
            Response response = await TransmitMessageAsync(1, new object());
            byte[] imageBytes = Convert.FromBase64String(response.ResultData);
            using MemoryStream ms = new(imageBytes);
            Bitmap image = new(ms);
            return image;
        }

        public async Task StartStreamAsync(Action<Bitmap> SetImage)
        {
            while (!Cts.IsCancellationRequested)
            {
                var image = await GetScreenshotsAsync();
                SetImage(image);
            }
        }
    }
}
