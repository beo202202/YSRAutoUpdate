using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        /// TETBL MIN
        /// </summary>
        public static string sTETBLMIN = String.Empty;

        /// <summary>
        /// TETBL MAX
        /// </summary>
        public static string sTETBLMAX = String.Empty;

        /// <summary>
        /// TETBL NAME
        /// </summary>
        public static string sTETBLNAME = String.Empty;




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
            //Main m = new Main();

            ///<summary>
            /// TETBL
            ///</summary>
            
            GetPrivateProfileString("TETBL", "MIN", "5306", Buf, 1024, sINIPath);
            //sTETBLMIN = Buf.ToString();
            //MessageBox.Show(sTETBLMIN);
            Main.main.comboBox1.SelectedItem = sTETBLMIN = Buf.ToString();

            GetPrivateProfileString("TETBL", "MAX", "5389", Buf, 1024, sINIPath);
            //sTETBLMAX = Buf.ToString();
            //MessageBox.Show(sTETBLMAX);
            Main.main.comboBox2.SelectedItem = sTETBLMAX = Buf.ToString();

            GetPrivateProfileString("TETBL", "NAME", "의사랑공DB", Buf, 1024, sINIPath);
            //sTETBLNAME = Buf.ToString();
            //MessageBox.Show(sTETBLNAME);
            Main.main.comboBox3.SelectedItem = sTETBLNAME = Buf.ToString();

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
            /// TETBLNumber
            ///</summary>
            WritePrivateProfileString("TETBL", "MIN", Main.main.comboBox1.SelectedItem.ToString(), sINIPath);
            WritePrivateProfileString("TETBL", "MAX", Main.main.comboBox2.SelectedItem.ToString(), sINIPath);
            WritePrivateProfileString("TETBL", "NAME", Main.main.comboBox3.SelectedItem.ToString(), sINIPath);

            ///<summary>
            /// UpdateResume
            ///</summary>
            // 업데이트 이력을 하려 했으나 각각의 데이터베이스 정보를 알 수 없었다...

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