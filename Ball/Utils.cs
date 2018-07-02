using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ball
{
    static class Utils
    {
        /// <summary>
        /// Exit immidiately (Force Break)
        /// </summary>
        public static void ExitImmidiately()
        {
            System.Environment.Exit(0);
        }
        public static string GetTime_File()
        {
            return DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
        }
        public static string GetTime_Normal()
        {
            return DateTime.Now.ToString();
        }
        public static string GetLogFullName()
        {
            return Configures.LogPath + Configures.LogFileName;
        }
    }
}
