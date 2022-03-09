using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace The_Blue_Project
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
            

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {

            if(Name.Text != "" && Surname.Text != "")
            {
                

                StreamWriter Register = File.CreateText("test.txt");
                Register.WriteLine(Number.Text + "@");
                Register.WriteLine("Name :" + Name.Text + ";");
                Register.WriteLine("Surname :" + Surname.Text + ";");
                Register.WriteLine("Birth Date :" + DateOfBirth.Text + ";");
                Register.WriteLine("Adress :" + Adress.Text + ";");
                Register.WriteLine("Phone :" + Phone.Text + ";");
                Register.WriteLine("Registered on : " + DateTime.Now);
                Register.Close();


                StreamWriter saveFile = new StreamWriter(textBox1.Text + "_saveFile");
                saveFile.Close();

                StreamWriter LogFile = new StreamWriter(textBox1.Text + "_LogFile");
                LogFile.Close();


                int count = Convert.ToInt32(Number.Text);
                int NewCount = (count + 1);

                string newCount = Convert.ToString(NewCount);

                StreamWriter Count = File.CreateText("number.txt");
                Count.WriteLine(newCount);
                Count.Close();
                File.Move("test.txt", textBox1.Text);

                StreamReader list = new StreamReader("list.txt");
                string lists = list.ReadToEnd();
                list.Close();

                richTextBox1.Text = lists;

                StreamWriter newList = new StreamWriter("list.txt");
                string newLists = (richTextBox1.Text + Environment.NewLine + textBox1.Text);
                newList.WriteLine(newLists);
                newList.Close();

                

                label9.Visible = false;

                this.Close();

                MessageBox.Show("Account : " + Name.Text + " " + Surname.Text + " Created Succefully !");

                

            }

            else
            {
                label9.Visible = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int Count = Convert.ToInt32(File.ReadAllText("number.txt"));
            Number.Text = Convert.ToString(Count);
            
            textBox1.Text = (Number.Text + "-" + Name.Text + "-" + Surname.Text);
        }
    }
}
