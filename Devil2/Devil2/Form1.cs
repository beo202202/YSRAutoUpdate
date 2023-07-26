//2022-01-16 포스트 캡쳐 기능


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

namespace Devil2
{
    public partial class Form1 : Form
    {
        //SetForm 선언
        subform.SetForm setfom1 = new subform.SetForm();

        //panel 선언
        ucPanel.ucPanel1 ucPan1 = new ucPanel.ucPanel1();
        ucPanel.ucPanel2 ucPan2 = new ucPanel.ucPanel2();

        private void Form1_Load(object sender, EventArgs e)
        {
            //ucPan1.eLogSender += UcPan_eLogSender;
            ucPan2.eLogSender += UcPan_eLogSender;

            panel1.Controls.Add(ucPan1);
        }

        #region del Event
        private void UcPan_eLogSender(object oSender, enLogLevel eLevel, string strLog)
        {
            //throw new NotImplementedException();
        }
        #endregion

        
        //테스트 비트맵 선언
        Bitmap btMain;

        /*
        Bitmap bp0 = new Bitmap(@"img\우편\마을_우편.PNG", true);

        bitMapList.Add(bp0);

            int i = 0; //int i,j =0 이 안되나?
        int j = 0;
        int k = 0;
        String b;
        //while (i == 0)
        //{
        b = "[우편]";
            Delay(1000);
        i = searchIMGClick(0, b);
        */

        public Form1()
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

            InitializeComponent();


            textBox1.SelectionStart = textBox1.Text.Length;
            textBox1.ScrollToCaret();

            Init();

            //abc_Img[1] = new Bitmap(@"img\마을_영웅.PNG"); //이름을 모험 관련으로 바꾸기 @@@@@@@@@@@@@@@@@@@          

        }

        private void Init()
        {
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

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        public static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);

        [DllImport("user32")]
        public static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);

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

        //x,y 값을 전달해주면 지정된 핸들에 마우스 클릭 이벤트를 발생합니다.
        private void 마우스클릭(int x, int y)
        {
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
                    Delay(100);

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

                            textBox1.AppendText("C" + "[ " + maxval + "%]" + b + "\r\n");
                            //textBox1.AppendText(b + "\r\n");
                            i = 1;
                        }
                        else
                        {
                            textBox1.AppendText("F " + "[ " + maxval + "%]" + b + "\r\n");
                            //textBox1.AppendText("이미지 찾지 못함2" + "\r\n");
                            //textBox1.Text += "이미지 찾지 못함2" + "\r\n";
                            //Delay(500);
                        }
                    }
                }

                else
                {
                    //플레이어를 못찾을경우
                    textBox1.AppendText("앱플레이어 못 찾았어요" + a + "." + "\r\n");
                    i = 0;
                }
                return i;
            }
            catch
            {
                textBox1.AppendText("찾기오류\\searchIMG.\r\n");
            }
            return i;
            //finally { }

        }


        //searchIMGClick에 스크린 이미지와 찾을 이미지 번호를 넣어줍니다.
        public int searchIMGClick(int a, String b)
        {
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

                            textBox1.AppendText("C" + "[ " + maxval + "%]" + b + "\r\n");
                            //textBox1.AppendText(b + "\r\n");
                            i = 1;
                        }
                        else
                        {
                            textBox1.AppendText("F " + "[ " + maxval + "%]" + b + "\r\n");
                            //textBox1.AppendText("이미지 찾지 못함2" + "\r\n");
                            //textBox1.Text += "이미지 찾지 못함2" + "\r\n";
                            //Delay(500);
                        }
                    }
                }
                else
                {
                    //플레이어를 못찾을경우
                    textBox1.AppendText("앱플레이어 못 찾았어요" + a + "." + "\r\n");
                }
            }
            catch
            {
                //textBox1.AppendText("이미지 찾지 못함 or 오류2" + "\r\n");
            }
            //finally { }
            return i;
        }


        //LDPlyaer 핸들 설정
        private void button1_Click(object sender, EventArgs e)
        {
            LDPlayer핸들();
        }

        public void LDPlayer핸들()
        {
            //앱플레이어 이름
            AppPlayerName = "LDPlayer";
            //녹스
            //부모창 핸들
            //IntPtr hd1 = FindWindow("Qt5QWindowIcon", "녹스 플레이어");
            IntPtr hd1 = FindWindow(null, "LDPlayer");

            //자식 창1  
            IntPtr hd2 = FindWindowEx(hd1, IntPtr.Zero, null, "TheRender");

            //자식 창2       
            //IntPtr hd3 = FindWindowEx(hd2, IntPtr.Zero, null, "sub");
            //if문 넣어서
            IntPtr hd3 = FindWindowEx(hd2, IntPtr.Zero, null, "AnglePlayer_0");

            if (hd1 != IntPtr.Zero)
            {
                textBox1.AppendText("부모:    " + hd1.ToString() + "\r\n자식1:  " + hd2.ToString() + "\r\n자식2:  " + hd3.ToString() + "\r\n");
            }
            else
            {
                //못 찾은 경우
                textBox1.AppendText("LDPlayer창을 못 찼았어요.\r\n");
            }
        }


        //블루스택 핸들 설정
        private void button2_Click(object sender, EventArgs e)
        {
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
                textBox1.AppendText("부모:    " + hd1.ToString() + "\r\n자식1:  " + hd2.ToString() + "\r\n자식2:  " + hd3.ToString() + "\r\n");
            }
            else
            {
                //못 찾은 경우
                textBox1.AppendText("블루스택창을 못 찼았어요.\r\n");
            }
        }


        //텍스트 박스,리스트(로그)박스,이미지 지우기
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            ucPan1.lboxLog.Items.Clear();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
        }


        //이미지 찾기4
        private void button4_Click(object sender, EventArgs e)
        {

        }

        public int searchIMGAdv(int z, int a, int b, int c, int d) //find_img 를 숫자만 받아서..어찌고 저쩌고...
        {

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
                        textBox1.AppendText("F " + "[ " + maxval + "%]");

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
                            textBox1.AppendText("[위치" + "X= " + click_x + " Y = " + click_y + "]\r\n");

                            i = 1;
                        }
                        else
                        {
                            textBox1.AppendText("이미지 찾지 못함1" + "\r\n");
                            i = 0;
                        }
                    }

                }
                catch
                {
                    textBox1.AppendText("찾기오류\\searchIMGAdv.\r\n");
                }
            }
            else
            {
                //플레이어를 못찾을경우
                textBox1.AppendText("앱플레이어 못 찾았어요.\r\n");
                i = 0;
            }

            //finally { }
            return i;
        }

        //스크린샷
        private void button5_Click(object sender, EventArgs e)
        {
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


            //pictureBox2.Image = resizeImage(pictureBox1.Image);
            //try
            //{
            //    모험(1000);
            //}
            //catch
            //{
            //    textBox1.AppendText("이미지 찾지 못함 or 모험오류2" + "\r\n");
            //}
        }


        //모험 로직
        public void 모험(int a)
        {
            //textBox1.AppendText("오류테스트1" + "\r\n");
            Bitmap bp0 = new Bitmap(@"img\모험\마을_모험.PNG", true);
            Bitmap bp1 = new Bitmap(@"img\모험\마을_모험_핫타임.PNG", true);
            Bitmap bp2 = new Bitmap(@"img\모험\모험.PNG", true);
            Bitmap bp3 = new Bitmap(@"img\모험\쫄작영지.PNG", true);
            Bitmap bp4 = new Bitmap(@"img\모험\탐험.PNG", true);
            Bitmap bp5 = new Bitmap(@"img\모험\마지막모험.PNG", true);
            Bitmap bp6 = new Bitmap(@"img\모험\시작하기.PNG", true);
            Bitmap bp7 = new Bitmap(@"img\모험\x2_2.PNG", true);
            Bitmap bp8 = new Bitmap(@"img\모험\2-2라운드.PNG", true);

            //Bitmap bp9 = new Bitmap(@"img\모험\마을_모험.PNG", true);

            //Bitmap bp10 = new Bitmap(@"img\모험\마을_모험.PNG", true);
            //Bitmap bp11 = new Bitmap(@"img\모험\마을_모험_핫타임.PNG", true);
            //Bitmap bp12 = new Bitmap(@"img\모험\모험.PNG", true);
            //Bitmap bp13 = new Bitmap(@"img\모험\쫄작영지.PNG", true);
            //Bitmap bp14 = new Bitmap(@"img\모험\마지막모험.PNG", true);
            //Bitmap bp15 = new Bitmap(@"img\모험\시작하기.PNG", true);

            //textBox1.Text += "이미지 찾지 못함 or 오류3_3" + "\r\n";

            bitMapList.Add(bp0);

            bitMapList.Add(bp1);

            bitMapList.Add(bp2);
            bitMapList.Add(bp3);

            bitMapList.Add(bp4);
            bitMapList.Add(bp5);
            bitMapList.Add(bp6);
            bitMapList.Add(bp7);
            bitMapList.Add(bp8);

            //textBox1.Text += "이미지 찾지 못함 or 오류4" + "\r\n";

            int i = 0; //int i,j =0 이 안되나?
            int j = 0;
            int k = 0;
            int stack = 0;
            String b;

            while (i == 0 && j == 0 && stack != 10)
            {
                b = "[모험\\시작]";
                i = searchIMGClick(0, b);
                j = searchIMGClick(1, b);
                stack++;
                Delay(500);
                //textBox1.AppendText("이미지 찾지 못함 or 오류5" + "\r\n");
            }
            if (stack == 10)
            {
                textBox1.AppendText("마을\\모험 이미지 찾지 못함" + "\r\n");
                return;
            }
            Delay(a);

            if (i == 1 || j == 1)
            {
                b = "[모험\\모험]";
                i = j = k = stack = 0;
                while (i == 0 && stack != 10)
                {
                    i = searchIMGClick(2, b); //모험클릭
                    stack++;
                    Delay(500);
                }
                if (stack == 10)
                {
                    textBox1.AppendText("마을\\모험\\모험 이미지 찾지 못함" + "\r\n");
                    return;
                }
                Delay(a);

                b = "[모험\\모험\\마지막모험]";
                i = j = k = stack = 0;
                while (i == 0 && stack != 10)
                {
                    i = searchIMGClick(5, b); //모험클릭
                    stack++;
                    Delay(500);
                }
                if (stack == 10)
                {
                    textBox1.AppendText("모험\\마지막모험 이미지 찾지 못함" + "\r\n");
                    return;
                }
                Delay(a);

                b = "[모험\\시작하기]";
                i = j = k = stack = 0;
                while (i == 0 && stack != 10)
                {
                    i = searchIMGClick(6, b); //모험클릭
                    stack++;
                    Delay(500);

                    //자동모험 활성 체크
                    //3배 모드 활성 체크
                    //쫄 1렙 체크
                    //최대 장비, 영웅, 원소 등 체크
                }
                if (stack == 10)
                {
                    textBox1.AppendText("모험\\시작하기 이미지 찾지 못함" + "\r\n");
                    return;
                }

                //b = "[모험\\모험진입]";
                i = j = k = stack = 0;
                while (i == 0 && stack != 20)
                {
                    textBox1.AppendText("테스트" + "\r\n");
                    b = "[모험\\모험진입]";
                    i = searchIMGClick(7, b);
                    stack++;
                    Delay(500);
                }
                if (stack == 20)
                {
                    textBox1.AppendText("진입 못 했거나 이미지 찾지 못함" + "\r\n");
                    return;
                }

                b = "[모험\\2_2라운드]";
                i = j = k = stack = 0;
                while (i == 0 && stack != 40)
                {
                    i = searchIMGAdv(1, 323, 50, 642, 537);
                    stack++;
                    Delay(500);
                }
                if (i == 1)
                {
                    //설정한 거 클릭하기
                    마우스클릭(555, 471);//1-1 스킬 클릭
                }
                if (stack == 40)
                {
                    textBox1.AppendText("진입 못 했거나 이미지 찾지 못함2" + "\r\n");
                    return;
                }
                textBox1.AppendText("테스트" + "\r\n");
                return;

            }
            ////모험 돌기

            /*마을 모험 클릭
             * 모험/쫄작영지 클릭
             * 최근 모험 클릭
             * int t = 0;
             * 입력한 값 t = 2;
             * int r = 0;
             * while(r<t)
             * {
             *          int i = 0;
             *          int j = 0;
             *          int k = 0;
             *          int l = 0;
             *          int s = 0;
             *          int y = 0;
             *          while(l<3 && s==0)
             *          {
             *              i = 여자업적_1
             *              j = 여자업적_2
             *              k = 여자업적_3
             *              l = i + j + k
             *              s = 시작 버튼 찾기
             *          }
             *          

             *      if (l==3)
             *      {
             *          쫄교체 프로세스+쫄소환 프로세스
             *      }
             *      s = 0
             *      while(s==0)
             *      {
             *          s = 시작 버튼 찾기 클릭
             *      }
             *      // 1_2라운드 찾기,영웅 최대, 장비 최대, 영웅 조각 최대, 원소 최대, 펫 최대 찾기
             *      i = j = k = l = s = y = 0;
             *      while (i==0)
             *      {
             *          i = 1_2라운드 찾기
             *          j = 영웅 최대
             *          k = 장비 최대
             *          l = 영웅 조각 최대
             *          s = 원소 최대
             *          y = 펫 최대 찾기
             *      }
             *      if (j==1)
             *      {
             *          영웅 최대 프로세스
             *      }
             *      else if (k==1)
             *      {
             *          장비 최대 프로세스
             *      }
             *      else if (l==1)
             *      {
             *          영웅 조각 최대 프로세스
             *      }
             *      else if (s==1)
             *      {
             *          원소 최대 프로세스
             *      }
             *      else if (y==1)
             *      {
             *          펫 최대 프로세스
             *      }else if (i==1)
             *      {
             *          자동 스킬 끄기
             *          2배 켜기
             *          1_2 라운드 스킬 쓰기
             *      }
             *      i = 0;
             *      while (i==0)
             *      {
             *          2_2 라운드 찾기
             *      }
             *      2_2 스킬 쓰기
             *      i= 0;
             *      while ( i==0) 
             *      {
             *          전투승리 찾기
             *      }
             *      i = 0;
             *      while (i==0)
             *      {
             *          다시하기 찾을 때 까지 중앙 클릭
             *          조각 찾기 체크
             *          돈 찾아서 체크
             *          캐릭터 카드 찾아서 체크
             *          펫 카드 찾아서 체크
             *          장비 찾아서 체크             *          
             *      }
             *      다시하기 클릭

             *      
             *      
             *          
             * }
             */
        }

        public static Image resizeImage(Image image)
        {
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

        private void button6_Click(object sender, EventArgs e) //캡쳐
        {
            Button btn = sender as Button;

            Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");

            IntPtr findwindow = FindWindow(null, AppPlayerName);
            if (AppPlayerName != "" && findwindow != IntPtr.Zero)
            {
                //플레이어를 찾았을 경우
                textBox1.AppendText("앱플레이어 찾았습니다.\r\n");
                Log(enLogLevel.Info, $"앱플레이어를 찾았습니다.");

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

                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                    pictureBox1.Image = null;
                }
                // pictureBox1 이미지를 표시해줍니다.
                pictureBox1.Image = bmp;
            }
            else
            {
                //플레이어를 못찾을경우
                textBox1.AppendText("앱플레이어 못 찾았어요.\r\n");
                Log(enLogLevel.Info, $"앱플레이어를 못 찾았습니다.");
            }
        }

        //setform 불러오기
        private void btnSet_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button; 

            Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");
            panel1.Controls.Clear();
            panel1.Controls.Add(ucPan2);
        } 


        #region Log OverLoading
        private void Log(enLogLevel eLevel, string LogDesc)
        {
            DateTime dTime = DateTime.Now;
            string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            ucPan1.lboxLog.Items.Insert(0, LogInfo);
        }
        private void Log(DateTime dTime, enLogLevel eLevel, string LogDesc)
        {
            string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            ucPan1.lboxLog.Items.Insert(0, LogInfo);
        }
        #endregion Log OverLoading

        private void btnSet2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Log(enLogLevel.Info, $"{btn.Text} 버튼 Click");
            panel1.Controls.Clear();
            panel1.Controls.Add(ucPan1);
            //panel1.Controls.Remove(ucPan2);
        }
    }
}