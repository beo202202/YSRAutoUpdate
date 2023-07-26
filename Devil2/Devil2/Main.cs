//2022-01-16 포스트 캡쳐 기능
//2022-08-16 환경설정 xml 일부 저장기능

//2022-08-18 로그가 실행이 드디어 됨. 그러나 너무 길어진 거 같음. 그럴바에 메인에 로그 넣는게 낫지 않나

//텍스트만 썼는데도 불구하고 메모리가 조금씩 올라간다 해결 방법은?

//로그도 있는지 없는지 확인하면서 계속 저장해야함. (파일명: yyyy-mm-dd)
//저장 버튼 누르면 저장하기 >> 이후 값이 바뀔 때마다 저장하기 or 닫기 할 때마다 저장하기
// 설정 창이 닫히면 메인 폼 위로 오게 하기?
//로그 클래스를 파셜로 나눠서 메인에서 실행 가능하게
//그 후 셋폼에서도 가능하게
//세팅폼을 실행 할 때 값을 불러오기
//시작버튼을 눌렀을 때 저장된 값을 불러와 변수에 저장하기
//SetForm에서 로그 쓰는 방법 public 써야하나? 클래스 따로 만들어서 해야하나?

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using OpenCvSharp;
using System.IO;
using OpenCvSharp.Detail;

namespace Devil2
{
    public partial class Main : Form
    {
        //panel 선언
        //ucPanel.ucPanel1 ucPan1 = new ucPanel.ucPanel1();
        //ucPanel.ucPanel2 ucPan2 = new ucPanel.ucPanel2();

        private void Form1_Load(object sender, EventArgs e)
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            //ucPan1.eLogSender += UcPan_eLogSender;
            //ucPan2.eLogSender += UcPan_eLogSender;

            //panel1.Controls.Add(ucPan1);

            string LogInfo = "시작되었습니다.";
            lboxLog.Items.Insert(0, LogInfo);
            l.Log(enLogLevel.Info, $"테스트" );
            LogInfo = ".";
        }

        #region del Event
        private void UcPan_eLogSender(object oSender, enLogLevel eLevel, string strLog)
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            l.Log(eLevel, $"[{oSender.ToString()}] {strLog}");
            //string LogInfo = "테스트";
            //ucPan1.lboxLog.Items.Insert(0, LogInfo);
            //throw new NotImplementedException();
        }
        #endregion


        //테스트 비트맵 선언
        Bitmap btMain;

        public Main()
        {
            

            InitializeComponent();


            //textBox1.SelectionStart = textBox1.Text.Length;
            //textBox1.ScrollToCaret();

            
            이미지받아오기();

            //abc_Img[1] = new Bitmap(@"img\마을_영웅.PNG"); //이름을 모험 관련으로 바꾸기 @@@@@@@@@@@@@@@@@@@          

        }

        private void 이미지받아오기()
        {
            //bitMapList.Add(bp0);
            //bitMapList.Add(bp1);
            //bitMapList.Add(bp2);
            //bitMapList.Add(bp3);
            //bitMapList.Add(bp4);
            //bitMapList.Add(bp5);
            //bitMapList.Add(bp6);
            ////bitMapList.Add(bp7);
            //bitMapList.Add(bp8);

            //pictureBox1.Image = bitMapList[0];
            //pictureBox2.Image = bitMapList[1];
            //pictureBox2.Image = bitMapList[2];

            //pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //앱플레이어 선언
        //String AppPlayerName = "LDPlayer";
        //String AppPlayerName = "BlueStacks";
        String AppPlayerName = ""; //저장된 값 불러오기
        //앱플레이어 고정 해야함
        //앱플레이어 크기를 저정할 변수
        //double full_width = 0;
        //double full_height = 0;
        //앱플레이어 지정한 크기
        //double pix_width = 830;
        //double pix_height = 553;

        //비트맵 배열 선언
        List<Bitmap> bitMapList = new List<Bitmap>();

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hWnd1, IntPtr hWnd2, string lpsz1, string lpsz2);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int SW_SHOWNORMAL = 1;

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);

        [DllImport("user32")]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

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

        //마우스
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;

        public object ListBox { get; internal set; }

        //x,y 값을 전달해주면 지정된 핸들에 마우스 클릭 이벤트를 발생합니다.
        private void 마우스클릭(int x, int y)
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            //클릭이벤트를 발생시킬 플레이어를 찾습니다.
            IntPtr findwindow = FindWindow(null, AppPlayerName);
            if (findwindow != IntPtr.Zero)
            {
                if (AppPlayerName == "LDPlayer")
                {
                    //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
                    //IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, "Qt5QWindowIcon", "ScreenBoardClassWindow");
                    IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, null, "TheRender");

                    //y = y - 32; //녹스 플레이어는 상단바의 길이를 빼줘야 한다.
                    IntPtr lparam = new IntPtr(x | (y << 16));

                    //플레이어 핸들에 클릭 이벤트를 전달합니다.
                    SendMessage(hwnd_child, WM_LBUTTONDOWN, 1, lparam);

                    SendMessage(hwnd_child, WM_LBUTTONUP, 0, lparam);
                    //Delay(100);

                    //textBox1.AppendText("클릭" + "X= " + x + "  Y = " + y + "\r\n");

                }
                else if (AppPlayerName == "BlueStacks")
                {
                    //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
                    //IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, "Qt5QWindowIcon", "ScreenBoardClassWindow");
                    IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, null, "BlueStacks Android PluginAndroid");

                    //x = x - 7;
                    //y = y - 46; //BlueStacks은 상단바의 길이를 빼줘야 한다.
                    IntPtr lparam = new IntPtr(x | (y << 16));

                    //플레이어 핸들에 클릭 이벤트를 전달합니다.
                    SendMessage(hwnd_child, WM_LBUTTONDOWN, 1, lparam);
                    SendMessage(hwnd_child, WM_LBUTTONUP, 0, lparam);

                    //textBox1.AppendText("클릭" + "X= " + x + "  Y = " + y + "\r\n");
                }
                //else if (AppPlayerName == "상품수정")
                //{
                //    //플레이어를 찾았을 경우 클릭이벤트를 발생시킬 핸들을 가져옵니다.
                //    //IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, "Qt5QWindowIcon", "ScreenBoardClassWindow");
                //    IntPtr hwnd_child = FindWindowEx(findwindow, IntPtr.Zero, null, "Chrome Legacy Window");

                //    //x = x - 7;
                //    //y = y - 46; //BlueStacks은 상단바의 길이를 빼줘야 한다.
                //    IntPtr lparam = new IntPtr(x | (y << 16));

                //    //플레이어 핸들에 클릭 이벤트를 전달합니다.
                //    SendMessage(hwnd_child, WM_LBUTTONDOWN, 1, lparam);
                //    SendMessage(hwnd_child, WM_LBUTTONUP, 0, lparam);
                //}
            }
        }

        //서치이미지에 특정 좌표 사이만 찾는 기능을 넣기
        //searchIMG에 스크린 이미지와 찾을 이미지 번호를 넣어줍니다.
        public int searchIMG(int a, String b) //find_img 를 숫자만 받아서..어찌고 저쩌고...
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            int i = 0;
            try
            {


                IntPtr findwindow = FindWindow(null, AppPlayerName);
                if (AppPlayerName != "" && findwindow != IntPtr.Zero)
                {

                    //플레이어를 찾았을 경우
                    //textBox1.Text += "앱플레이어 찾았습니다.\r\n";

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
                            int offsetX = 0;
                            int offsetY = 0;
                            if (AppPlayerName == "LDPlayer")
                            {
                                offsetY = 32;
                                //maxloc.Y = maxloc.Y - offsetY; //녹스 플레이어는 상단바의 길이를 빼줘야 한다.
                                IntPtr lparam = new IntPtr(maxloc.X | (maxloc.Y << 16));
                            }
                            else if (AppPlayerName == "BlueStacks")
                            {
                                offsetX = 7;
                                offsetY = 46;
                                //maxloc.X = maxloc.X - offsetX;
                                //maxloc.Y = maxloc.Y - offsetY; //BlueStacks은 상단바의 길이를 빼줘야 한다.
                                IntPtr lparam = new IntPtr(maxloc.X | (maxloc.Y << 16));
                            }
                            int click_x = maxloc.X + bitMapList[a].Width / 2 - offsetX;
                            int click_y = maxloc.Y + bitMapList[a].Height / 2 - offsetY;

                            //마우스클릭(click_x, click_y);
                            //textBox1.Text += "클릭" + "X= " + click_x + "  Y = " + click_y + "\r\n";

                            //textBox1.AppendText("C" + "[ " + maxval + "%]" + b + "\r\n");
                            l.Log(enLogLevel.Info, $"C" + "[ " + maxval + "%]" + b);
                            //textBox1.AppendText(b + "\r\n");
                            i = 1;
                        }
                        else
                        {
                            //textBox1.AppendText("F " + "[ " + maxval + "%]" + b + "\r\n");
                            l.Log(enLogLevel.Info, $"F " + "[ " + maxval + "%]" + b);
                            //textBox1.AppendText("이미지 찾지 못함2" + "\r\n");
                            //textBox1.Text += "이미지 찾지 못함2" + "\r\n";
                            //Delay(500);
                        }
                    }
                }

                else
                {
                    //플레이어를 못찾을경우
                    //textBox1.AppendText("앱플레이어 못 찾았어요" + a + "." + "\r\n");
                    l.Log(enLogLevel.Info, $"앱플레이어 못 찾았어요" + a + ".");
                    i = 0;
                }
                return i;
            }
            catch
            {
                //textBox1.AppendText("찾기오류\\searchIMG.\r\n");
                l.Log(enLogLevel.Info, $"찾기오류\\searchIMG.");
            }
            return i;
            //finally { }

        }


        //searchIMGClick에 스크린 이미지와 찾을 이미지 번호를 넣어줍니다.
        public int searchIMGClick(int a, String b)
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            int i = 0;
            try
            {
                IntPtr findwindow = FindWindow(null, AppPlayerName);
                if (AppPlayerName != "" && findwindow != IntPtr.Zero)
                {
                    //플레이어를 찾았을 경우
                    //textBox1.Text += "앱플레이어 찾았습니다.\r\n";

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
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    //pictureBox1.Image = bmp;

                    //pictureBox2 이미지를 표시해줍니다.
                    if (pictureBox2.Image != null)
                    {
                        pictureBox2.Image.Dispose();
                    }

                    //pictureBox3.Image = bitMapList[a];

                    //스크린 이미지 선언
                    using (Mat ScreenMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bmp))
                    //찾을 이미지 선언
                    using (Mat FindMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitMapList[a]))
                    //스크린 이미지에서 FindMat 이미지를 찾아라
                    using (Mat res = ScreenMat.MatchTemplate(FindMat, TemplateMatchModes.CCoeffNormed))
                    {
                        //찾은 이미지의 유사도를 담을 더블형 최대 최소 값을 선언합니다.
                        double minval, maxval = 0;
                        //찾은 이미지의 위치를 담을 포인트형을 선업합니다.
                        OpenCvSharp.Point minloc, maxloc;
                        //찾은 이미지의 유사도 및 위치 값을 받습니다. 
                        Cv2.MinMaxLoc(res, out minval, out maxval, out minloc, out maxloc);
                        //textBox1.Text += "찾은 이미지의 유사도 : " + maxval + "\r\n";

                        maxval = Math.Truncate(maxval * 100) / 100;
                        Math.Truncate(maxval);
                        maxval *= 100;


                        //이미지를 찾았을 경우 클릭이벤트를 발생!!
                        if (maxval >= 80)
                        {
                            int offsetX = 0;
                            int offsetY = 0;
                            if (AppPlayerName == "LDPlayer")
                            {
                                offsetY = 32;
                                //maxloc.Y = maxloc.Y - offsetY; //녹스 플레이어는 상단바의 길이를 빼줘야 한다.
                                IntPtr lparam = new IntPtr(maxloc.X | (maxloc.Y << 16));
                            }
                            else if (AppPlayerName == "BlueStacks")
                            {
                                offsetX = 7;
                                offsetY = 46;
                                //maxloc.X = maxloc.X - offsetX;
                                //maxloc.Y = maxloc.Y - offsetY; //BlueStacks은 상단바의 길이를 빼줘야 한다.
                                IntPtr lparam = new IntPtr(maxloc.X | (maxloc.Y << 16));
                            }
                            int click_x = maxloc.X + bitMapList[a].Width / 2 - offsetX;
                            int click_y = maxloc.Y + bitMapList[a].Height / 2 - offsetY;

                            마우스클릭(click_x, click_y);
                            //textBox1.Text += "클릭" + "X= " + click_x + "  Y = " + click_y + "\r\n";

                            //textBox1.AppendText("C" + "[ " + maxval + "%]" + b + "\r\n");
                            l.Log(enLogLevel.Info, $"C" + "[ " + maxval + "%]" + b);
                            //textBox1.AppendText(b + "\r\n");
                            i = 1;
                        }
                        else
                        {
                            //textBox1.AppendText("F " + "[ " + maxval + "%]" + b + "\r\n");
                            l.Log(enLogLevel.Info, $"F " + "[ " + maxval + "%]" + b);
                            //textBox1.AppendText("이미지 찾지 못함2" + "\r\n");
                            //textBox1.Text += "이미지 찾지 못함2" + "\r\n";
                            //Delay(500);
                        }
                    }
                }
                else
                {
                    //플레이어를 못찾을경우
                    //textBox1.AppendText("앱플레이어 못 찾았어요" + a + "." + "\r\n");
                    l.Log(enLogLevel.Info, $"앱플레이어 못 찾았어요" + a + ".");
                }
            }
            catch
            {
                //textBox1.AppendText("이미지 찾지 못함 or 오류2" + "\r\n");
            }
            //finally { }
            return i;
        }

        #region Button Click
        //LDPlyaer 핸들 설정
        private void button1_Click(object sender, EventArgs e)
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            Button btn = sender as Button;

            l.Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");

            LDPlayer핸들();
        }

        


        //텍스트 박스,리스트(로그)박스,이미지 지우기
        private void button3_Click(object sender, EventArgs e)
        {
            // 1. 로그 클래스 개체 선언
            LogClass l = new LogClass();

            Button btn = sender as Button;            

            //textBox1.Text = "";
            lboxLog.Items.Clear();

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            //MessageBox.Show(enLogLevel.Info.ToString());

            lboxLog.Items.Insert(0, l.Log($"{btn.Text} 버튼 Click"));

            //l.SetText2(lboxLog, $"{btn.Text} 버튼 Click");      // 2. 메소드 호출 .Text가 아님.
            //l = null;                                                               // 3. 리소스 반환

        }


        //이미지 찾기4
        private void button4_Click(object sender, EventArgs e)
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            Button btn = sender as Button;

            l.Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");
        }

        //스크린샷
        private void button5_Click(object sender, EventArgs e)
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            Button btn = sender as Button;

            l.Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");

            btMain = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                                Screen.PrimaryScreen.Bounds.Height);
            using (Graphics g = Graphics.FromImage(btMain))
            {
                g.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
                                        Screen.PrimaryScreen.Bounds.Y,
                                        0, 0,
                                        btMain.Size,
                                        CopyPixelOperation.SourceCopy);
                //Picture Box Display
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                pictureBox1.Image = btMain;
            }
        }

        //버튼6 클릭
        private void button6_Click(object sender, EventArgs e) //캡쳐
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            Button btn = sender as Button;

            l.Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");

            IntPtr findwindow = FindWindow(null, AppPlayerName);
            if (AppPlayerName != "" && findwindow != IntPtr.Zero)
            {
                //플레이어를 찾았을 경우
                //textBox1.AppendText("앱플레이어 찾았습니다.\r\n");
                //l.Log(enLogLevel.Info, $"앱플레이어를 찾았습니다.");
                try
                {
                    //찾은 플레이어를 바탕으로 Graphics 정보를 가져옵니다.
                    Graphics Graphicsdata = Graphics.FromHwnd(findwindow);
                    //l.Log(enLogLevel.Info, $"Graphicsdata: " + Graphicsdata);

                    //찾은 플레이어 창 크기 및 위치를 가져옵니다. 
                    Rectangle rect = Rectangle.Round(Graphicsdata.VisibleClipBounds);
                    //l.Log(enLogLevel.Info, $"rect: " + rect);

                    //LDPlayer 캡쳐오류
                    if(AppPlayerName == "LDPlayer" && rect.Width != 1002 && rect.Height != 575)
                    {
                        l.Log(enLogLevel.Info, $"LDPlayer_캡쳐 오류_크기 오류");
                        l.Log(enLogLevel.Info, $"LDPlayer_반복될 경우_크기 조절 바람");
                    }

                    //BlueStacks 5 캡쳐오류
                    if (AppPlayerName == "BlueStacks App Player" && rect.Width == 0)
                    {
                        l.Log(enLogLevel.Info, $"캡처 오류 원인_최소화");

                        ShowWindow(findwindow, SW_SHOWNORMAL);
                        l.Log(enLogLevel.Info, $"캡처 오류 원인_최소화_노멀조치");

                        //찾은 플레이어를 바탕으로 Graphics 정보를 가져옵니다.
                        Graphicsdata = Graphics.FromHwnd(findwindow);

                        //찾은 플레이어 창 크기 및 위치를 가져옵니다.
                        rect = Rectangle.Round(Graphicsdata.VisibleClipBounds);
                    }

                    //플레이어 창 크기 만큼의 비트맵을 선언해줍니다.
                    //l.Log(enLogLevel.Info, $"rect.Width: " + rect.Width + "rect.Height: " + rect.Height);
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

                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                        pictureBox1.Image = null;
                    }
                    // pictureBox1 이미지를 표시해줍니다.
                    pictureBox1.Image = bmp;
                    l.Log(enLogLevel.Info, $"캡처되었습니다.");
                }
                catch
                {
                    //폼 다시 노말로(최소화취소)
                    //this.WindowState = FormWindowState.Normal;
                    l.Log(enLogLevel.Info, $"앱플레이어 찾음_캡쳐 오류");
                }
            }
            else
            {
                //플레이어를 못찾을경우
                //textBox1.AppendText("앱플레이어 못 찾았어요.\r\n");
                l.Log(enLogLevel.Info, $"앱플레이어를 못 찾았습니다.");
            }
        }

        //ucpanel2 불러오기
        private void btnSet_Click(object sender, EventArgs e)
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            Button btn = sender as Button;

            l.Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");

            //panel1.Controls.Clear();
            //panel1.Controls.Add(ucPan2);



            //중복 폼 체크하는 것
            if (Application.OpenForms["SetForm"] is SetForm setform)
            {
                // Form1 열려 있을 경우
                setform.Focus();
                return;
            }
            //Form1이 열려있지 않은 경우
            //. 새로 띄울 Form의 new 객체 생성
            //setform = new SetForm(strParameter);
            //subform.SetForm setform = new subform.SetForm();
            // 2. 폼이름.Show();
            //setform.MdiParent = this;
            setform = new SetForm();
            setform.Show();

            //l.Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");

        }

        private void btnSet2_Click(object sender, EventArgs e)
        {
            // 로그 클래스 개체 선언
            // 1. 인스턴스 생성
            LogClass l = new LogClass();

            Button btn = sender as Button;

            //MessageBox.Show(enLogLevel.Info.ToString()) ;

            //eLogSender("닫기 버튼", enLogLevel.Info, "Button Click");

            //l.Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");

            //Application.Exit();

            // 전후 비교를 위해 내용을 비웁니다.
            //textBox1.Text = "";
            //lboxLog.Items.Clear();

            // MyClass 인스턴스를 만들고, 메소드에 처리를 요청합니다. 
            //LogClass l = new LogClass();                          // 1. 인스턴스 생성
            //logclass.SetText(textBox1, $"{btn.Text} 버튼 Click");      // 2. 메소드 호출 .Text가 아님
            //logclass = null;                                                               // 3. 리소스 반환

            l.SetText2(lboxLog, $"{btn.Text} 버튼 Click");      // 2. 메소드 호출 .Text가 아님
            l = null;                                                               // 3. 리소스 반환

            // 메시지가 찍혔는지 확인해 봅니다.
            //MessageBox.Show(lboxLog.ToString());

            //panel1.Controls.Clear();
            //panel1.Controls.Add(ucPan1);
            //panel1.Controls.Remove(ucPan2);
        }
        #endregion Button Click



        #region handle
        //블루스택 핸들 설정
        private void button2_Click(object sender, EventArgs e)
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            Button btn = sender as Button;

            l.Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");
            //앱플레이어 이름
            //AppPlayerName = "BlueStacks";     //블루스택3
            AppPlayerName = "BlueStacks App Player";        //블루스택5

            //부모창 핸들
            //IntPtr hd1 = FindWindow("HwndWrapper[Bluestacks.exe;;8464f083-5e86-437e-8eb2-6e4fd4b5b58e]", "BlueStacks");
            //블루스택3
            //IntPtr hd1 = FindWindow(null, "BlueStacks");
            //블루스택5
            IntPtr hd1 = FindWindow("Qt5154QWindowOwnDCIcon", "BlueStacks App Player");

            //자식 창1  
            //블루스택3
            //IntPtr hd2 = FindWindowEx(hd1, IntPtr.Zero, null, "BlueStacks Android PluginAndroid");
            //블루스택5
            IntPtr hd2 = FindWindowEx(hd1, IntPtr.Zero, "Qt5154QwindowIcon", "HD-Player");

            //자식 창2 
            //블루스택3
            //IntPtr hd3 = FindWindowEx(hd2, IntPtr.Zero, null, "_ctl.Window");
            //블루스택5
            IntPtr hd3 = FindWindowEx(hd2, IntPtr.Zero, "BlueStacksApp", "_ctl.Wind");


            if (hd1 != IntPtr.Zero)
            {
                //textBox1.AppendText("부모:    " + hd1.ToString() + "\r\n자식1:  " + hd2.ToString() + "\r\n자식2:  " + hd3.ToString() + "\r\n");
                l.Log(enLogLevel.Info, $"부모:    " + hd1.ToString() + "\r\n자식1:  " + hd2.ToString() + "\r\n자식2:  " + hd3.ToString());
            }
            else
            {
                //못 찾은 경우
                //textBox1.AppendText("블루스택창을 못 찼았어요.\r\n");
                l.Log(enLogLevel.Info, $"블루스택창을 못 찼았어요.");
            }
        }

        public void LDPlayer핸들()
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            //앱플레이어: LDPlayer
            AppPlayerName = "LDPlayer";
            //녹스
            //부모창 핸들
            //IntPtr hd1 = FindWindow("Qt5QWindowIcon", "녹스 플레이어");
            //LDPlayer4
            //IntPtr hd1 = FindWindow(null, "LDPlayer");
            //LDPlayer9
            IntPtr hd1 = FindWindow("LDPlayerMainFrame", "LDPlayer");

            //자식 창1  
            //LDPlayer4
            //IntPtr hd2 = FindWindowEx(hd1, IntPtr.Zero, null, "TheRender");
            //LDPlayer9
            IntPtr hd2 = FindWindowEx(hd1, IntPtr.Zero, "RenderWindow", "TheRender");


            //자식 창2       
            //IntPtr hd3 = FindWindowEx(hd2, IntPtr.Zero, null, "sub");
            //if문 넣어서
            //LDPlayer4
            //IntPtr hd3 = FindWindowEx(hd2, IntPtr.Zero, null, "AnglePlayer_0");
            //LDPlayer9
            IntPtr hd3 = FindWindowEx(hd2, IntPtr.Zero, "subWin", "sub");

            if (hd1 != IntPtr.Zero)
            {
                //textBox1.AppendText("부모:    " + hd1.ToString() + "\r\n자식1:  " + hd2.ToString() + "\r\n자식2:  " + hd3.ToString() + "\r\n");
                l.Log(enLogLevel.Info, $"부모:    " + hd1.ToString() + "\r\n자식1:  " + hd2.ToString() + "\r\n자식2:  " + hd3.ToString());
            }
            else
            {
                //못 찾은 경우
                //textBox1.AppendText("LDPlayer창을 못 찼았어요.\r\n");
                l.Log(enLogLevel.Info, $"LDPlayer창을 못 찼았어요.");
            }
        }
        #endregion handle

        //클래스로 만들고
        //오버로딩으로 만들기
        public int searchIMGAdv(int z, int a, int b, int c, int d) //find_img 를 숫자만 받아서..어찌고 저쩌고...
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            int i = 0;

            IntPtr findwindow = FindWindow(null, AppPlayerName);
            if (AppPlayerName != "" && findwindow != IntPtr.Zero)
            {
                //플레이어를 찾았을 경우
                //textBox1.Text += "앱플레이어 찾았습니다.\r\n";

                //찾은 플레이어를 바탕으로 Graphics 정보를 가져옵니다.
                Graphics Graphicsdata = Graphics.FromHwnd(findwindow);

                //찾은 플레이어 창 크기 및 위치를 가져옵니다. 
                Rectangle rect = Rectangle.Round(Graphicsdata.VisibleClipBounds);

                //플레이어 창 크기 만큼의 비트맵을 선언해줍니다.
                Bitmap bmp = new Bitmap(rect.Width, rect.Height);
                //200으로 설정했음 

                //textBox1.AppendText(rect.Width + " * " + rect.Height +"\r\n");
                //830*553 160 dpi 블루스택
                //830*465 160 dpi LDPlayer

                // pictureBox1 이미지를 표시해줍니다.
                pictureBox1.Image = bmp;

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

                try
                {
                    //a = 300
                    //b = 50
                    //c = 600
                    //d = 520
                    //크기....
                    Bitmap croppedBitmap = bmp;
                    croppedBitmap = croppedBitmap.Clone(
                            new Rectangle(a, b, rect.Width - c, rect.Height - d),
                            System.Drawing.Imaging.PixelFormat.DontCare);
                    pictureBox2.Image = croppedBitmap;
                    //bmp = croppedBitmap;

                    //이미지를 표시해줍니다.
                    //pictureBox2.Image = croppedBitmap;
                    pictureBox3.Image = bitMapList[z];

                    //스크린 이미지 선언
                    using (Mat ScreenMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(croppedBitmap))
                    //찾을 이미지 선언
                    using (Mat FindMat = OpenCvSharp.Extensions.BitmapConverter.ToMat(bitMapList[z]))
                    //스크린 이미지에서 FindMat 이미지를 찾아라
                    using (Mat res = ScreenMat.MatchTemplate(FindMat, TemplateMatchModes.CCoeffNormed))
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
                        //textBox1.AppendText("F " + "[ " + maxval + "%]");
                        l.Log(enLogLevel.Info, $"F " + "[ " + maxval + "%]");

                        //이미지를 찾았을 경우 클릭이벤트를 발생!!
                        if (maxval >= 60)
                        {
                            int offsetX = 0;
                            int offsetY = 0;
                            if (AppPlayerName == "LDPlayer")
                            {
                                offsetY = 32;
                                //maxloc.Y = maxloc.Y - offsetY; //녹스 플레이어는 상단바의 길이를 빼줘야 한다.
                                IntPtr lparam = new IntPtr(maxloc.X | (maxloc.Y << 16));
                            }
                            else if (AppPlayerName == "BlueStacks")
                            {
                                offsetX = 7;
                                offsetY = 46;
                                //maxloc.X = maxloc.X - offsetX;
                                //maxloc.Y = maxloc.Y - offsetY; //BlueStacks은 상단바의 길이를 빼줘야 한다.
                                IntPtr lparam = new IntPtr(maxloc.X | (maxloc.Y << 16));
                            }
                            int click_x = maxloc.X + bitMapList[z].Width / 2 - offsetX;
                            int click_y = maxloc.Y + bitMapList[z].Height / 2 - offsetY;

                            //마우스클릭(click_x, click_y);
                            //textBox1.AppendText("[위치" + "X= " + click_x + " Y = " + click_y + "]\r\n");
                            l.Log(enLogLevel.Info, $"[위치" + "X= " + click_x + " Y = " + click_y);

                            i = 1;
                        }
                        else
                        {
                            //textBox1.AppendText("이미지 찾지 못함1" + "\r\n");
                            l.Log(enLogLevel.Info, $"이미지 찾지 못함1");

                            i = 0;
                        }
                    }

                }
                catch
                {
                    //textBox1.AppendText("찾기오류\\searchIMGAdv.\r\n");
                    l.Log(enLogLevel.Info, $"찾기오류\\searchIMGAdv.");
                }
            }
            else
            {
                //플레이어를 못찾을경우
                //textBox1.AppendText("앱플레이어 못 찾았어요.\r\n");
                l.Log(enLogLevel.Info, $"앱플레이어 못 찾았어요.");
                i = 0;
            }

            //finally { }
            return i;
        }

        public static Image resizeImage(Image image)
        {
            //로그 클래스 개체 선언
            LogClass l = new LogClass();

            if (image != null)
            {
                Bitmap croppedBitmap = new Bitmap(image);
                croppedBitmap = croppedBitmap.Clone(
                        new Rectangle(300, 0, image.Width - 600, image.Height - 450),
                        System.Drawing.Imaging.PixelFormat.DontCare);
                return croppedBitmap;
            }
            else
            {
                return image;
            }
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}