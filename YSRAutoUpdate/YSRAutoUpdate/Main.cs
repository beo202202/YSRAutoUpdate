// 2022-01-16 포스트 캡쳐 기능


// 2022년 8월
/*
    // 2022-08-16 환경설정 xml 일부 저장기능

    // 2022-08-18 로그가 실행이 드디어 됨. 그러나 너무 길어진 거 같음. 그럴바에 메인에 로그 넣는게 낫지 않나

    // 2022-08-19 비활성 마우스 입력이 안되는 것 같다.
    // 2022-08-19 텍스트만 썼는데도 불구하고 메모리가 조금씩 올라간다 해결 방법은?

    // 2022-08-22 질문창 Y가 클릭이 안되어서 SIK (키보드 입력으로 대체) PostMessage 로 해도 되는 것인가?
    // 2022-08-22 키보드 입력 대신 SendMessage 버튼 클릭으로 대체

    // 2022-08-24 32비트로 이미지 교체 완료, 이미지 비교 시 32비트로 비교를 해야하는데 24비트는 안된다. 캡처 도구 로만 캡처하자(알캡처, 포토샵 안됨 ㅠ.ㅠ)
    // 2022-08-24 24비트로 비교하려면 비트 변환을 해야한다.
    // 2022-08-24 AppPlayerName을 쓰는 지역변수가 있어서 공유를 할 수 없었다. 변경 해주니 전역변수로 공유 할 수 있었다.

    // 2022-08-25 while문 중 두 줄이상에서 값이 변했는데 안나오는 이유를 모르겠다. >> while문은 반복을 완료하고 값을 검사한다.
    // 2022-08-25 while문에서 SendMessage랑 잘 안맞는가 보다. 계속 멈추는 이유를 찾았다. PostMessage로 바꾸니 작동을 한다.
    // 2022-08-25 한꺼번에 업데이트가 안되어 하나씩 업데이트 하기로 하였다.
    // 2022-08-25 창 찾는중...3 에서 종료되어 넘어가지 않고 무한 루프를 한다.

    // 2022-08-26 while은 빨리 돌기 때문에 Delay를 걸어놔야한다.
    // 2022-08-26 send로 다시 바꾸었다.
    // 2022-08-26 'YSRAutoUpdate' 로 바꾸었다.
    // 2022-08-26 로그 출력 문자들을 정리해보려 했으나 완성 못시켰다.

    // 2022-08-29 로그 폰트 문제였다.
    // 2022-08-29 post로 다시 바꾸었다. post= 쪽지만 보내기, send 바로 답장 받기
    // 2022-08-29 자동모드 진행 중 추가
    // 2022-08-29 자동모드를 스레드로 바꿈
    // 2022-08-29 while문을 넣으면 폼이 안보임

    // 2022-08-30 폼 띄우기 전에 while 문이 들어가버렸던 문제 해결
    // 2022-08-30 스레드로 나뉘었으나 Join.. 문제 생김 원인 불명

    // 2022-08-31 send로 바꿈, 핸들 항상 위로. 핸들 숨기기 등 넣음.
*/

// 2022년 9월
/*
// 09-01 labelProgressBar1, 2 추가, DB 미연결 시 오류 추가, YSR2000 - SQL Anywhere 네트워크 서버, WATCOM SQL NT234c 비활성 DB 네트워크 추가, 자동모드 종료 추가
// 09-05 여러가지 추가하였으나 추후 자세히 기재, 콤보값 변경 시 자동 변경 기능... 미구현
*/


// 설정창 투입, 저장, opacity 투명도 설정기능도 넣기 현재창 상대창
// 업데이트 내역도 저장(성공내역)
// Label 최대치도 수치 변경이 가능한가

// 아이콘 이미지 변경, 
// 스레드 개편은 못함. 잘 안됨. 그냥 그대로.
// 스레드로 바꾸면 while로 멈춤이 없으려나? 프로그램 활성화 비활성화 맨 뒤 맨 앞 문제인가?


// 설정창을 투입할까? ㅇ~ㅇ 까지 같은거
// 로그 저장?, 자동모드 진행 중을 할까?

// NuGet 패키지 정리하여 용량을 줄이기 (필수는 제외, 예.OpenCV)
//업데이트 정보창에서 자동 클릭 


// 전체함수에 추가하기 l = null;                                                               // 3. 리소스 반환
//로그도 있는지 없는지 확인하면서 계속 저장해야함. (파일명: yyyy-mm-dd)
//저장 버튼 누르면 저장하기 >> 이후 값이 바뀔 때마다 저장하기 or 닫기 할 때마다 저장하기
// 설정 창이 닫히면 메인 폼 위로 오게 하기?
//로그 클래스를 파셜로 나눠서 메인에서 실행 가능하게
//그 후 셋폼에서도 가능하게
//세팅폼을 실행 할 때 값을 불러오기
//시작버튼을 눌렀을 때 저장된 값을 불러와 변수에 저장하기
//SetForm에서 로그 쓰는 방법 public 써야하나? 클래스 따로 만들어서 해야하나?

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
        int labelMAX;
        public static Main main;
        public Main()
        {
            InitializeComponent(); //이게 있어야하나?
            
            이미지받아오기();

            this.Load += Form_Load;
        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int j=0;
            j = Convert.ToInt32(comboBox1.SelectedItem);
            //MessageBox.Show(j.ToString());
            //MessageBox.Show(Convert.ToInt32(comboBox1.SelectedItem).ToString());
            comboBox1.Items.Clear();
            for (int i = 5306; i <= Convert.ToInt32(comboBox2.SelectedItem); i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.Text = j.ToString();
            MessageBox.Show(j.ToString());
            MessageBox.Show(comboBox1.Text);
            if (Convert.ToInt32(comboBox1.SelectedItem) > 0 && Convert.ToInt32(comboBox2.SelectedItem) > 0) // 값이 0이하면 캔슬하기
            {     
                int labelMAX2;
                labelMAX2 = Convert.ToInt32(comboBox2.SelectedItem) - Convert.ToInt32(comboBox1.SelectedItem) + 1;
                labelMAX = labelMAX2;
                Config.SavaIniFile();
                labelProgressBar1.Maximum = labelMAX;                
            }
            //comboBox1.Items.Clear();
            //for (int i = 5306; i <= Convert.ToInt32(comboBox2.SelectedItem); i++)
            //{
            //    comboBox1.Items.Add(i);
            //}           
        }

        int index1;
        private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //MessageBox.Show(comboBox1.Text);
            if (index1 > 0)
            {
                MessageBox.Show(comboBox1.Text);
                int labelMAX2;
                labelMAX2 = Convert.ToInt32(comboBox2.SelectedItem) - Convert.ToInt32(comboBox1.SelectedItem) + 1;
                if (Convert.ToInt32(comboBox1.SelectedItem) > 0 && Convert.ToInt32(comboBox2.SelectedItem) > 0) // 값이 0이하면 캔슬하기
                {
                    labelMAX = labelMAX2;
                    Config.SavaIniFile();
                    labelProgressBar1.Maximum = labelMAX;

                    int j;
                    j = Convert.ToInt32(comboBox1.SelectedItem);

                    //comboBox1.Items.Clear();
                    //for (int i = 5306; i <= Convert.ToInt32(comboBox2.SelectedItem); i++)
                    //{
                    //    comboBox1.Items.Add(i);
                    //}
                    //comboBox1.SelectedItem = j;
                }                
            }
            index1++;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            main = this;
            Config.LoadIniFile();
            int j = 0;
            j = Convert.ToInt32(comboBox1.SelectedItem);
            comboBox1.Items.Clear();
            for (int i = 5306; i <= Convert.ToInt32(comboBox2.SelectedItem); i++)
            {
                comboBox1.Items.Add(i);
            }
            comboBox1.Text = j.ToString();
            SetWindowPos(this.Handle, HWND_TOPMOST, 0, 0, 0, 0, WINDOW_FLAGS2);

            // 이벤트 핸들러 연결
            //Config.ItemStr += new StrAddHandler(this.strADD);

            //strADD("abcd");
            //this.TopMost = true;
            //progressBar1.Step = 20;

            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            // 프로그레스바 값 주는 예
            //InitProgressBar(uiLpb_1, 24);
            //InitProgressBar(uiLpb_2, 54);
            //InitProgressBar(uiLpb_3, 66);
            //InitProgressBar(uiLpb_4, 98);

            l.Log(lboxLog, "준비완료");
            l = null;
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
            }
            catch
            {
                l.Log(lboxLog, "이미지 불러오기 오류");
            }
            finally
            {
                l.Log(lboxLog, "이미지 불러오기 완료");
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
            int A = 5306; // 처음 시작 값
            int i, j, k, m;
            i = 0;
            j = 0;
            k = 0;
            m = 0;
            String exe_name; //b;

            Thread thread2 = new Thread(() => 자동모드진행중());
            thread2.Start();


            i = 의사랑핸들("YSR2000 - SQL Anywhere 네트워크 서버", 0);
            if (i == 1)
            {
                if (this.textBox1.InvokeRequired == true)
                {
                    this.textBox1.Invoke((MethodInvoker)delegate
                    {                        
                        this.textBox1.BackColor = Color.Yellow;
                        this.textBox1.ForeColor = Color.Black;
                        this.textBox1.Text = "데이터베이스와 연결이 되었습니다.".PadLeft(57);
                        thread2.Suspend();
                        //Delay(1000);
                    });
                }
            }
            else
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
                InitProgressBar(labelProgressBar1, 84);
                InitProgressBar(labelProgressBar2, 100);
                A = 9999;
            }
            
            //l.Log(lboxLog, thread2.ThreadState.ToString());
         

            while (A < 5310) // 마지막 값 -1 5390
            {
                if (thread2.ThreadState.ToString() == "Suspended")
                {
                    this.textBox1.BackColor = Color.FromArgb(192, 0, 0);
                    this.textBox1.ForeColor = Color.White;
                    thread2.Resume();
                } 
                //l.Log(lboxLog, thread2.ThreadState.ToString());

                // 계속 실행
                // 실행파일 경로와 이름
                //exe_name = Application.StartupPath + "\\process.exe";
                exe_name = "D:\\의사랑 업데이트\\TETBL" + A;

                // 실행파일 실행
                Process.Start(exe_name);
                l.Log(lboxLog, exe_name + $" 실행");

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
                    InitProgressBar(labelProgressBar1, 84);
                    InitProgressBar(labelProgressBar2, 100);
                    A = 9999;
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
            InitProgressBar(labelProgressBar1, 84);
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

        private static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        private static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        private const UInt32 SWP_NOSIZE = 0x0001;
        private const UInt32 SWP_NOMOVE = 0x0002;        
        private const UInt32 SWP_NOACTIVATE = 0x0010;
        private const UInt32 HIDEWINDOW = 0x0080;
        private const UInt32 SWP_NOOWNERZORDER = 0x0200; // Z 순서에서 소유자 창의 위치를 변경하지 않습니다.
        private const UInt32 SWP_NOZORDER = 0x0004; // 현재 Z 순서를 유지합니다. ( hWndlnsertAfter 매개변수 무시)

        private const UInt32 WINDOW_FLAGS = SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE | SWP_NOOWNERZORDER;
        private const UInt32 WINDOW_FLAGS2 = SWP_NOMOVE | SWP_NOSIZE | SWP_NOZORDER;

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

            if (radioButton1.Checked)
            {
                thread1.Start();
            }
            else if (radioButton2.Checked)
            {                
                labelMAX = Convert.ToInt32(comboBox2.SelectedItem) - Convert.ToInt32(comboBox1.SelectedItem) + 1;
                MessageBox.Show(comboBox2.SelectedItem.ToString());
                labelProgressBar1.Maximum = labelMAX;
                //Config.IDInsert();
                //ini 생성 테스트
                Config.LoadIniFile(); // 불러오기 아님? 해당 경로에 INI 파일 생성

                //progressBar1.Value = 100;
            }
            else if (radioButton3.Checked)
            {
                //Config.LoadIniFile(); // 해당 경로에 INI 파일 생성
                Config.SavaIniFile(); //Config.ini 파일 경로에 저장
            }
        }
        #endregion Button Click

        public 
        int indexNumber;

        //int 점점점갯수;
        string 자동모드_점점점 = "ㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇㅇ";

        public void 자동모드진행중()
        {
            // 위의 변수를 모두 전역변수로 설정하고 아래 문자열을 timer에 넣어서 indexNumber++ 돌리면 위의 움짤처럼 동작하게됩니다.

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
                    //hd1 = FindWindowEx(hd, IntPtr.Zero, "TButton", "확인(&O)");
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