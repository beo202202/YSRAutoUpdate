using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Devil2.ucPanel
{
    public partial class ucPanel2 : UserControl
    {
        public event delLogSender eLogSender;

        public ucPanel2()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            eLogSender("ucPanel2 Button", enLogLevel.Info, "Button Click");
        }
    }
}
