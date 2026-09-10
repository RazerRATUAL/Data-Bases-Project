using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;


namespace ProiectBazeDeDate
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        private void btnDA_Click(object sender, EventArgs e)
        {
            Process.Start("https://youtu.be/CaLYRpvWUGQ?si=oqe0rgNw7Kv5fjYI");
            Environment.Exit(0);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Process.Start("shutdown.exe", "/s /t 0");
        }
    }
}
