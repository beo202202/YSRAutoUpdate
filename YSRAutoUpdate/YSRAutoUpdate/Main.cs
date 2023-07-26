using MessagePack.Formatters;
using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics; // 외부 프로그램 실행
using System.Drawing;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using YSRAutoUpdate;
//using SetForm;

namespace YSR
{
    public partial class Main : Form
    {
        String AppPlayerName = ""; //저장된 값 불러올까?
        public static Main main;
        
        public Main()
        {       

            InitializeComponent(); // 이것 없이는 안되나봐?            
 
        }


        private void Main_Shown(object sender, EventArgs e)
        {
            main = this;

            LogClass l = new LogClass();

            l.Log(lboxLog, "프로그램을 시작합니다.");
            //Delay(500);
            l.Log(lboxLog, "시작");
            //Delay(100);
            l.Log(lboxLog, "시작");
            //Delay(100);

            이미지받아오기();

            l.Log(lboxLog, "환경설정을 불러 오는 중...");
            환경설정2();
            Config.LoadIniFile();
            환경설정();
            l.Log(lboxLog, "환경설정을 불러 왔습니다.");
            

            comboBox1.Enabled = true;
            comboBox2.Enabled = true;
            comboBox3.Enabled = true;
            comboBox4.Enabled = true;

            l.Log(lboxLog, "준비완료");

            l = null;
        }

        private void 환경설정()
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
            //MessageBox.Show(Convert.ToInt32(comboBox1.SelectedItem).ToString());
            //MessageBox.Show(comboBox2.SelectedItem.ToString());
            //COM_MIN = Convert.ToInt32(comboBox1.SelectedItem);
            COM_MIN = Convert.ToInt32(sTETBLMIN);
            //MessageBox.Show("COM_MIN = " + COM_MIN);
            //COM_MAX = Convert.ToInt32(comboBox2.SelectedItem);
            COM_MAX = Convert.ToInt32(sTETBLMAX);
            //MessageBox.Show("COM_MAX = " + COM_MAX);

            //+(오류) sTETBLSMIN 설정값이 지금 설정보다 높을 경우 값을 초기화 해야한다.

            //MessageBox.Show(sTETBLMAX);
            comboBox1.Items.Clear();
            if (COM_MIN == 0 || COM_MAX == 0 || COM_MIN < Convert.ToInt32(sTETBLSMIN)
                || Convert.ToInt32(sTETBLSMAX) < COM_MAX || COM_MAX < COM_MIN)
            {
                if (COM_MIN == 0)
                {
                    l.Log(lboxLog, "초기화(사유: 최소 현재값이 설정되어 있지 않습니다.)");
                }
                if (COM_MAX == 0)
                {
                    l.Log(lboxLog, "초기화(사유: 최대 현재값이 설정되어 있지 않습니다.)");
                }
                else if (Convert.ToInt32(sTETBLSMAX) < COM_MAX)
                {
                    l.Log(lboxLog, "초기화(사유: 최대 설정값이 최대 현대값보다 작습니다.)");
                }
                else if (COM_MAX < COM_MIN)
                {
                    l.Log(lboxLog, "초기화(사유: 현재 최대값이 현재 최소값보다 작습니다.)");
                }
                else
                {
                    l.Log(lboxLog, "초기화(사유: 최소 현재값이 최소 설정값보다 작습니다.)");
                }
                for (int i = Convert.ToInt32(sTETBLSMIN); i <= Convert.ToInt32(sTETBLSMAX); i++)
                {
                    comboBox1.Items.Add(i);
                }
                comboBox1.SelectedIndex = 0; // 초기화
                l.Log(lboxLog, "최소 TETBL" + comboBox1.SelectedItem + "로 초기화되었습니다.");
                COM_MIN = Convert.ToInt32(comboBox1.SelectedItem);
                Config.SavaIniFile();
            }
            else // 값이 이상이 없다면
            {
                for (int i = Convert.ToInt32(sTETBLSMIN); i <= COM_MAX; i++)
                {
                    comboBox1.Items.Add(i);
                }
                comboBox1.SelectedItem = COM_MIN;
            }

            comboBox2.Items.Clear();
            for (int i = Convert.ToInt32(sTETBLSMIN); i <= Convert.ToInt32(sTETBLSMAX); i++)
            {
                comboBox2.Items.Add(i);
            }
            if (COM_MAX == 0)
            {
                l.Log(lboxLog, "초기화(사유: 최대 현재값이 설정되어 있지 않습니다.)");
                comboBox2.SelectedIndex = 0;
                l.Log(lboxLog, "최대 TETBL" + comboBox2.SelectedItem + "로 초기화되었습니다.");
                COM_MAX = Convert.ToInt32(comboBox2.SelectedItem);
                Config.SavaIniFile();
            }
            else if (Convert.ToInt32(sTETBLSMAX) < COM_MAX)
            {
                l.Log(lboxLog, "초기화(사유: 설정 값이 현재 값 보다 작습니다.)");
                comboBox2.SelectedIndex = 0;
                l.Log(lboxLog, "최대 TETBL" + comboBox2.SelectedItem + "로 초기화되었습니다.");
                COM_MAX = Convert.ToInt32(comboBox2.SelectedItem);
                Config.SavaIniFile();
            }
            else if (COM_MAX < COM_MIN)
            {
                l.Log(lboxLog, "초기화(사유: 현재 최대값이 현재 최소값보다 작습니다.)");
                comboBox2.SelectedIndex = 0;
                l.Log(lboxLog, "최대 TETBL" + comboBox2.SelectedItem + "로 초기화되었습니다.");
                COM_MAX = Convert.ToInt32(comboBox2.SelectedItem);
                Config.SavaIniFile();
            }
            else //평소랑 같다면
            {
                comboBox2.SelectedItem = COM_MAX;
            }

            //MessageBox.Show("COM_MIN = " + COM_MIN);
            //MessageBox.Show("COM_MAX = " + COM_MAX);

            labelMAX = COM_MAX - COM_MIN + 1;
            //MessageBox.Show("labelMAX = " + labelMAX);
            labelProgressBar1.Maximum = labelMAX;

            l = null;
        }

        private void 환경설정2()
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

            
            comboBox3.Items.Clear();
            //comboBox3.Items.Add("아무것도 없습니다.");
            if (sCHECK1 == "True")
            {
                comboBox3.Items.Add(sNAME1);
            }
            if (sCHECK2 == "True")
            {
                comboBox3.Items.Add(sNAME2);
            }
            if (sCHECK3 == "True")
            {
                comboBox3.Items.Add(sNAME3);
            }
            if (sCHECK4 == "True")
            {
                comboBox3.Items.Add(sNAME4);
            }
            if (sCHECK5 == "True")
            {
                comboBox3.Items.Add(sNAME5);
            }
            if (sCHECK6 == "True")
            {
                comboBox3.Items.Add(sNAME6);
            }
            if (sCHECK7 == "True")
            {
                comboBox3.Items.Add(sNAME7);
            }
            if (sCHECK8 == "True")
            {
                comboBox3.Items.Add(sNAME8);
            }
            if (sCHECK9 == "True")
            {
                comboBox3.Items.Add(sNAME9);
            }
            if (sCHECK10 == "True")
            {
                comboBox3.Items.Add(sNAME10);
            }
            

            //comboBox3.SelectedIndex = 0;
            l = null;            
        }

        int labelMAX, COM_MIN, COM_MAX;
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e) // 값을 사용자가 선택할 경우에
        {
            LogClass l = new LogClass();

            l.Log(lboxLog, "최소 TETBL" + comboBox1.SelectedItem + "를 선택하셨습니다.");
            COM_MIN = Convert.ToInt32(comboBox1.SelectedItem);
            //COM_MAX = Convert.ToInt32(comboBox2.SelectedItem);
            //labelMAX = COM_MAX - COM_MIN + 1;
            //labelProgressBar1.Maximum = labelMAX;
            Config.SavaIniFile();          
            환경설정();

            l = null;
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e) // 값을 사용자가 선택할 경우에
        {
            LogClass l = new LogClass();

            l.Log(lboxLog, "최대 TETBL" + comboBox2.SelectedItem + "를 선택하셨습니다.");
            //COM_MIN = Convert.ToInt32(comboBox1.SelectedItem);
            COM_MAX = Convert.ToInt32(comboBox2.SelectedItem);
            //labelMAX = COM_MAX - COM_MIN + 1;
            //labelProgressBar1.Maximum = labelMAX;
            Config.SavaIniFile();            
            환경설정();

            l = null;
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e) // 값을 사용자가 선택할 경우에
        {
            //MessageBox.Show("뭐가 문제냐2");
            Config.SavaIniFile();
        }

        private void comboBox4_SelectionChangeCommitted(object sender, EventArgs e) // 값을 사용자가 선택할 경우에
        {
            Config.SavaIniFile();
        }

        //private void strADD(string str)
        //{
        //    MessageBox.Show(str);
        //    this.Text = str;
        //}

        private void InitProgressBar(LabelProgressBar progressBar, int value)
        {
            SetProgressValue(progressBar, value);
            SetProgressColor(progressBar, value);
        }

        /// <summary>
        /// Set ProgressBar value
        /// </summary>
        /// <param name="value"></param>
        private void SetProgressValue(LabelProgressBar progressBar, int value)
        {
            if (progressBar.InvokeRequired == true)
            {
                progressBar.Invoke(new MethodInvoker(delegate ()
                {
                    progressBar.Value = value;
                }));
            }
            else
            {
                progressBar.Value = value;
            }
        }

        /// <summary>
        /// Set ProgressBar color
        /// </summary>
        /// <param name="value"></param>
        private void SetProgressColor(LabelProgressBar progressBar, int value)
        {
            if (0 <= value && value < 25)
                progressBar.ProgressColor = Color.FromArgb(116, 182, 102);

            else if (25 <= value && value < 50)
                progressBar.ProgressColor = Color.FromArgb(118, 190, 219);

            else if (50 <= value && value < 75)
                progressBar.ProgressColor = Color.FromArgb(230, 176, 95);

            else
                progressBar.ProgressColor = Color.FromArgb(201, 92, 84);
        }

        private void 이미지받아오기()
        {
            LogClass l = new LogClass();
            try
            {
                // 이미지 선언
                Bitmap bp0 = new Bitmap(@"img\의사랑 업데이트\예(Y)_질문1.PNG", true);
                Bitmap bp1 = new Bitmap(@"img\의사랑 업데이트\확인(O)_정보.PNG", true);
                Bitmap bp2 = new Bitmap(@"img\의사랑 업데이트\확인_안내.PNG", true);
                Bitmap bp3 = new Bitmap(@"img\의사랑 업데이트\다시 한 번 실행하시겠습니까_질문.PNG", true);
                Bitmap bp4 = new Bitmap(@"img\의사랑 업데이트\아니오_질문.PNG", true);

                bitMapList.Add(bp0);
                bitMapList.Add(bp1);
                bitMapList.Add(bp2);
                bitMapList.Add(bp3);
                bitMapList.Add(bp4);

                l.Log(lboxLog, "이미지 불러오기 완료");
            }
            catch
            {
                l.Log(lboxLog, "이미지 파일이 없습니다.");
            }
        }

        // 라벨 프로그레스바로 바꾸고, 함수로 바꾸고 색깔도 변하게 하고 
        //prviate void SetProgressBar()

        public void 의사랑자동업데이트()
        {
            InitProgressBar(labelProgressBar1, 0);
            //Delay(1000);
            InitProgressBar(labelProgressBar2, 0);

            this.textBox1.BackColor = Color.FromArgb(192, 0, 0);
            this.textBox1.ForeColor = Color.White;
            //로그 클래스 개체 선언
            LogClass l = new LogClass();
            int A = COM_MIN; // 시작 값
            int B = COM_MAX; // 마지막 값
            int i = 0;
            int j = 0;
            int k = 0;
            int m = 0;
            string clinic, address, exe_name, exe_name2; //b;
            clinic = "";
            exe_name = "";
            exe_name2 = "";

            Thread thread2 = new Thread(() => 자동모드진행중());

            의사랑핸들("YSR2000 - SQL Anywhere 네트워크 서버", 1); // DB 종료
            l.Log(lboxLog, "DB 확인 중");
            Delay(500);

            if (this.comboBox3.InvokeRequired == true)
            {
                this.textBox1.Invoke((MethodInvoker)delegate
                {
                    clinic = comboBox3.SelectedItem.ToString();
                });
            }

            if (clinic == "") 
            {
                // 빈값 = 오류;
                if (thread2.ThreadState.ToString() != "Unstarted")
                {
                    thread2.Abort();
                    if (this.textBox1.InvokeRequired == true)
                    {
                        this.textBox1.Invoke((MethodInvoker)delegate
                        {
                            this.textBox1.BackColor = Color.Yellow;
                            this.textBox1.ForeColor = Color.Black;
                            this.textBox1.Text = "DB와 연결이 되어 있지 않습니다".PadLeft(57);
                        });
                    }
                }
                InitProgressBar(labelProgressBar1, labelMAX);
                InitProgressBar(labelProgressBar2, 100);
                A = 99999999; // While 값에 안들어가게 하기
            } 
            else 
            {
                address = "C:\\Users\\소유자\\Desktop\\";
                //exe_name = "서울안과";
                exe_name2 = ".lnk";

                // 실행파일 실행
                Process.Start(address + clinic + exe_name2);
                l.Log(lboxLog, clinic + "DB 실행");

                if (this.textBox1.InvokeRequired == true)
                {
                    this.textBox1.Invoke((MethodInvoker)delegate
                    {
                        this.textBox1.BackColor = Color.Yellow;
                        this.textBox1.ForeColor = Color.Black;
                        while (j == 0)
                        {
                            this.textBox1.Text = clinic.PadLeft(56) + "DB 실행 중.";
                            Delay(200);
                            this.textBox1.Text = clinic.PadLeft(56) + "DB 실행 중..";
                            Delay(200);
                            this.textBox1.Text = clinic.PadLeft(56) + "DB 실행 중...";
                            Delay(200);
                            j = IsWindowEnabled(FindWindow(null, "YSR2000 - SQL Anywhere 네트워크 서버"));
                        }
                        this.textBox1.Text = clinic.PadLeft(45) + "DB와 연결이 되었습니다.";
                        l.Log(lboxLog, clinic + "DB와 연결이 되었습니다.");
                        //Delay(1000);
                    });
                }
                Delay(2000);

                // DB 비활성화 및 최소화 할 때까지 기다리기
            }
            thread2.Start();

            while (A < B+1)
            {
                //if (thread2.ThreadState.ToString() == "Suspended")

                this.textBox1.BackColor = Color.FromArgb(192, 0, 0);
                this.textBox1.ForeColor = Color.White;
                //thread2.Resume();

                //l.Log(lboxLog, thread2.ThreadState.ToString());

                // 계속 실행
                // 실행파일 경로와 이름
                //exe_name = Application.StartupPath + "\\process.exe";
                exe_name = "D:\\의사랑 업데이트\\";
                exe_name2 = "TETBL";

                // 실행파일 실행
                //Process.Start(exe_name);
                l.Log(lboxLog, exe_name2 + A + $" 실행");

                //프로세스 생성
                Process p = new Process();

                p.StartInfo.FileName = exe_name+exe_name2+A+".exe";

                // 기본과 최소화 로 구분
                if (this.textBox1.InvokeRequired == true)
                {
                    this.comboBox4.Invoke((MethodInvoker)delegate
                    {
                        if(this.comboBox4.SelectedItem.ToString() == "최소화")
                        {
                            p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized; // 최소화로 실행
                        }                        
                    });
                }        
                                                                        
                p.Start();

                // 의사랑핸들("TfmMain", "") [의사랑2012] 업데이트 창이 뜨거나 질문창이 뜨거나 정보창이 뜰때까지 while
                //l.Log(lboxLog, "창 찾는 중...1");
                InitProgressBar(labelProgressBar2, 30);

                i = 0;
                while (i == 0)
                {
                    //자동모드진행중();
                    i = 의사랑핸들(null, 0);                    
                    Delay(100);
                }

                InitProgressBar(labelProgressBar2, 50);
                //l.Log(lboxLog, "창 찾는 중...2");
                i = 0;
                while (i == 0 && m == 0)
                {
                    //자동모드진행중();
                    i += 의사랑핸들("[안내] 아래 내용을 반드시 확인해 주시기  바랍니다.", 1);
                    Delay(100);                    
                    m = 의사랑핸들("오류", 1);
                    Delay(100);
                    i += 의사랑핸들("질문", 0);
                    Delay(100);
                    if (i > 0 || m == 1)
                    {
                        Delay(100);
                        break;
                    }
                    Delay(100);
                }

                InitProgressBar(labelProgressBar2, 70);
                j = searchIMG(3, "이미지찾기"); //다시 한 번 실행하시겠습니까? (질문창)                 // b를 지우고 핸들을 아예 넣어버릴까?

                if (m == 1 && j == 0)
                {
                    if (thread2.ThreadState.ToString() != "Unstarted")
                    {
                        thread2.Abort();
                        if (this.textBox1.InvokeRequired == true)
                        {
                            this.textBox1.Invoke((MethodInvoker)delegate
                            {
                                this.textBox1.BackColor = Color.Yellow;
                                this.textBox1.ForeColor = Color.Black;
                                this.textBox1.Text = "데이터베이스와 연결이 되어 있지 않습니다".PadLeft(57);
                            });
                        }
                    }
                    InitProgressBar(labelProgressBar1, labelMAX);
                    InitProgressBar(labelProgressBar2, 100);
                    A = 99999999; // while값 벗어나기
                }                
                else if (m == 0 && j == 1)
                {
                    InitProgressBar(labelProgressBar2, 100);
                    l.Log(lboxLog, "이미 업데이트 되었음.");
                    의사랑핸들("질문", 2); // "아니오" 버튼 클릭                    
                    Delay(100);                    
                }
                else if (m== 0 && j ==0)
                {
                    InitProgressBar(labelProgressBar2, 80);
                
                    l.Log(lboxLog, "업데이트 중...");
                    // 4개 창 모두 없을 때 반복문 나온다.
                    i = 0;
                    while (
                        (FindWindow("TfmMain", null) != null)
                        || (FindWindow(null, "질문") != null)
                        || (FindWindow("TMessageForm", "정보") != null))
                    {
                        //자동모드진행중();
                        i = 0;
                        i += 의사랑핸들("질문", 1);
                        i += 의사랑핸들("정보", 1);
                        i += 의사랑핸들(null, 0);
                        if (i == 0)
                        {
                            l.Log(lboxLog, "업데이트 완료");
                            break;
                        }
                        Delay(100);
                    }
                }
                A++;
                k++;
                InitProgressBar(labelProgressBar1, k);
                InitProgressBar(labelProgressBar2, 100);           
            
                //l.Log(lboxLog, "pass");                
            }
            InitProgressBar(labelProgressBar1, labelMAX);
            l.Log(lboxLog, "종료");
            Delay(500);
            l.Log(lboxLog, "종료");
            Delay(500);
            l.Log(lboxLog, "종료");
            Delay(500);
            l.Log(lboxLog, "종료");
            Delay(500);
            l.Log(lboxLog, "종료");
            Delay(500);
            if (thread2.ThreadState.ToString() != "Unstarted")
            {
                thread2.Abort();
                if (this.textBox1.InvokeRequired == true)
                {
                    this.textBox1.Invoke((MethodInvoker)delegate
                    {
                        this.textBox1.BackColor = Color.Yellow;
                        this.textBox1.ForeColor = Color.Black;
                        this.textBox1.Text = "자동모드 종료".PadLeft(66);
                    });
                }
            }
            //종료

            //핸들이 없으면 값이 null
        }

        //x,y 값을 전달해주면 왼쪽클릭이벤트를 발생합니다.
        public void InClick(int x, int y)
        {
            LogClass l = new LogClass();

            //클릭이벤트를 발생시킬 플레이어를 찾습니다.
            IntPtr findwindow = FindWindow(null, AppPlayerName);
            if (findwindow != IntPtr.Zero)
            {
                //textBox1.AppendText("클릭 x= " + x + "y= " + y + "\r\n");
                l.Log(lboxLog, "클릭 x= " + x + "y= " + y);
                SetCursorPos(x, y);

                Delay(100);
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                Delay(100);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                Delay(50);

                //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
                //IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, "RenderWindow", "TheRender");
                //IntPtr lparam = new IntPtr(x | (y << 16));

                //플레이어 핸들에 클릭 이벤트를 전달합니다.
                //SendMessage(hwnd_child, WM_LBUTTONDOWN, 1, lparam);
                //SendMessage(hwnd_child, WM_LBUTTONUP, 0, lparam);
            }
            l = null;
        }

        //비트맵 배열 선언
        List<Bitmap> bitMapList = new List<Bitmap>();

        private static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;        
        private const UInt32 SWP_NOACTIVATE = 0x0010;
        private const UInt32 HIDEWINDOW = 0x0080;
        private const UInt32 SHOWWINDOW = 0x0040;
        private const UInt32 SWP_NOOWNERZORDER = 0x0200; // Z 순서에서 소유자 창의 위치를 변경하지 않습니다.
        private const UInt32 SWP_NOZORDER = 0x0004; // 현재 Z 순서를 유지합니다. ( hWndlnsertAfter 매개변수 무시)

        private const UInt32 WINDOW_FLAGS = SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_NOOWNERZORDER;
        private const UInt32 WINDOW_FLAGS2 = SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER;

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32")]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle); // 프로세스를 윈도우 최상위 화면으로 활성화?

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;

        [DllImport("user32")]
        public static extern Int32 SetCursorPos(Int32 x, Int32 y);

        [DllImport("user32.dll")]
        static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint dwData, int dwExtraInfo);

        private const uint MOUSEEVENTF_LEFTDOWN = 0x0002;      // The left button is down.
        private const uint MOUSEEVENTF_LEFTUP = 0x0004;        // The left button is up.

        private const uint MOUSEEVENTF_RIGHTDOWN = 0x0008;      // The left button is down.
        private const uint MOUSEEVENTF_RIGHTUP = 0x0010;        // The left button is up.

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);
        const int WM_LBUTTONDOWN = 0x0201; // 마우스 다운
        const int WM_LBUTTONUP = 0x0202; //마우스 업
        const int BM_CLICK = 0x00F5; // 버튼 클릭        

        [DllImport("user32")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsIconic(IntPtr windowHandle);

        [DllImport("user32.dll")]
        private static extern int IsWindowEnabled(IntPtr hwnd);


        public enum WMessages : int
        {
            WM_CHAR = 0x102     //char
        }

        

        //internal 안에서만 됨.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        internal static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }

        public object ListBox { get; internal set; }

        //x,y 값을 전달해주면 지정된 핸들에 마우스 클릭 이벤트를 발생합니다.
        private void 마우스클릭(int x, int y) // *마우스클릭
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            //클릭이벤트를 발생시킬 플레이어를 찾습니다.
            IntPtr findwindow = FindWindow(null, AppPlayerName);
            l.Log(lboxLog, AppPlayerName + "!!!!!!!!!!!!!!!!!!!!");
            if (findwindow != IntPtr.Zero)
            {
                if (AppPlayerName == "LDPlayer")
                {
                    //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
                    //IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, "Qt5QWindowIcon", "ScreenBoardClassWindow");
                    IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, null, "TheRender");

                    //y = y - 32; //녹스 플레이어는 상단바의 길이를 빼줘야 한다.
                    IntPtr lparam = new IntPtr(x | (y << 0));

                    //플레이어 핸들에 클릭 이벤트를 전달합니다.
                    SendMessage(hwnd_child, WM_LBUTTONDOWN, 1, lparam);
                    SendMessage(hwnd_child, WM_LBUTTONUP, 0, lparam);
                    //Delay(100);

                    //textBox1.AppendText("클릭" + "X= " + x + "  Y = " + y + "\r\n");

                }
                else if (AppPlayerName == "BlueStacks") //블루스택1인가 3인가
                {
                    //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
                    //IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, "Qt5QWindowIcon", "ScreenBoardClassWindow");
                    IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, null, "BlueStacks Android PluginAndroid");

                    //x = x - 7;
                    //y = y - 46; //BlueStacks은 상단바의 길이를 빼줘야 한다.
                    IntPtr lparam = new IntPtr(x | (y << 0));

                    //플레이어 핸들에 클릭 이벤트를 전달합니다.
                    SendMessage(hwnd_child, WM_LBUTTONDOWN, 1, lparam);
                    SendMessage(hwnd_child, WM_LBUTTONUP, 0, lparam);

                    //textBox1.AppendText("클릭" + "X= " + x + "  Y = " + y + "\r\n");
                }
                else if (AppPlayerName == "질문")
                {
                    findwindow = FindWindow("TMessageForm", AppPlayerName);
                    //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
                    //IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, "Qt5QWindowIcon", "ScreenBoardClassWindow");
                    IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, "TButton", "예(&Y)");

                    //x = x - 7;
                    //y = y - 30; // 상단바의 길이를 빼줘야 한다.
                    IntPtr lparam = new IntPtr(x | (y << 0));

                    l.Log(lboxLog, "입력이 되나.");

                    //플레이어 핸들에 클릭 이벤트를 전달합니다.
                    SendMessage(hwnd_child, WM_LBUTTONDOWN, 1, lparam);
                    SendMessage(hwnd_child, WM_LBUTTONUP, 0, lparam);

                    //textBox1.AppendText("클릭" + "X= " + x + "  Y = " + y + "\r\n");
                }
                else if (AppPlayerName == "정보")
                {
                    findwindow = FindWindow("TMessageForm", AppPlayerName);
                    //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
                    IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, "TButton", "확인(&O)");

                    IntPtr lparam = new IntPtr(x | (y << 0));

                    l.Log(lboxLog, "입력이 되나.");

                    //플레이어 핸들에 클릭 이벤트를 전달합니다.
                    SendMessage(hwnd_child, WM_LBUTTONDOWN, 1, lparam);
                    SendMessage(hwnd_child, WM_LBUTTONUP, 0, lparam);

                    //textBox1.AppendText("클릭" + "X= " + x + "  Y = " + y + "\r\n");
                }
            }
            l = null;
        }

        //서치이미지에 특정 좌표 사이만 찾는 기능을 넣기
        //searchIMG에 스크린 이미지와 찾을 이미지 번호를 넣어줍니다.
        public int searchIMG(int a, String b) //find_img 를 숫자만 받아서..어찌고 저쩌고...
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            //l.Log(lboxLog, "AppPlayerName :" + AppPlayerName);

            int i = 0;
            try
            {
                IntPtr findwindow = FindWindow(null, AppPlayerName);
                if (AppPlayerName != "" && findwindow != IntPtr.Zero)
                {

                    //앱플레이어를 찾았을 경우
                    //l.Log(lboxLog, "앱플레이어 찾았습니다.");

                    //찾은 플레이어를 바탕으로 Graphics 정보를 가져옵니다.
                    Graphics Graphicsdata = Graphics.FromHwnd(findwindow);

                    //찾은 플레이어 창 크기 및 위치를 가져옵니다. 
                    Rectangle rect = Rectangle.Round(Graphicsdata.VisibleClipBounds);

                    //플레이어 창 크기 만큼의 비트맵을 선언해줍니다.
                    Bitmap bmp = new Bitmap(rect.Width, rect.Height);

                    int nFlags = 0; //초기화

                    OperatingSystem os = Environment.OSVersion; //시스템 os
                    Version v = os.Version; //os 몇 인지
                    if (v.Major == 10) //os는 10이다
                    {
                        nFlags = 0x2;
                    }
                    else //os 10 미만이다
                    {
                        nFlags = 0x0;
                    }
                    //비트맵을 바탕으로 그래픽스 함수로 선언해줍니다.
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        //찾은 플레이어의 크기만큼 화면을 캡쳐합니다.
                        IntPtr hdc = g.GetHdc();
                        PrintWindow(findwindow, hdc, nFlags);
                        g.ReleaseHdc(hdc);
                    }


                    // pictureBox1 이미지를 표시해줍니다.
                    //pictureBox1.Image = bmp;
                    //pictureBox3.Image = bitMapList[a];


                    //스크린 이미지 선언
                    using (Mat ScreenMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp))
                    //찾을 이미지 선언
                    using (Mat FindMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitMapList[a]))
                    //스크린 이미지에서 FindMat 이미지를 찾아라
                    using (Mat res = ScreenMat.MatchTemplate(FindMat, TemplateMatchModes.CCoeffNormed))
                    // 32비트로 해야하는데 24비트인지 확인해야함
                    {
                        //찾은 이미지의 유사도를 담을 더블형 최대 최소 값을 선언합니다.
                        double minval, maxval = 0;
                        //찾은 이미지의 위치를 담을 포인트형을 선업합니다.
                        OpenCvSharp.Point minloc, maxloc;
                        //찾은 이미지의 유사도 및 위치 값을 받습니다. 
                        Cv2.MinMaxLoc(res, out minval, out maxval, out minloc, out maxloc);
                        //textBox1.AppendText("찾은 이미지의 유사도 : " + maxval + "\r\n");

                        maxval = Math.Truncate(maxval * 100) / 100;
                        Math.Truncate(maxval);
                        maxval *= 100;

                        //이미지를 찾았을 경우 표시만!!
                        if (maxval >= 80)
                        {
                            //l.Log(lboxLog, $"C" + "[ " + maxval + "%]" + b);
                            i = 1;
                        }
                        else
                        {
                            //l.Log(lboxLog, $"F " + "[ " + maxval + "%]" + b);
                            i = 0;
                        }
                    }
                }

                else
                {
                    //플레이어를 못찾을경우
                    //l.Log(lboxLog, $"앱플레이어 못 찾았어요" + a + ".");
                    i = 0;
                }
            }
            catch (OpenCvSharp.OpenCVException)
            {
                l.Log(lboxLog, $"searchIMG\\찾기오류\\32비트,24비트PNG추정");
            }
            catch (Exception e)
            {
                l.Log(lboxLog, e.ToString());
            }
            return i;
        }

        public System.Threading.Timer myTimer;
        //스레드 타이머 시작
        public void fn_start(TimerCallback callback, int starttime, int sendtime)
        {
            myTimer = new System.Threading.Timer(callback, null, starttime, sendtime);
        }
        //스레드 타이머 종료
        public void fn_stop()
        {
            myTimer.Dispose();
        }

        //string TState1;
        //string TState2;

        #region Button Click
        private void button1_Click(object sender, EventArgs e)
        {
            LogClass l = new LogClass();

            l.Log(lboxLog, $"저장");
            Config.SavaIniFile();
            
            l.Log(lboxLog, $"종료");
            l = null;
            Application.Exit();            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogClass l = new LogClass();

            l.Log(lboxLog, $"최소화");
            this.WindowState = FormWindowState.Minimized;

            l = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 설정 창 올리기
            //SetForm frm = new SetForm();

            //frm.StartPosition = FormStartPosition.CenterScreen;
            //frm.ShowDialog();

            using (SetForm frm = new SetForm())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // update datagrid
                    //...
                }
            }
        }

        // 의사랑 자동 업데이트
        public void button9_Click(object sender, EventArgs e)
        {
            LogClass l = new LogClass();
            Button btn = sender as Button;
            l.Log(lboxLog, $"{btn.Text} 버튼 Click");

            Thread thread1 = new Thread(() => 의사랑자동업데이트());

            //thread2.IsBackground = true;
            //Config.LoadIniFile(); // 해당 경로에 INI 파일 생성
            //Config.SavaIniFile(); //Config.ini 파일 경로에 저장

            if (radioButton1.Checked) // 자동 업데이트
            {
                thread1.Start();
            }
            else if (radioButton2.Checked) //테스트
            {

            }
            else if (radioButton3.Checked) //테스트2
            {
               // 의사랑핸들("YSR2000 - SQL Anywhere 네트워크 서버", 1); // DB 종료
               // //Delay(500);
               // // 체크박스 값을 확인하는 법
               // String exe_name = "C:\\Users\\소유자\\Desktop\\서울안과.lnk";

               // //프로세스 생성
               // Process p = new Process();

               // p.StartInfo.FileName = exe_name;
               // // p.WaitForExit(); // 외부 프로세스 실행하면 C# 일시중지

               // //p.StartInfo.UseShellExecute = false;

               // //// 데이터 넣기
               // //p.StartInfo.RedirectStandardInput = true;
               // //// 데이터 받기
               // //p.StartInfo.RedirectStandardOutput = false;
               // ////p.Arguments =;
               // //p.StartInfo.RedirectStandardError = true;

               // //p.StartInfo.CreateNoWindow = true; // < 윈도우 생성 안하기

               //// MessageBox.Show(p.StartInfo.WindowStyle.ToString());

               // //p.StartInfo.WindowStyle = ProcessWindowStyle.Minimized; //실행 됨.

               //// MessageBox.Show(p.StartInfo.WindowStyle.ToString());
               // p.Start();

               // // 실행파일 실행
               // //Process.Start(startInfo);
               // //Process.Start(exe_name);
               // l.Log(lboxLog, exe_name + $" 실행");
            }
        }

        #endregion Button Click

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            button2.BackColor = Color.Black;
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(64, 64, 64);
        }
        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            button1.BackColor = Color.Red;
        }
        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(64, 64, 64);
        }

        public
        int indexNumber;

        //int 점점점갯수;
        string 자동모드_점점점 = "ㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇ";

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            LogClass l = new LogClass();
            //Config.SavaIniFile();
            this.Opacity = trackBar1.Value * 0.01;
            l.Log(lboxLog, "투명도 : " + trackBar1.Value + "%");

            l = null;
        }

        private void tableLayoutPanel2_MouseDown(object sender, MouseEventArgs e)
        {
            // 마우스 다운 시 창을 움직이게
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, IntPtr.Zero);
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            // 마우스 다운 시 창을 움직이게
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, IntPtr.Zero);
        }

        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            // 마우스 다운 시 창을 움직이게
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, IntPtr.Zero);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                LogClass l = new LogClass();

                l.Log(lboxLog, $"윈도우 최상위로");
                checkBox1.BackgroundImage = YSRAutoUpdate.Properties.Resources.pin2;
                // 최상위로 설정
                SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, WINDOW_FLAGS);
            }
            else
            {
                LogClass l = new LogClass();

                l.Log(lboxLog, $"윈도우 최상위 취소");
                checkBox1.BackgroundImage = YSRAutoUpdate.Properties.Resources.pin;
                // 두번째 상위로 설정
                SetWindowPos(this.Handle, HWND_NOTOPMOST, 0, 0, 0, 0, WINDOW_FLAGS);
            }
        }

        private void comboBox1_MouseMove(object sender, MouseEventArgs e)
        {
            환경설정();
        }

        private void comboBox2_MouseMove(object sender, MouseEventArgs e)
        {
            환경설정();
        }

        public void 자동모드진행중()
        {
            // 위의 변수를 모두 전역변수로 설정하고 아래 문자열을 timer에 넣어서 indexNumber++
            while (true)
            {
                int 점점점갯수 = Math.Abs(자동모드_점점점.Length - (indexNumber % ((자동모드_점점점.Length) * 2)));
                int 위치 = 21 + Math.Abs(자동모드_점점점.Length - (indexNumber % ((자동모드_점점점.Length) * 2)));

                // Invoke를 통해 해당 Object에 대한 접근 권한을 얻기
                // textBox1 객체에 접근하기 위해 Invoke 가 요구된다면
                if (this.textBox1.InvokeRequired == true)
                {
                    this.textBox1.Invoke((MethodInvoker)delegate
                    {
                        this.textBox1.Text = string.Format("자동모드 진행 중 [ {0,9} ] {1,20}",
                    indexNumber.ToString().PadLeft(9, '0'), 자동모드_점점점.Substring(점점점갯수).PadLeft(위치, ' '));
                    });
                }
                else
                {
                    this.textBox1.Text = string.Format("자동모드 진행 중 [ {0,9} ] {1,26}",
                    indexNumber.ToString().PadLeft(9, '0'), 자동모드_점점점.Substring(점점점갯수).PadLeft(위치, ' '));
                }
                indexNumber++;
                //Delay(100);
                Thread.Sleep(100);
            }
        }

        #region handle
        public int 의사랑핸들(string APN, int i) // *의사랑핸들
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();
            int j = 0;

            IntPtr hd, hd1, hd2, hd3;
            switch (APN)
            {
                case "YSR2000 - SQL Anywhere 네트워크 서버":
                    AppPlayerName = "YSR2000 - SQL Anywhere 네트워크 서버";
                    hd = FindWindow(null, AppPlayerName); //"TMessageTagForm" or "TMessageForm"
                    //SetWindowPos(hd, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd1 = FindWindowEx(hd, IntPtr.Zero, null, "");
                    //SetWindowPos(hd1, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd2 = FindWindowEx(hd1, IntPtr.Zero, "Button", "종료(&H)");
                    //SetWindowPos(hd2, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);

                    if (hd != IntPtr.Zero)
                    {
                        //l.Log(lboxLog, $" 창 찾음.");
                        int x = 0;
                        int y = 0;

                        //l.Log(lboxLog, $"부모:    " + hd.ToString());
                        //l.Log(lboxLog, $"자식1:    " + hd1.ToString());
                        //l.Log(lboxLog, $"자식2:    " + hd2.ToString());

                        IntPtr lparam = new IntPtr(x | (y << 0));
                        switch (i)
                        {
                            case 0:
                                //l.Log(lboxLog, $"버튼 클릭 안함.");
                                break;
                            case 1:
                                SendMessage(hd2, BM_CLICK, 0, lparam); // 확인
                                //l.Log(lboxLog, $"버튼 클릭.");
                                break;
                            default:
                                l.Log(lboxLog, $"의사랑핸들\\네트워크 서버\\오류\\클릭값");
                                break;
                        }
                        j = 1;
                    }
                    else
                    {
                        //못 찾은 경우
                        //l.Log(lboxLog, $"질문 창을 못 찼았어요.");
                        j = 0;
                    }
                    break;

                case "오류":
                    AppPlayerName = "오류";
                    hd = FindWindow("TMessageForm", AppPlayerName); //"TMessageTagForm" or "TMessageForm"
                    //SetWindowPos(hd, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd1 = FindWindowEx(hd, IntPtr.Zero, "TButton", "확인(&O)");
                    //SetWindowPos(hd1, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    //hd2 = FindWindowEx(hd, IntPtr.Zero, "TButton", "아니오(&N)");
                    //SetWindowPos(hd2, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);

                    if (hd != IntPtr.Zero)
                    {
                        //l.Log(lboxLog, $"질문 창 찾음.");
                        int x = 0;
                        int y = 0;

                        //l.Log(lboxLog, $"부모:    " + hd.ToString());
                        //l.Log(lboxLog, $"자식1:    " + hd1.ToString());
                        //l.Log(lboxLog, $"자식2:    " + hd1.ToString());

                        IntPtr lparam = new IntPtr(x | (y << 0));
                        switch (i)
                        {
                            case 0:
                                //l.Log(lboxLog, $"버튼 클릭 안함.");
                                break;
                            case 1:
                                SendMessage(hd1, BM_CLICK, 0, lparam); // 확인
                                //l.Log(lboxLog, $"(예) 버튼 클릭");
                                //Delay(1000);
                                break;
                            default:
                                l.Log(lboxLog, $"의사랑핸들\\오류\\오류\\클릭값");
                                break;
                        }
                        j = 1;
                    }
                    else
                    {
                        //못 찾은 경우
                        //l.Log(lboxLog, $"질문 창을 못 찼았어요.");
                        j = 0;
                    }
                    break;

                case null:
                    // 의사랑 2012 업데이트 창이 있는가
                    AppPlayerName = null;
                    hd = FindWindow("TfmMain", AppPlayerName); //""보다 null로 해야 찾을 수 있다.
                    SetWindowPos(hd, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS | HIDEWINDOW);
                    //IntPtr hd1 = FindWindowEx(hd, IntPtr.Zero, "TPanel", "PanClient");
                    //IntPtr hd2 = FindWindowEx(hd1, IntPtr.Zero, "TPanel", "");
                    //IntPtr hd3 = FindWindowEx(hd2, IntPtr.Zero, "TButton", "확인");

                    if (hd != IntPtr.Zero)
                    {
                        //l.Log(lboxLog, $"의사랑 2012 업데이트 창 찾음.");
                        //l.Log(lboxLog, $"부모:    " + hd.ToString());
                        j = 1;
                    }
                    else
                    {
                        //못 찾은 경우
                        //l.Log(lboxLog, $"의사랑 2012 업데이트 창을 못 찼았어요.");
                        j = 0;
                    }
                    break;

                case "질문":
                    AppPlayerName = "질문";
                    hd = FindWindow(null, AppPlayerName); //"TMessageTagForm" or "TMessageForm"
                    SetWindowPos(hd, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd1 = FindWindowEx(hd, IntPtr.Zero, "TButton", "예(&Y)");
                    SetWindowPos(hd1, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd2 = FindWindowEx(hd, IntPtr.Zero, "TButton", "아니오(&N)");
                    SetWindowPos(hd2, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);

                    if (hd != IntPtr.Zero)
                    {
                        //l.Log(lboxLog, $"질문 창 찾음.");
                        int x = 0;
                        int y = 0;

                        //l.Log(lboxLog, $"부모:    " + hd.ToString());
                        //l.Log(lboxLog, $"자식1:    " + hd1.ToString());
                        //l.Log(lboxLog, $"자식2:    " + hd1.ToString());

                        IntPtr lparam = new IntPtr(x | (y << 0));
                        switch (i)
                        {
                            case 0:
                                //l.Log(lboxLog, $"버튼 클릭 안함.");
                                break;
                            case 1:
                                SendMessage(hd1, BM_CLICK, 0, lparam); // 예
                                //l.Log(lboxLog, $"(예) 버튼 클릭");
                                //Delay(1000);
                                break;
                            case 2:
                                SendMessage(hd2, BM_CLICK, 0, lparam); // 아니오
                                //l.Log(lboxLog, $"(아니오) 버튼 클릭");
                                //Delay(1000);
                                break;
                            default:
                                l.Log(lboxLog, $"의사랑핸들\\질문\\오류\\클릭값");
                                break;
                        }
                        j = 1;
                    }
                    else
                    {
                        //못 찾은 경우
                        //l.Log(lboxLog, $"질문 창을 못 찼았어요.");
                        j = 0;
                    }
                    break;

                case "정보":
                    AppPlayerName = "정보";
                    hd = FindWindow("TMessageForm", AppPlayerName);
                    SetWindowPos(hd, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd1 = FindWindowEx(hd, IntPtr.Zero, "TButton", "확인(&O)");
                    SetWindowPos(hd1, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);

                    if (hd != IntPtr.Zero)
                    {
                        //l.Log(lboxLog, $"정보 창 찾음.");
                        int x = 0;
                        int y = 0;

                        //l.Log(lboxLog, $"부모:    " + hd.ToString());
                        //l.Log(lboxLog, $"자식1:    " + hd1.ToString());

                        if (i == 1)
                        {
                            //l.Log(lboxLog, $"(확인) 버튼 클릭1");
                            IntPtr lparam = new IntPtr(x | (y << 16));
                            SendMessage(hd1, BM_CLICK, 0, lparam);
                            //l.Log(lboxLog, $"(확인) 버튼 클릭");
                            //Delay(1000);
                        }
                        j = 1;
                    }
                    else
                    {
                        //못 찾은 경우
                        //l.Log(lboxLog, $"정보 창을 못 찼았어요.");
                        j = 0;
                    }
                    break;

                case "[안내] 아래 내용을 반드시 확인해 주시기  바랍니다.":
                    AppPlayerName = "[안내] 아래 내용을 반드시 확인해 주시기  바랍니다.";
                    hd = FindWindow(null, AppPlayerName); // TfmMainMsg
                    SetWindowPos(hd, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd1 = FindWindowEx(hd, IntPtr.Zero, "TPanel", "PanClient");
                    SetWindowPos(hd1, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd2 = FindWindowEx(hd1, IntPtr.Zero, "TPanel", "");
                    SetWindowPos(hd2, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd3 = FindWindowEx(hd2, IntPtr.Zero, "TButton", "확인");
                    SetWindowPos(hd3, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);

                    if (hd != IntPtr.Zero)
                    {
                        //l.Log(lboxLog, $"[안내] 창 찾음.");
                        int x = 0;
                        int y = 0;

                        //l.Log(lboxLog, $"부모:    " + hd.ToString());
                        //l.Log(lboxLog, $"자식1:    " + hd1.ToString());
                        //l.Log(lboxLog, $"자식2:    " + hd2.ToString());
                        //l.Log(lboxLog, $"자식3:    " + hd3.ToString());

                        if (i == 1)
                        {
                            IntPtr lparam = new IntPtr(x | (y << 0));
                            SendMessage(hd3, BM_CLICK, 0, lparam);
                            //l.Log(lboxLog, $"(확인) 버튼 클릭.");
                            //Delay(1000);
                        }
                        j = 1;
                    }
                    else
                    {
                        //못 찾은 경우
                        //l.Log(lboxLog, $"[안내] 창을 못 찼았어요.");
                        j = 0;
                    }
                    break;

                case "업데이트 정보":
                    AppPlayerName = "업데이트 정보"; //앱플레이어: 의사랑_업데이트 정보
                    hd = FindWindow("TUpdateToolHistory", AppPlayerName);
                    SetWindowPos(hd, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd1 = FindWindowEx(hd, IntPtr.Zero, "TPanel", "");
                    SetWindowPos(hd1, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd2 = FindWindowEx(hd1, IntPtr.Zero, "TPanel", "");
                    SetWindowPos(hd2, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);
                    hd3 = FindWindowEx(hd2, IntPtr.Zero, "TButton", "전체실행");
                    SetWindowPos(hd3, HWND_BOTTOM, 0, 0, 0, 0, WINDOW_FLAGS);

                    if (hd != IntPtr.Zero)
                    {
                        //l.Log(lboxLog, $"업데이트 정보 창 찾음.");
                        int x = 0;
                        int y = 0;

                        //l.Log(lboxLog, $"부모:    " + hd.ToString());
                        //l.Log(lboxLog, $"자식1:    " + hd1.ToString());
                        //l.Log(lboxLog, $"자식2:    " + hd2.ToString());
                        //l.Log(lboxLog, $"자식3:    " + hd3.ToString());

                        if (i == 1)
                        {
                            IntPtr lparam = new IntPtr(x | (y << 0));
                            SendMessage(hd3, BM_CLICK, 0, lparam);
                            //l.Log(lboxLog, $"(전체실행) 버튼 클릭.");
                            //Delay(1000);
                        }
                        j = 1;
                    }
                    else
                    {
                        //못 찾은 경우
                        //l.Log(lboxLog, $"업데이트 정보창을 못 찼았어요.");
                        j = 0;
                    }
                    break;

                default:
                    l.Log(lboxLog, "의사랑핸들\\오류");
                    break;
            }
            return j;
        }
        #endregion handle



    }
}