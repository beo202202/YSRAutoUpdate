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
        //@"C:\테스트
        //\Config.ini"; // Environment.CurrentDirectory + "\\Config.ini";

        /// <summary>
        /// LAYOUT TOP
        /// </summary>
        public static string sTOP = String.Empty;

        /// <summary>
        /// LAYOUT OPASITY
        /// </summary>
        public static string sOPASITY = String.Empty;

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
        /// TETBL WINDOW
        /// </summary>
        public static string sTETBLWINDOW = String.Empty;

        /// <summary>
        /// TETBL2 PATH
        /// </summary>
        public static string sTETBLPATH = String.Empty;

        /// <summary>
        /// TETBL2 SMIN
        /// </summary>
        public static string sTETBLSMIN = String.Empty;

        /// <summary>
        /// TETBL2 SMAX
        /// </summary>
        public static string sTETBLSMAX = String.Empty;

        /// <summary>
        /// CLINIC CEHCK
        /// </summary>
        public static string sCHECK1 = String.Empty;
        public static string sCHECK2 = String.Empty;
        public static string sCHECK3 = String.Empty;
        public static string sCHECK4 = String.Empty;
        public static string sCHECK5 = String.Empty;
        public static string sCHECK6 = String.Empty;
        public static string sCHECK7 = String.Empty;
        public static string sCHECK8 = String.Empty;
        public static string sCHECK9 = String.Empty;
        public static string sCHECK10 = String.Empty;

        /// <summary>
        /// CLINIC NAME
        /// </summary>
        public static string sNAME1 = String.Empty;
        public static string sNAME2 = String.Empty;
        public static string sNAME3 = String.Empty;
        public static string sNAME4 = String.Empty;
        public static string sNAME5 = String.Empty;
        public static string sNAME6 = String.Empty;
        public static string sNAME7 = String.Empty;
        public static string sNAME8 = String.Empty;
        public static string sNAME9 = String.Empty;
        public static string sNAME10 = String.Empty;

        /// <summary>
        /// CLINIC PATH
        /// </summary>
        public static string sCLINIC1PATH = String.Empty;
        public static string sCLINIC2PATH = String.Empty;
        public static string sCLINIC3PATH = String.Empty;
        public static string sCLINIC4PATH = String.Empty;
        public static string sCLINIC5PATH = String.Empty;
        public static string sCLINIC6PATH = String.Empty;
        public static string sCLINIC7PATH = String.Empty;
        public static string sCLINIC8PATH = String.Empty;
        public static string sCLINIC9PATH = String.Empty;
        public static string sCLINIC10PATH = String.Empty;

        ///// <summary>
        ///// FTP IP
        ///// </summary>
        //public static string sFTPIP = String.Empty;

        ///// <summary>
        ///// FTP Port
        ///// </summary>
        //public static string sFTPPort = String.Empty;

        ///// <summary>
        ///// FTP User
        ///// </summary>
        //public static string sFTPUser = String.Empty;

        ///// <summary>
        ///// FTP Password
        ///// </summary>
        //public static string sFTPPw = String.Empty;

        //false 틀리지않다 true 틀리다 
        public static bool bCheck = false;

        public static (string, string, string, string, string, string, string, string, string, string, string, string,
            string, string, string, string, string, string, string, string, string, string,
            string, string, string, string, string, string, string, string, string, string, 
            string, string, string) LoadIniFile0()
        {
            StringBuilder Buf = new StringBuilder(1024);

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

            ///<summary>
            /// TETBL2
            ///</summary>
            GetPrivateProfileString("TETBL2", "PATH", @"C:\", Buf, 1024, sINIPath);
            sTETBLPATH = Buf.ToString();
            //SetForm.setform.textBox1.Text = sTETBLPATH = Buf.ToString();

            GetPrivateProfileString("TETBL2", "sMIN", "5306", Buf, 1024, sINIPath);
            sTETBLSMIN = Buf.ToString();
            //SetForm.setform.textBox2.Text = sTETBLSMIN = Buf.ToString();

            GetPrivateProfileString("TETBL2", "sMAX", "5389", Buf, 1024, sINIPath);
            sTETBLSMAX = Buf.ToString();
            //SetForm.setform.textBox3.Text = sTETBLSMAX = Buf.ToString();

            ///<summary>
            /// CLINIC CHECK
            ///</summary>
            GetPrivateProfileString("CLINICCHECK", "CHECK1", "false", Buf, 1024, sINIPath);
            sCHECK1 = Buf.ToString();
            //SetForm.setform.checkBox1.Checked = Convert.ToBoolean(sCHECK1);

            GetPrivateProfileString("CLINICCHECK", "CHECK2", "false", Buf, 1024, sINIPath);
            sCHECK2 = Buf.ToString();
            //SetForm.setform.checkBox2.Checked = Convert.ToBoolean(sCHECK2);

            GetPrivateProfileString("CLINICCHECK", "CHECK3", "false", Buf, 1024, sINIPath);
            sCHECK3 = Buf.ToString();
            //SetForm.setform.checkBox3.Checked = Convert.ToBoolean(sCHECK3);

            GetPrivateProfileString("CLINICCHECK", "CHECK4", "false", Buf, 1024, sINIPath);
            sCHECK4 = Buf.ToString();
            //SetForm.setform.checkBox4.Checked = Convert.ToBoolean(sCHECK4);

            GetPrivateProfileString("CLINICCHECK", "CHECK5", "false", Buf, 1024, sINIPath);
            sCHECK5 = Buf.ToString();
            //SetForm.setform.checkBox5.Checked = Convert.ToBoolean(sCHECK5);

            GetPrivateProfileString("CLINICCHECK", "CHECK6", "false", Buf, 1024, sINIPath);
            sCHECK6 = Buf.ToString();
            //SetForm.setform.checkBox6.Checked = Convert.ToBoolean(sCHECK6);

            GetPrivateProfileString("CLINICCHECK", "CHECK7", "false", Buf, 1024, sINIPath);
            sCHECK7 = Buf.ToString();
            //SetForm.setform.checkBox7.Checked = Convert.ToBoolean(sCHECK7);

            GetPrivateProfileString("CLINICCHECK", "CHECK8", "false", Buf, 1024, sINIPath);
            sCHECK8 = Buf.ToString();
            //SetForm.setform.checkBox8.Checked = Convert.ToBoolean(sCHECK8);

            GetPrivateProfileString("CLINICCHECK", "CHECK9", "false", Buf, 1024, sINIPath);
            sCHECK9 = Buf.ToString();
            //SetForm.setform.checkBox9.Checked = Convert.ToBoolean(sCHECK9);

            GetPrivateProfileString("CLINICCHECK", "CHECK10", "false", Buf, 1024, sINIPath);
            sCHECK10 = Buf.ToString();
            //SetForm.setform.checkBox10.Checked = Convert.ToBoolean(sCHECK10);

            ///<summary>
            /// CLINIC NAME
            ///</summary>
            GetPrivateProfileString("CLINICNAME", "sNAME1", "", Buf, 1024, sINIPath);
            sNAME1 = Buf.ToString();
            //SetForm.setform.textBox4.Text = sNAME1 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME2", "", Buf, 1024, sINIPath);
            sNAME2 = Buf.ToString();
            //SetForm.setform.textBox5.Text = sNAME2 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME3", "", Buf, 1024, sINIPath);
            sNAME3 = Buf.ToString();
            //SetForm.setform.textBox6.Text = sNAME3 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME4", "", Buf, 1024, sINIPath);
            sNAME4 = Buf.ToString();
            //SetForm.setform.textBox7.Text = sNAME4 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME5", "", Buf, 1024, sINIPath);
            sNAME5 = Buf.ToString();
            //SetForm.setform.textBox8.Text = sNAME5 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME6", "", Buf, 1024, sINIPath);
            sNAME6 = Buf.ToString();
            //SetForm.setform.textBox9.Text = sNAME6 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME7", "", Buf, 1024, sINIPath);
            sNAME7 = Buf.ToString();
            //SetForm.setform.textBox10.Text = sNAME7 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME8", "", Buf, 1024, sINIPath);
            sNAME8 = Buf.ToString();
            //SetForm.setform.textBox11.Text = sNAME8 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME9", "", Buf, 1024, sINIPath);
            sNAME9 = Buf.ToString();
            //SetForm.setform.textBox12.Text = sNAME9 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME10", "", Buf, 1024, sINIPath);
            sNAME10 = Buf.ToString();
            //SetForm.setform.textBox13.Text = sNAME10 = Buf.ToString();

            ///<summary>
            /// CLINIC PATH
            ///</summary>
            GetPrivateProfileString("CLINICPATH", "sCLINIC1PATH", "", Buf, 1024, sINIPath);
            sCLINIC1PATH = Buf.ToString();
            //SetForm.setform.textBox14.Text = sCLINIC1PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC2PATH", "", Buf, 1024, sINIPath);
            sCLINIC2PATH = Buf.ToString();
            //SetForm.setform.textBox15.Text = sCLINIC2PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC3PATH", "", Buf, 1024, sINIPath);
            sCLINIC3PATH = Buf.ToString();
            //SetForm.setform.textBox16.Text = sCLINIC3PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC4PATH", "", Buf, 1024, sINIPath);
            sCLINIC4PATH = Buf.ToString();
            //SetForm.setform.textBox17.Text = sCLINIC4PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC5PATH", "", Buf, 1024, sINIPath);
            sCLINIC5PATH = Buf.ToString();
            //SetForm.setform.textBox18.Text = sCLINIC5PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC6PATH", "", Buf, 1024, sINIPath);
            sCLINIC6PATH = Buf.ToString();
            //SetForm.setform.textBox19.Text = sCLINIC6PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC7PATH", "", Buf, 1024, sINIPath);
            sCLINIC7PATH = Buf.ToString();
            //SetForm.setform.textBox20.Text = sCLINIC7PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC8PATH", "", Buf, 1024, sINIPath);
            sCLINIC8PATH = Buf.ToString();
            //SetForm.setform.textBox21.Text = sCLINIC8PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC9PATH", "", Buf, 1024, sINIPath);
            sCLINIC9PATH = Buf.ToString();
            //SetForm.setform.textBox22.Text = sCLINIC9PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC10PATH", "", Buf, 1024, sINIPath);
            sCLINIC10PATH = Buf.ToString();
            //SetForm.setform.textBox23.Text = sCLINIC10PATH = Buf.ToString();

            return (sTETBLMIN, sTETBLMAX, sTETBLPATH, sTETBLSMIN, sTETBLSMAX,
            sCHECK1, sCHECK2, sCHECK3, sCHECK4, sCHECK5, sCHECK6, sCHECK7, sCHECK8, sCHECK9, sCHECK10,
            sNAME1, sNAME2, sNAME3, sNAME4, sNAME5, sNAME6, sNAME7, sNAME8, sNAME9, sNAME10,
            sCLINIC1PATH, sCLINIC2PATH, sCLINIC3PATH, sCLINIC4PATH, sCLINIC5PATH,
            sCLINIC6PATH, sCLINIC7PATH, sCLINIC8PATH, sCLINIC9PATH, sCLINIC10PATH);
        }

        public static void LoadIniFile()
        {
            StringBuilder Buf = new StringBuilder(1024);
            //Main m = new Main();

            ///<summary>
            /// LAYOUT
            ///</summary>
            GetPrivateProfileString("LAYOUT", "OPASITY", "100", Buf, 1024, sINIPath);
            //sTETBLMIN = Buf.ToString();            
            sOPASITY = Buf.ToString();
            Main.main.trackBar1.Value = Convert.ToInt32(sOPASITY);

            GetPrivateProfileString("LAYOUT", "TOP", "false", Buf, 1024, sINIPath);
            //sTETBLMIN = Buf.ToString();            
            sTOP = Buf.ToString();
            Main.main.checkBox1.Checked = Convert.ToBoolean(sTOP);

            ///<summary>
            /// TETBL
            ///</summary>
            GetPrivateProfileString("TETBL", "MIN", "5306", Buf, 1024, sINIPath);
            //sTETBLMIN = Buf.ToString();
            //MessageBox.Show(sTETBLMIN);
            Main.main.comboBox1.SelectedItem = sTETBLMIN = Buf.ToString();
            //MessageBox.Show(sTETBLMIN);

            GetPrivateProfileString("TETBL", "MAX", "5389", Buf, 1024, sINIPath);
            //sTETBLMAX = Buf.ToString();
            //MessageBox.Show(sTETBLMAX);
            Main.main.comboBox2.SelectedItem = sTETBLMAX = Buf.ToString();
            //MessageBox.Show(sTETBLMAX);

            GetPrivateProfileString("TETBL", "NAME", "서울안과", Buf, 1024, sINIPath);
            //sTETBLNAME = Buf.ToString();
            //MessageBox.Show(sTETBLNAME);
            Main.main.comboBox3.SelectedItem = sTETBLNAME = Buf.ToString();

            GetPrivateProfileString("TETBL", "WINDOW", "기본", Buf, 1024, sINIPath);
            //sTETBLNAME = Buf.ToString();
            //MessageBox.Show(sTETBLNAME);
            Main.main.comboBox4.SelectedItem = sTETBLWINDOW = Buf.ToString();
        }

        public static void LoadIniFile2()
        {
            StringBuilder Buf = new StringBuilder(1024);
            
            ///<summary>
            /// TETBL2
            ///</summary>
            GetPrivateProfileString("TETBL2", "PATH", @"C:\", Buf, 1024, sINIPath);
            SetForm.setform.textBox1.Text = sTETBLPATH = Buf.ToString();

            GetPrivateProfileString("TETBL2", "sMIN", "5306", Buf, 1024, sINIPath);
            SetForm.setform.textBox2.Text = sTETBLSMIN = Buf.ToString();

            GetPrivateProfileString("TETBL2", "sMAX", "5389", Buf, 1024, sINIPath);
            SetForm.setform.textBox3.Text = sTETBLSMAX = Buf.ToString();

            ///<summary>
            /// CLINIC CHECK
            ///</summary>
            GetPrivateProfileString("CLINICCHECK", "CHECK1", "false", Buf, 1024, sINIPath);
            sCHECK1 = Buf.ToString();
            SetForm.setform.checkBox1.Checked = Convert.ToBoolean(sCHECK1);

            GetPrivateProfileString("CLINICCHECK", "CHECK2", "false", Buf, 1024, sINIPath);
            sCHECK2 = Buf.ToString();
            SetForm.setform.checkBox2.Checked = Convert.ToBoolean(sCHECK2);

            GetPrivateProfileString("CLINICCHECK", "CHECK3", "false", Buf, 1024, sINIPath);
            sCHECK3 = Buf.ToString();
            SetForm.setform.checkBox3.Checked = Convert.ToBoolean(sCHECK3);

            GetPrivateProfileString("CLINICCHECK", "CHECK4", "false", Buf, 1024, sINIPath);
            sCHECK4 = Buf.ToString();
            SetForm.setform.checkBox4.Checked = Convert.ToBoolean(sCHECK4);

            GetPrivateProfileString("CLINICCHECK", "CHECK5", "false", Buf, 1024, sINIPath);
            sCHECK5 = Buf.ToString();
            SetForm.setform.checkBox5.Checked = Convert.ToBoolean(sCHECK5);

            GetPrivateProfileString("CLINICCHECK", "CHECK6", "false", Buf, 1024, sINIPath);
            sCHECK6 = Buf.ToString();
            SetForm.setform.checkBox6.Checked = Convert.ToBoolean(sCHECK6);

            GetPrivateProfileString("CLINICCHECK", "CHECK7", "false", Buf, 1024, sINIPath);
            sCHECK7 = Buf.ToString();
            SetForm.setform.checkBox7.Checked = Convert.ToBoolean(sCHECK7);

            GetPrivateProfileString("CLINICCHECK", "CHECK8", "false", Buf, 1024, sINIPath);
            sCHECK8 = Buf.ToString();
            SetForm.setform.checkBox8.Checked = Convert.ToBoolean(sCHECK8);

            GetPrivateProfileString("CLINICCHECK", "CHECK9", "false", Buf, 1024, sINIPath);
            sCHECK9 = Buf.ToString();
            SetForm.setform.checkBox9.Checked = Convert.ToBoolean(sCHECK9);

            GetPrivateProfileString("CLINICCHECK", "CHECK10", "false", Buf, 1024, sINIPath);
            sCHECK10 = Buf.ToString();
            SetForm.setform.checkBox10.Checked = Convert.ToBoolean(sCHECK10);

            ///<summary>
            /// CLINIC NAME
            ///</summary>
            GetPrivateProfileString("CLINICNAME", "sNAME1", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox4.Text = sNAME1 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME2", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox5.Text = sNAME2 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME3", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox6.Text = sNAME3 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME4", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox7.Text = sNAME4 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME5", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox8.Text = sNAME5 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME6", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox9.Text = sNAME6 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME7", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox10.Text = sNAME7 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME8", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox11.Text = sNAME8 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME9", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox12.Text = sNAME9 = Buf.ToString();

            GetPrivateProfileString("CLINICNAME", "sNAME10", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox13.Text = sNAME10 = Buf.ToString();

            ///<summary>
            /// CLINIC PATH
            ///</summary>
            GetPrivateProfileString("CLINICPATH", "sCLINIC1PATH", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox14.Text = sCLINIC1PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC2PATH", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox15.Text = sCLINIC2PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC3PATH", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox16.Text = sCLINIC3PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC4PATH", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox17.Text = sCLINIC4PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC5PATH", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox18.Text = sCLINIC5PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC6PATH", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox19.Text = sCLINIC6PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC7PATH", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox20.Text = sCLINIC7PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC8PATH", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox21.Text = sCLINIC8PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC9PATH", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox22.Text = sCLINIC9PATH = Buf.ToString();

            GetPrivateProfileString("CLINICPATH", "sCLINIC10PATH", "", Buf, 1024, sINIPath);
            SetForm.setform.textBox23.Text = sCLINIC10PATH = Buf.ToString();

        }

        public static void SavaIniFile()
        {
            ///<summary>
            /// LAYOUT
            ///</summary>
            WritePrivateProfileString("LAYOUT", "TOP", Main.main.checkBox1.Checked.ToString(), sINIPath);
            WritePrivateProfileString("LAYOUT", "OPASITY", Main.main.trackBar1.Value.ToString(), sINIPath);

            ///<summary>
            /// TETBL
            ///</summary>
            WritePrivateProfileString("TETBL", "MIN", Main.main.comboBox1.SelectedItem.ToString(), sINIPath);
            WritePrivateProfileString("TETBL", "MAX", Main.main.comboBox2.SelectedItem.ToString(), sINIPath);
            WritePrivateProfileString("TETBL", "NAME", Main.main.comboBox3.SelectedItem.ToString(), sINIPath);
            WritePrivateProfileString("TETBL", "WINDOW", Main.main.comboBox4.SelectedItem.ToString(), sINIPath);

            ///<summary>
            /// UpdateResume
            ///</summary>
            // 업데이트 이력을 하려 했으나 각각의 데이터베이스 정보를 알 수 없었다...

            /////<summary>
            ///// FTP
            /////</summary>
            //WritePrivateProfileString("FTP", "IP", sFTPIP, sINIPath);

            //WritePrivateProfileString("FTP", "PORT", sFTPPort, sINIPath);

            //WritePrivateProfileString("FTP", "USER", sFTPUser, sINIPath);

            //WritePrivateProfileString("FTP", "PW", sFTPPw, sINIPath);
        }

        public static void SavaIniFile2()
        {
            ///<summary>
            /// TETBL2
            ///</summary>
            WritePrivateProfileString("TETBL2", "PATH", SetForm.setform.textBox1.Text, sINIPath);
            WritePrivateProfileString("TETBL2", "SMIN", SetForm.setform.textBox2.Text, sINIPath);
            WritePrivateProfileString("TETBL2", "SMAX", SetForm.setform.textBox3.Text, sINIPath);

            ///<summary>
            /// CLINIC CHECK
            ///</summary>
            WritePrivateProfileString("CLINICCHECK", "CHECK1", SetForm.setform.checkBox1.Checked.ToString(), sINIPath);
            WritePrivateProfileString("CLINICCHECK", "CHECK2", SetForm.setform.checkBox2.Checked.ToString(), sINIPath);
            WritePrivateProfileString("CLINICCHECK", "CHECK3", SetForm.setform.checkBox3.Checked.ToString(), sINIPath);
            WritePrivateProfileString("CLINICCHECK", "CHECK4", SetForm.setform.checkBox4.Checked.ToString(), sINIPath);
            WritePrivateProfileString("CLINICCHECK", "CHECK5", SetForm.setform.checkBox5.Checked.ToString(), sINIPath);
            WritePrivateProfileString("CLINICCHECK", "CHECK6", SetForm.setform.checkBox6.Checked.ToString(), sINIPath);
            WritePrivateProfileString("CLINICCHECK", "CHECK7", SetForm.setform.checkBox7.Checked.ToString(), sINIPath);
            WritePrivateProfileString("CLINICCHECK", "CHECK8", SetForm.setform.checkBox8.Checked.ToString(), sINIPath);
            WritePrivateProfileString("CLINICCHECK", "CHECK9", SetForm.setform.checkBox9.Checked.ToString(), sINIPath);
            WritePrivateProfileString("CLINICCHECK", "CHECK10", SetForm.setform.checkBox10.Checked.ToString(), sINIPath);

            ///<summary>
            /// CLINIC NAME
            ///</summary>
            WritePrivateProfileString("CLINICNAME", "sNAME1", SetForm.setform.textBox4.Text, sINIPath);
            WritePrivateProfileString("CLINICNAME", "sNAME2", SetForm.setform.textBox5.Text, sINIPath);
            WritePrivateProfileString("CLINICNAME", "sNAME3", SetForm.setform.textBox6.Text, sINIPath);
            WritePrivateProfileString("CLINICNAME", "sNAME4", SetForm.setform.textBox7.Text, sINIPath);
            WritePrivateProfileString("CLINICNAME", "sNAME5", SetForm.setform.textBox8.Text, sINIPath);
            WritePrivateProfileString("CLINICNAME", "sNAME6", SetForm.setform.textBox9.Text, sINIPath);
            WritePrivateProfileString("CLINICNAME", "sNAME7", SetForm.setform.textBox10.Text, sINIPath);
            WritePrivateProfileString("CLINICNAME", "sNAME8", SetForm.setform.textBox11.Text, sINIPath);
            WritePrivateProfileString("CLINICNAME", "sNAME9", SetForm.setform.textBox12.Text, sINIPath);
            WritePrivateProfileString("CLINICNAME", "sNAME10", SetForm.setform.textBox13.Text, sINIPath);

            ///<summary>
            /// CLINIC PATH
            ///</summary>
            WritePrivateProfileString("CLINICPATH", "sCLINIC1PATH", SetForm.setform.textBox14.Text, sINIPath);
            WritePrivateProfileString("CLINICPATH", "sCLINIC2PATH", SetForm.setform.textBox15.Text, sINIPath);
            WritePrivateProfileString("CLINICPATH", "sCLINIC3PATH", SetForm.setform.textBox16.Text, sINIPath);
            WritePrivateProfileString("CLINICPATH", "sCLINIC4PATH", SetForm.setform.textBox17.Text, sINIPath);
            WritePrivateProfileString("CLINICPATH", "sCLINIC5PATH", SetForm.setform.textBox18.Text, sINIPath);
            WritePrivateProfileString("CLINICPATH", "sCLINIC6PATH", SetForm.setform.textBox19.Text, sINIPath);
            WritePrivateProfileString("CLINICPATH", "sCLINIC7PATH", SetForm.setform.textBox20.Text, sINIPath);
            WritePrivateProfileString("CLINICPATH", "sCLINIC8PATH", SetForm.setform.textBox21.Text, sINIPath);
            WritePrivateProfileString("CLINICPATH", "sCLINIC9PATH", SetForm.setform.textBox22.Text, sINIPath);
            WritePrivateProfileString("CLINICPATH", "sCLINIC10PATH", SetForm.setform.textBox23.Text, sINIPath);

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