using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace YSR
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>=
        /// ication.Run(new Main());  
        [STAThread]
        //중복방지하기
        static void Main()
        {
            try
            {
                int cnt = 0;

                Process[] procs = Process.GetProcesses();

                foreach (Process p in procs)
                {
                    if (p.ProcessName.Equals("YSR") == true) // YSRAutoUpdate로 바꿔야하나... 확인..해야함.                                    
                        cnt++;
                }
                if (cnt > 1)
                {
                    MessageBox.Show("이미 실행중입니다.");
                    return;
                }
                else
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new Main());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Program - Error");
            }
        }
    }
}
