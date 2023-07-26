using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devil2
{
    partial class LogClass
    {
        // panel 선언
        ucPanel.ucPanel1 ucPan1 = new ucPanel.ucPanel1();
        ucPanel.ucPanel2 ucPan2 = new ucPanel.ucPanel2();

        
        //ucPan1.eLogSender += ucPan1_eLogSender;

        // 필드
        private DateTime dTime; // = DateTime.Now;        
        private enLogLevel eLevel;
        private string LogDesc;
        private string LogInfo;

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

        #region Log OverLoading
        // 메서드
        public void Log(enLogLevel eLevel, string LogDesc)
        {
            //DateTime dTime = DateTime.Now;
            //string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            string LogInfo = $"{dTime:MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            MessageBox.Show(eLevel.ToString());
            MessageBox.Show(LogDesc);
            ucPan1.lboxLog.Items.Insert(0, LogInfo);
        }
        public void Log(DateTime dTime, enLogLevel eLevel, string LogDesc)
        {
            string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            ucPan1.lboxLog.Items.Insert(0, LogInfo);
        }
        #endregion

        /*
        #region del Event
        private void UcPan_eLogSender(object oSender, enLogLevel eLevel, string strLog)
        {
            Log(eLevel, $"[{oSender.ToString()}] {strLog}");
            //throw new NotImplementedException();
        }
        #endregion
        */

        /*
        public void Log(enLogLevel eLevel, string LogDesc)
        {
            //DateTime dTime = DateTime.Now;
            //string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            //string LogInfo = $"{dTime:MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            ucPan1.lboxLog.Items.Insert(0, LogInfo);
        }
        public void Log(DateTime dTime, enLogLevel eLevel, string LogDesc)
        {
            string LogInfo = $"{dTime:yyyy-MM-dd hh:mm:ss.fff} [{eLevel.ToString()}] {LogDesc}";
            ucPan1.lboxLog.Items.Insert(0, LogInfo);
        }
        */

    }
}
