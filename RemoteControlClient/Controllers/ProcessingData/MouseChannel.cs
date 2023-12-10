using RemoteControlClient.Models;

namespace RemoteControlClient.Controllers.ProcessingData
{
    public class MouseChannel : Channel
    {
        public async Task<int> SendMouseResponsesAsync(int Width, int Height, int X, int Y, MouseState mouseAction)
        {
            int[] data = { Width, Height, X, Y, (int)mouseAction };
            Response response = await TransmitMessageAsync(2, data);
            int code = Convert.ToInt32(response.ResultData);
            return code;
        }

        public (int X, int Y) ScaleCoordinates(int oldImageWidth, int oldImageHeight, int newImageWidth, int newImageHeight, int mouseX, int mouseY)
        {
            double scaleX = (double)newImageWidth / oldImageWidth;
            double scaleY = (double)newImageHeight / oldImageHeight;

            mouseX = (int)(mouseX * scaleX);
            mouseY = (int)(mouseY * scaleY);
            return (mouseX, mouseY);
        }
    }
}
