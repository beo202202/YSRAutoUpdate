using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devil2
{
    // 델리게이트 선언
    public delegate void StrAddHandler(String str);

    partial class LogClass
    {
        // panel 선언
        ucPanel.ucPanel1 ucPan1 = new ucPanel.ucPanel1();
        ucPanel.ucPanel2 ucPan2 = new ucPanel.ucPanel2();

        //ucPan1.eLogSender += ucPan1_eLogSender;

        // 필드
        //private DateTime dTime; // = DateTime.Now;        
        private enLogLevel eLevel;
        private string LogDesc;
        private string LogInfo;

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

            string LogInfo = $"{dTime:MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {message}";

            // as 연산자는 형변환에 성공하면 해당 타입을, 실패하면 null을 반환합니다.
            if (lBoxLog != null)
            {
                lBoxLog.Items.Insert(0, LogInfo);
                //lBoxLog.Text = message;
                //MessageBox.Show(LogInfo);
            }
            //MessageBox.Show(box.ToString());
        }

        

        /*
        // 프로퍼티
        public DateTime Dtime
        {
            get { return dTime; }
            set { dTime = DateTime.Now; }
        }
        
        public enLogLevel Elevel
        {
            get { return eLevel; }
            set { eLevel = value; }
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
        public String Log(string LogDesc)
        {
            Main m = new Main();

            DateTime dTime = DateTime.Now;
            //string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            string LogInfo = $"{dTime:MM-dd hh:mm:ss.fff} [Info] {LogDesc}";
            //MessageBox.Show("LogInfo : " + LogInfo);

            return LogInfo;

            //왜 판넬로 안넘어가는걸까! 판넬 포기
            //m.lboxLog.Items.Insert(0, LogInfo);
            //m.lboxLog.Items.Clear();
        }
        public String Log(enLogLevel eLevel, string LogDesc)
        {
            Main m = new Main();

            DateTime dTime = DateTime.Now;
            //string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            string LogInfo = $"{dTime:MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            //MessageBox.Show("LogInfo : " + LogInfo);

            return LogInfo;

            //왜 판넬로 안넘어가는걸까! 판넬 포기
            //m.lboxLog.Items.Insert(0, LogInfo);
            //m.lboxLog.Items.Clear();
        }
        public void Log(DateTime dTime, string LogDesc)
        {
            string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            ucPan1.lboxLog.Items.Insert(0, LogInfo);
        }
        #endregion

    }
}
