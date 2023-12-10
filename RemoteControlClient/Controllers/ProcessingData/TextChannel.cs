using RemoteControlClient.Models;

namespace RemoteControlClient.Controllers.ProcessingData
{
    public class TextChannel : Channel
    {
        public async Task<bool> AskPermissionOnMessaging(string name)
        {
            Response response = await TransmitMessageAsync(4, name);
            int code = Convert.ToInt32(response.ResultData);
            return code == 200;
        }

        public async Task<string> GetMessage(string message)
        {
            Response response = await TransmitMessageAsync(5, message);
            return response.ResultData;
        }
    }
}
