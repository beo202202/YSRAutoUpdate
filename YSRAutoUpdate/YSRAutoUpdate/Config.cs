using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YSR
{
    public static class Config
    {
        // ini 파일을 불러올 때 사용되는 함수
        [System.Runtime.InteropServices.DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string sAppName, string sKeyName, string sDefault, StringBuilder sReturnedString, int nSize,
            string sFileName);

        // ini 파일에 저장할 때 사용되는 함수
        [System.Runtime.InteropServices.DllImport("kernel32")]
        public static extern int WritePrivateProfileString(string sAppName, string sKeyName, string sValue, string sFileName);

        public static string sINIPath = Environment.CurrentDirectory + "\\Config.ini";
        //@"C:\범범조조
        //\Config.ini"; // Environment.CurrentDirectory + "\\Config.ini";

        /// <summary>
        /// Database IP
        /// </summary>
        public static string sDBIP = String.Empty;

        /// <summary>
        /// Databbase User
        /// </summary>
        public static string sDBUser = String.Empty;

        /// <summary>
        /// Database Password
        /// </summary>
        public static string sDBPw = String.Empty;

        /// <summary>
        /// Database Name
        /// </summary>
        public static string sDBName = String.Empty;

        /// <summary>
        /// FTP IP
        /// </summary>
        public static string sFTPIP = String.Empty;

        /// <summary>
        /// FTP Port
        /// </summary>
        public static string sFTPPort = String.Empty;

        /// <summary>
        /// FTP User
        /// </summary>
        public static string sFTPUser = String.Empty;

        /// <summary>
        /// FTP Password
        /// </summary>
        public static string sFTPPw = String.Empty;

        //false 틀리지않다 true 틀리다 
        public static bool bCheck = false;

        public static void LoadIniFile()
        {
            StringBuilder Buf = new StringBuilder(1024);

            ///<summary>
            /// Database
            ///</summary>
            GetPrivateProfileString("SERVER", "IP", "127.0.0.1", Buf, 1024, sINIPath);
            sDBIP = Buf.ToString();

            GetPrivateProfileString("SERVER", "USER", "범범조조", Buf, 1024, sINIPath);
            sDBUser = Buf.ToString();

            GetPrivateProfileString("SERVER", "PW", "12345", Buf, 1024, sINIPath);
            sDBPw = Buf.ToString();

            GetPrivateProfileString("SERVER", "DATABASE", "범범", Buf, 1024, sINIPath);
            sDBName = Buf.ToString();

            ///<summary>
            /// FTP
            ///</summary>
            GetPrivateProfileString("FTP", "IP", "127.0.0.1", Buf, 1024, sINIPath);
            sFTPIP = Buf.ToString();

            GetPrivateProfileString("FTP", "PORT", "9999", Buf, 1024, sINIPath);
            sFTPPort = Buf.ToString();

            GetPrivateProfileString("FTP", "USER", "범범조조", Buf, 1024, sINIPath);
            sFTPUser = Buf.ToString();

            GetPrivateProfileString("FTP", "PW", "범범조조", Buf, 1024, sINIPath);
            sFTPPw = Buf.ToString();
        }

        public static void SavaIniFile()
        {
            ///<summary>
            /// Database
            ///</summary>
            WritePrivateProfileString("SERVER", "IP", sDBIP, sINIPath);

            WritePrivateProfileString("SERVER", "USER", sDBUser, sINIPath);

            WritePrivateProfileString("SERVER", "PW", sDBPw, sINIPath);

            WritePrivateProfileString("SERVER", "DATABASE", sDBName, sINIPath);

            ///<summary>
            /// FTP
            ///</summary>
            WritePrivateProfileString("FTP", "IP", sFTPIP, sINIPath);

            WritePrivateProfileString("FTP", "PORT", sFTPPort, sINIPath);

            WritePrivateProfileString("FTP", "USER", sFTPUser, sINIPath);

            WritePrivateProfileString("FTP", "PW", sFTPPw, sINIPath);
        }

        public static void WriteUpdatingInfo(bool b)
        {
            string sVal = b == true ? "true" : "false";
            WritePrivateProfileString("UPDATE", "UPDATING", sVal, sINIPath);
        }

        public static string ReadUpdatingInfo()
        {
            StringBuilder Buf = new StringBuilder(1024);
            GetPrivateProfileString("UPDATE", "UPDATING", "", Buf, 1024, sINIPath);

            return Buf.ToString();
        }
    }
}