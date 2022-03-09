using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Blue_Project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            textBox1.Text = File.ReadAllText("number.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            registerForm register = new registerForm();
            register.ShowDialog();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = File.ReadAllText("number.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List list = new List();
            list.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            work work = new work();
            work.ShowDialog();
        }
    }
}
