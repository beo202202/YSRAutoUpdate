using OpenCvSharp;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace YSR
{
    // 델리게이트 선언
    //public delegate void StrAddHandler(String str);

    partial class LogClass
    {
        //ucPan1.eLogSender += ucPan1_eLogSender;

        // 필드
        //private DateTime dTime; // = DateTime.Now;        
        private enLogLevel eLevel;
        //private string LogDesc;
        //private string LogInfo;

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

        // 메서드를 하나 만들어 기능을 제공합니다.
        public void SetText(object box, string message)
        {
            // 전달된 매개 변수를 TextBox로 형변환 합니다.
            TextBox textBox = box as TextBox;

            // as 연산자는 형변환에 성공하면 해당 타입을, 실패하면 null을 반환합니다.
            if (textBox != null)
            {
                textBox.Text = message;
            }
        }

        // 메서드를 하나 만들어 기능을 제공합니다.
        public void Log(object box, string message)
        {
            // 전달된 매개 변수를 TextBox로 형변환 합니다.
            ListBox lBoxLog = box as ListBox;
            DateTime dTime = DateTime.Now;

            //MessageBox.Show(lBoxLog.ToString());

            //ListBox lBoxLog = (ListBox) $"System.Windwos.Forms.ListBox, Items.Count: 0";

            //string LogInfo = $"{dTime:MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {message}";
            //string LogInfo = $"{dTime:hh:mm:ss.fff} [{eLevel.ToString()}] {message}";
            string Log1 = $"[{dTime:hh:mm:ss.fff}]";
            string Log2 = message;

            // 로그 저장하기

            // 파일이 있는 지, 없는지 + 그 파일이 해당 날짜에 맞아야함.
            // 없으면 만들기

            string DirPath = Environment.CurrentDirectory + @"\Log";
            string FilePath = DirPath + "\\Log_" + DateTime.Today.ToString("yyyyMMdd") + ".log";
            string temp;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            try
            {
                if (!di.Exists) Directory.CreateDirectory(DirPath);
                if (!fi.Exists)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, message);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        temp = string.Format("[{0}] {1}", DateTime.Now, message);
                        sw.WriteLine(temp);
                        sw.Close();
                    }
                }
            }
            catch
            {

            }

            //FileInfo file = new FileInfo(Application.StartupPath + "\\test\\test.txt");
            //if (!file.Exists)  //해당 파일이 없으면 생성하고 파일 닫기
            //{
            //    FileStream fs = file.Create();
            //    fs.Close();
            //}

            //// 해당 파일에 내용을 추가적으로 작성하자 (기존 내용 초기화 X)
            //File.AppendAllText(Application.StartupPath + "\\test\\test.txt", "내용");



            // 로그 보여주기
            // as 연산자는 형변환에 성공하면 해당 타입을, 실패하면 null을 반환합니다.
            if (lBoxLog != null)
            {
                if (lBoxLog.InvokeRequired == true)
                {
                    lBoxLog.Invoke((MethodInvoker)delegate
                    {
                        lBoxLog.Items.Insert(0, string.Format("{0}{1}", Log1.PadRight(15), Log2));
                        Delay(100);
                    });
                }
                else
                {
                    lBoxLog.Items.Insert(0, string.Format("{0}{1}", Log1.PadRight(15), Log2));
                    Delay(100);
                }
                //lBoxLog.Items.Insert(0, LogInfo);
                //lBoxLog.Items.Insert(0, string.Format("{0}{1}", Log1.PadRight(15), Log2));
                //Delay(100);
                //lBoxLog.Text = message;
                //MessageBox.Show(LogInfo);
            }
            //MessageBox.Show(box.ToString());
        }

        // 프로퍼티
        public enLogLevel Elevel
        {
            get { return eLevel; }
            set { eLevel = value; }
        }
        /*
        
        public DateTime Dtime
        {
            get { return dTime; }
            set { dTime = DateTime.Now; }
        }
        
        

        public string Logdesc
        {
            get { return LogDesc; }
            set { LogDesc = value; }
        }

        public string Loginfo
        {
            get { return LogInfo; }
            set { LogInfo = $"{dTime:MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}"; }
        }
        */

        #region Log OverLoading
        // 메서드
        //public String Log(string LogDesc)
        //{
        //    Main m = new Main();

        //    DateTime dTime = DateTime.Now;
        //    //string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
        //    string LogInfo = $"{dTime:MM-dd hh:mm:ss.fff} [Info] {LogDesc}";
        //    //MessageBox.Show("LogInfo : " + LogInfo);

        //    return LogInfo;

        //    //왜 판넬로 안넘어가는걸까! 판넬 포기
        //    //m.lboxLog.Items.Insert(0, LogInfo);
        //    //m.lboxLog.Items.Clear();
        //}
        //public String Log(enLogLevel eLevel, string LogDesc)
        //{
        //    Main m = new Main();

        //    DateTime dTime = DateTime.Now;
        //    //string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
        //    string LogInfo = $"{dTime:MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
        //    //MessageBox.Show("LogInfo : " + LogInfo);

        //    return LogInfo;

        //    //왜 판넬로 안넘어가는걸까! 판넬 포기
        //    //m.lboxLog.Items.Insert(0, LogInfo);
        //    //m.lboxLog.Items.Clear();
        //}
        //public void Log(DateTime dTime, string LogDesc)
        //{
        //    string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
        //    ucPan1.lboxLog.Items.Insert(0, LogInfo);
        //}
        #endregion

    }
}
