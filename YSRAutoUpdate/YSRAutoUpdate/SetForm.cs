using Microsoft.VisualStudio.Utilities;
using Microsoft.WindowsAPICodePack.Dialogs;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using YSRAutoUpdate;
using static System.Net.WebRequestMethods;

namespace YSR
{
    public partial class SetForm : Form
    {
        public static SetForm setform;
        //private string strLocalFolder = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\'));
        //static 잘 모르겠당.
        static string sPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string strLocalFolder = System.IO.Path.GetDirectoryName(sPath);
        string strXmlFile = "\\Setting.xml";

        public SetForm()
        {
            InitializeComponent();
        }

        private void SetForm_Shown(object sender, EventArgs e)
        {
            setform = this;

            LogClass l = new LogClass();

            환경설정3();
            
            //파일이 존재 하지 않으면...
            if (!System.IO.File.Exists(strLocalFolder + strXmlFile))
                //MessageBox.Show("없네요.");
                l.Log(Main.main.lboxLog, "저장된 세팅이 없습니다.");
            return;            
        }

        private void 환경설정3()
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            l.Log(Main.main.lboxLog, "환경설정2를 불러오는 중...");
            Config.LoadIniFile2();
            l.Log(Main.main.lboxLog, "환경설정2를 불러왔습니다.");
            
            l = null;
        }

        private void 환경설정4()
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            (string sTETBLMIN, string sTETBLMAX,
                string sTETBLPATH, string sTETBLSMIN, string sTETBLSMAX,
            string sCHECK1, string sCHECK2, string sCHECK3, string sCHECK4, string sCHECK5,
            string sCHECK6, string sCHECK7, string sCHECK8, string sCHECK9, string sCHECK10,
            string sNAME1, string sNAME2, string sNAME3, string sNAME4, string sNAME5,
            string sNAME6, string sNAME7, string sNAME8, string sNAME9, string sNAME10,
            string sCLINIC1PATH, string sCLINIC2PATH, string sCLINIC3PATH, string sCLINIC4PATH, string sCLINIC5PATH,
            string sCLINIC6PATH, string sCLINIC7PATH, string sCLINIC8PATH, string sCLINIC9PATH, string sCLINIC10PATH)
            = Config.LoadIniFile0();

            //+(오류) 현재값이 없는 초기값이라면? 콤보1,콤보2가 0이다....
            // 콤보1 값이 0 
            //MessageBox.Show(Convert.ToInt32(Main.main.comboBox1.SelectedItem).ToString());
            //MessageBox.Show(comboBox2.SelectedItem.ToString());
            //COM_MIN = Convert.ToInt32(Main.main.comboBox1.SelectedItem);
            int COM_MIN = Convert.ToInt32(sTETBLMIN);
            //MessageBox.Show("COM_MIN = " + COM_MIN);
            //COM_MAX = Convert.ToInt32(comboBox2.SelectedItem);
            int COM_MAX = Convert.ToInt32(sTETBLMAX);
            //MessageBox.Show("COM_MAX = " + COM_MAX);

            //+(오류) sTETBLSMIN 설정값이 지금 설정보다 높을 경우 값을 초기화 해야한다.

            //MessageBox.Show(sTETBLMAX);
            Main.main.comboBox1.Items.Clear();
            if (COM_MIN == 0 || COM_MAX == 0 || COM_MIN < Convert.ToInt32(sTETBLSMIN)
                || Convert.ToInt32(sTETBLSMAX) < COM_MAX || COM_MAX < COM_MIN)
            {
                if (COM_MIN == 0)
                {
                    l.Log(Main.main.lboxLog, "초기화(사유: 최소 현재값이 설정되어 있지 않습니다.)");
                }
                if (COM_MAX == 0)
                {
                    l.Log(Main.main.lboxLog, "초기화(사유: 최대 현재값이 설정되어 있지 않습니다.)");
                }
                else if (Convert.ToInt32(sTETBLSMAX) < COM_MAX)
                {
                    l.Log(Main.main.lboxLog, "초기화(사유: 최대 설정값이 최대 현대값보다 작습니다.)");
                }
                else if (COM_MAX < COM_MIN)
                {
                    l.Log(Main.main.lboxLog, "초기화(사유: 현재 최대값이 현재 최소값보다 작습니다.)");
                }
                else
                {
                    l.Log(Main.main.lboxLog, "초기화(사유: 최소 현재값이 최소 설정값보다 작습니다.)");
                }
                for (int i = Convert.ToInt32(sTETBLSMIN); i <= Convert.ToInt32(sTETBLSMAX); i++)
                {
                    Main.main.comboBox1.Items.Add(i);
                }
                Main.main.comboBox1.SelectedIndex = 0; // 초기화
                l.Log(Main.main.lboxLog, "최소 TETBL" + Main.main.comboBox1.SelectedItem + "로 초기화되었습니다.");
                COM_MIN = Convert.ToInt32(Main.main.comboBox1.SelectedItem);
                Config.SavaIniFile();
            }
            else // 값이 이상이 없다면
            {
                for (int i = Convert.ToInt32(sTETBLSMIN); i <= COM_MAX; i++)
                {
                    Main.main.comboBox1.Items.Add(i);
                }
                Main.main.comboBox1.SelectedItem = COM_MIN;
            }

            Main.main.comboBox2.Items.Clear();
            for (int i = Convert.ToInt32(sTETBLSMIN); i <= Convert.ToInt32(sTETBLSMAX); i++)
            {
                Main.main.comboBox2.Items.Add(i);
            }
            if (COM_MAX == 0)
            {
                l.Log(Main.main.lboxLog, "초기화(사유: 최대 현재값이 설정되어 있지 않습니다.)");
                Main.main.comboBox2.SelectedIndex = 0;
                l.Log(Main.main.lboxLog, "최대 TETBL" + Main.main.comboBox2.SelectedItem + "로 초기화되었습니다.");
                COM_MAX = Convert.ToInt32(Main.main.comboBox2.SelectedItem);
                Config.SavaIniFile();
            }
            else if (Convert.ToInt32(sTETBLSMAX) < COM_MAX)
            {
                l.Log(Main.main.lboxLog, "초기화(사유: 설정 값이 현재 값 보다 작습니다.)");
                Main.main.comboBox2.SelectedIndex = 0;
                l.Log(Main.main.lboxLog, "최대 TETBL" + Main.main.comboBox2.SelectedItem + "로 초기화되었습니다.");
                COM_MAX = Convert.ToInt32(Main.main.comboBox2.SelectedItem);
                Config.SavaIniFile();
            }
            else if (COM_MAX < COM_MIN)
            {
                l.Log(Main.main.lboxLog, "초기화(사유: 현재 최대값이 현재 최소값보다 작습니다.)");
                Main.main.comboBox2.SelectedIndex = 0;
                l.Log(Main.main.lboxLog, "최대 TETBL" + Main.main.comboBox2.SelectedItem + "로 초기화되었습니다.");
                COM_MAX = Convert.ToInt32(Main.main.comboBox2.SelectedItem);
                Config.SavaIniFile();
            }
            else //평소랑 같다면
            {
                Main.main.comboBox2.SelectedItem = COM_MAX;
            }

            //MessageBox.Show("COM_MIN = " + COM_MIN);
            //MessageBox.Show("COM_MAX = " + COM_MAX);

            int labelMAX = COM_MAX - COM_MIN + 1;
            //MessageBox.Show("labelMAX = " + labelMAX);
            Main.main.labelProgressBar1.Maximum = labelMAX;

            l = null;
        }

        private void 환경설정5()
        {
            LogClass l = new LogClass();

            (string sTETBLMIN, string sTETBLMAX,
                string sTETBLPATH, string sTETBLSMIN, string sTETBLSMAX,
            string sCHECK1, string sCHECK2, string sCHECK3, string sCHECK4, string sCHECK5,
            string sCHECK6, string sCHECK7, string sCHECK8, string sCHECK9, string sCHECK10,
            string sNAME1, string sNAME2, string sNAME3, string sNAME4, string sNAME5,
            string sNAME6, string sNAME7, string sNAME8, string sNAME9, string sNAME10,
            string sCLINIC1PATH, string sCLINIC2PATH, string sCLINIC3PATH, string sCLINIC4PATH, string sCLINIC5PATH,
            string sCLINIC6PATH, string sCLINIC7PATH, string sCLINIC8PATH, string sCLINIC9PATH, string sCLINIC10PATH)
            = Config.LoadIniFile0();

            // 설정값이 바뀌면 인덱스값이 바뀐다.... 생각해야한다.


            Main.main.comboBox3.Items.Clear();
            Main.main.comboBox3.Items.Add("새로 설정해주세요.");
            if (sCHECK1 == "True")
            {
                Main.main.comboBox3.Items.Add(sNAME1);
            }
            if (sCHECK2 == "True")
            {
                Main.main.comboBox3.Items.Add(sNAME2);
            }
            if (sCHECK3 == "True")
            {
                Main.main.comboBox3.Items.Add(sNAME3);
            }
            if (sCHECK4 == "True")
            {
                Main.main.comboBox3.Items.Add(sNAME4);
            }
            if (sCHECK5 == "True")
            {
                Main.main.comboBox3.Items.Add(sNAME5);
            }
            if (sCHECK6 == "True")
            {
                Main.main.comboBox3.Items.Add(sNAME6);
            }
            if (sCHECK7 == "True")
            {
                Main.main.comboBox3.Items.Add(sNAME7);
            }
            if (sCHECK8 == "True")
            {
                Main.main.comboBox3.Items.Add(sNAME8);
            }
            if (sCHECK9 == "True")
            {
                Main.main.comboBox3.Items.Add(sNAME9);
            }
            if (sCHECK10 == "True")
            {
                Main.main.comboBox3.Items.Add(sNAME10);
            }
            Main.main.comboBox3.SelectedIndex = 0;

            l = null;
        }
        private void button1_Click(object sender, EventArgs e) // 저장
        {
            LogClass l = new LogClass();

            Button btn = sender as Button;

            l.Log(Main.main.lboxLog, $"{btn.Text} 버튼 Click");

            Config.SavaIniFile2();

            l = null;
        }

        #region CommonOpenFileDialog
        public string ChangeFolderPath()
        {
            LogClass l = new LogClass();

            l.Log(Main.main.lboxLog, "의사랑 업데이트 폴더 선택");

            string FilePath = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            {
                dialog.IsFolderPicker = true; // true : 폴더 선택 / false : 파일 선택
                dialog.Title = "의사랑 업데이트 폴더 선택";

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    FilePath = dialog.FileName;
                }
            }
            l = null;
            return FilePath;
        }

        public string ChangeFilePath() //파일명만 가져오고 확장자명은 제외하는 방법이 없당....
        {
            string FilePath = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            {
                dialog.IsFolderPicker = false; // true : 폴더 선택 / false : 파일 선택
                dialog.Title = "병의원 파일 선택";
                dialog.Filters.Add(new CommonFileDialogFilter("링크 파일 (*.lnk)", "*.lnk"));
                dialog.DefaultExtension = ".lnk";                
                
                dialog.EnsureFileExists = false;

                //dialog.DefaultExt = ".lnk;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    FilePath = dialog.FileName;
                }
            }
            return FilePath;
        }

        private void OFD(object sender, EventArgs e)
        {
            LogClass l = new LogClass();
            //MessageBox.Show(((Button)sender).Name);
            string name = ((Button)sender).Name;
            string name2 = Regex.Replace(name, @"\D", "");
            int i = int.Parse(name2);

            l.Log(Main.main.lboxLog, name + " 병의원 Database 선택");
            //int i = Convert.ToInt32(name.Substring(name.Length - 1)); // 둘째자리 숫자부터는 오류가 생기니 숫자만 얻자
            //MessageBox.Show(name2);

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "병의원 Database 선택";
            ofd.DefaultExt = ".lnk";
            ofd.Filter = "링크 파일 (*.lnk)|*.lnk";
            ofd.DereferenceLinks = false; // false : 바로가기의 주소 true : 바로가기의 역참조 주소
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            ofd.AddExtension = false;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string sfn = ofd.SafeFileName;

                TextBox[] textBox = new TextBox[23]
                {
                   textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9, textBox10,
                textBox11, textBox12, textBox13, textBox14, textBox15, textBox16, textBox17, textBox18, textBox19, textBox20,
                textBox21, textBox22,  textBox23
                };

                textBox[i - 1].Text = Path.GetFileNameWithoutExtension(ofd.FileName);
                textBox[i + 9].Text = ofd.FileName;


                //textBox4.Text = sfn.Substring(0, sfn.Length - 4); // 아래와 같이 확장자명 제거 기능
                //textBox4.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
                //textBox14.Text = ofd.FileName;
            }            
            l = null;
        }

        #endregion CommonOpenFileDialog

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자와 백스페이스를 제외한 나머지를 바로 처리
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자와 백스페이스를 제외한 나머지를 바로 처리
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(textBox14.Text);
        }

        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = ChangeFolderPath();
        }

        private void 저장하기(object sender, FormClosingEventArgs e)
        {
            LogClass l = new LogClass();

            l.Log(Main.main.lboxLog, "저장하기");
            Config.SavaIniFile2();

            l = null;
        }

        private void 다시로드(object sender, FormClosedEventArgs e)
        {
            환경설정4();
            환경설정5();
        }
    }
}
