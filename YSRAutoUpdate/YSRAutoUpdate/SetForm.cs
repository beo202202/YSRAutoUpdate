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

            환경설정2();

            //파일이 존재 하지 않으면...
            if (!System.IO.File.Exists(strLocalFolder + strXmlFile))
                //MessageBox.Show("없네요.");
                l.Log(Main.main.lboxLog, "저장된 세팅이 없습니다.");
            return;            
        }

        private void 환경설정2()
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            l.Log(Main.main.lboxLog, "환경설정2를 불러오는 중...");
            Config.LoadIniFile2();
            l.Log(Main.main.lboxLog, "환경설정2를 불러왔습니다.");
            
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
    }
}
