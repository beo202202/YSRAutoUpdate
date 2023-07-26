using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace YSR
{
    public partial class SetForm : Form
    {
        //private string strLocalFolder = Application.ExecutablePath.Substring(0, Application.ExecutablePath.LastIndexOf('\\'));
        //static 잘 모르겠당.
        static string sPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        string strLocalFolder = System.IO.Path.GetDirectoryName(sPath);
        string strXmlFile = "\\Setting.xml";

        public SetForm()
        {
            InitializeComponent();
        }

        private void SetForm_Load(object sender, EventArgs e)
        {
            LogClass l = new LogClass();

            //값 불러오기
            //값 표현하기
            //XML Read

            //MessageBox.Show("1");
            //파일이 존재 하지 않으면...
            if (!System.IO.File.Exists(strLocalFolder + strXmlFile))
                //MessageBox.Show("없네요.");
                l.Log(Main.main.lboxLog, "저장된 세팅이 없습니다.");
            return;

            /*
            textBox1.Text = "";

            System.Xml.XmlDocument xdDoc = new System.Xml.XmlDocument();
            //XML 파일 로드...
            xdDoc.Load(strLocalFolder + strXmlFile);

            //테스트 노드 의 하위 노드들 읽기...
            foreach (System.Xml.XmlNode xn in xdDoc.ChildNodes)
            {
                textBox1.Text += "RootNode = " + xn.Name + System.Environment.NewLine;
                textBox1.Text += "하위 노드" + System.Environment.NewLine;
                //하위 노드... Root 노드에 대한
                foreach (System.Xml.XmlNode xx in xn)
                {
                    //XMLFileEx
                    //ProgramCheckBox
                    //ProgramRadio
                    if (xx.Name == "XMLFileEx")
                    {
                        textBox1.Text += "RootNode ->" + xx.Name + System.Environment.NewLine;
                        textBox1.Text += "           " + xx.InnerText + System.Environment.NewLine;
                    }
                    else if (xx.Name == "ProgramCheckBox")
                    {
                        textBox1.Text += "RootNode ->" + xx.Name + System.Environment.NewLine;
                        textBox1.Text += "           CheckBox1 = " + xx.Attributes[0].Value.ToString() + System.Environment.NewLine;
                        textBox1.Text += "           CheckBox2 = " + xx.Attributes[1].Value.ToString() + System.Environment.NewLine;
                        textBox1.Text += "           CheckBox3 = " + xx.Attributes[2].Value.ToString() + System.Environment.NewLine;
                    }
                    else
                    {
                        textBox1.Text += "RootNode ->" + xx.Name + System.Environment.NewLine;
                        textBox1.Text += "           Radio1 = " + xx.Attributes[0].Value.ToString() + System.Environment.NewLine;
                        textBox1.Text += "           Radio2 = " + xx.Attributes[1].Value.ToString() + System.Environment.NewLine;
                        textBox1.Text += "           Radio3 = " + xx.Attributes[2].Value.ToString() + System.Environment.NewLine;
                    }

                }
            */

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogClass logclass = new LogClass();

            Button btn = sender as Button;

            logclass.Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");

            //Log(enLogLevel.Info, $"앱플레이어 못 찾았어요" + a + ".");

            //파일이 존재 하면 삭제 하고 다시...
            if (System.IO.File.Exists(strLocalFolder + strXmlFile))
            {
                MessageBox.Show("있네요.");
                System.IO.File.Delete(strLocalFolder + strXmlFile);
            }

            //XML Create
            System.Xml.XmlDocument xdDoc = new System.Xml.XmlDocument();
            System.Xml.XmlNode xnRoot = xdDoc.CreateElement("테스트");

            System.Xml.XmlNode xnTmp = xdDoc.CreateElement("XMLFileEx");
            xnTmp.InnerText = "XML Test";

            //상위 노드에 xnTmp 노드를 추가 테스트 -> XMLFileEx 관계
            xnRoot.AppendChild(xnTmp);

            //라디오 버튼 저장
            System.Xml.XmlNode xnRadio = xdDoc.CreateElement("AppPlayer");
            System.Xml.XmlAttribute xaRadio1 = xdDoc.CreateAttribute("LDPlayer9");
            System.Xml.XmlAttribute xaRadio2 = xdDoc.CreateAttribute("BlueStacks3");

            //xaRadio1.Value = radioButton1.Checked.ToString();
            //xaRadio2.Value = radioButton2.Checked.ToString();

            //XnRadio 노드에 속성 추가
            xnRadio.Attributes.Append(xaRadio1);
            xnRadio.Attributes.Append(xaRadio2);


            //xnRoot.AppendChild(xnCheckBox);
            xnRoot.AppendChild(xnRadio);

            MessageBox.Show(xaRadio1.Value);
            MessageBox.Show(xaRadio2.Value);
            MessageBox.Show(strLocalFolder + strXmlFile);
            //XML 저장
            xdDoc.AppendChild(xnRoot);
            xdDoc.Save(strLocalFolder + strXmlFile);

        }

        public string ChangeFolderPath()
        {
            string FilePath = "";
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            {
                dialog.IsFolderPicker = true;

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    FilePath = dialog.FileName;
                }
            }
            return FilePath;
        }




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

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = ChangeFolderPath();
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            var ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
                textBox4.Text = ofd.FileName;
            
        }




        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(textBox4.Text);
        }
    }
}
