using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zmeykajopika
{
    public partial class SettingsForm : Form
    {
        Timer timer;
        public SettingsForm(Controller controller, Timer timer)
        {
            InitializeComponent();
            this.timer = timer;
            trackBar1.Value = timer.Interval;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Interval = trackBar1.Value;
            Close();
        }
    }
}
