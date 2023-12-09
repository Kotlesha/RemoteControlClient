using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RemoteControlClient
{
    internal static class IpAddressOperations
    {
        public static bool IsValidIPv4Address(string ipAdress)
        {
            if (string.IsNullOrWhiteSpace(ipAdress))
                return false;

            string[] splitValues = ipAdress.Split('.');
            foreach (var part in splitValues) Console.WriteLine(part);
            if (splitValues.Length != 4)
                return false;

            return IPAddress.TryParse(ipAdress, out IPAddress address);
        }

        public static string GetIpAddress()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] ipAddresses = Dns.GetHostEntry(hostName).AddressList;
            string ipAddress = ipAddresses.First(ip => ip.AddressFamily == AddressFamily.InterNetwork).ToString();
            return ipAddress;
        }
    }
}
