using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RemoteControlClient
{
    public class MouseChannel : Channel
    {
        public async Task<int> SendMouseResponses(Point point)
        {
            Response response = await TransmitMessageAsync(2, point);
            int code = Convert.ToInt32(response.ResultData);
            return code;
        }
    }
}
