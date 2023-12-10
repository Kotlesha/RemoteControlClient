using RemoteControlClient.Models;

namespace RemoteControlClient.Controllers.ProcessingData
{
    public class KeyboardChannel : Channel
    {
        public async Task<bool> SendKeyPressAsync(int keyCode)
        {
            Response response = await TransmitMessageAsync(3, keyCode);
            int code = Convert.ToInt32(response.ResultData);
            return code == 200;
        }
    }
}
