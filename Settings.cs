using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using UnityEngine;
using ForcedPVP;

namespace ForcedPVP
{
    class Settings
    {
        public static bool isNewVersionAvailable()
        {
            WebClient client = new WebClient();
            client.Headers.Add("User-Agent: BWard Server");
            string reply;
            try
            {
                reply = client.DownloadString(PVPLOAD.ApiRepository);
                PVPLOAD.newestVersion = reply.Split(new[] { "," }, StringSplitOptions.None)[0].Trim().Replace("\"", "").Replace("[{name:", "");
            }
            catch
            {
                Debug.Log("The newest version could not be determined.");
                PVPLOAD.newestVersion = "Unknown";
            }

            if (PVPLOAD.newestVersion != PVPLOAD.version)
            {
                return true;
            }

            return false;
        }
    }
}
