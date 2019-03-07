using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Web;

namespace SfDesk.Models
{
    public class Utility
    {
        public static string GetMacAddress()
        {
            return
              (
                  from nic in NetworkInterface.GetAllNetworkInterfaces()
                  where nic.OperationalStatus == OperationalStatus.Up
                  select nic.GetPhysicalAddress().ToString()
              ).FirstOrDefault();
        }
        public static string GetIPAddress()
        {
            string hostName = Dns.GetHostName();
            return Dns.GetHostByName(hostName).AddressList[0].ToString();
        }
        
    }
}