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

namespace Library_Manager_Lite
{
    public partial class work : Form
    {
        public work()
        {
            InitializeComponent();


            listBox1.Items.Clear();

            StreamReader list = new StreamReader("list.txt");
            string lists = list.ReadToEnd();
            richTextBox1.Text = lists;

            if (richTextBox1.Lines.Length > 0)
            {
                listBox1.Items.AddRange((object[])richTextBox1.Lines);
            }

            listBox1.SetSelected(0, true);

        }



        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            StreamReader list = new StreamReader("list.txt");
            string lists = list.ReadToEnd();
            richTextBox1.Text = lists;

            if (richTextBox1.Lines.Length > 0)
            {
                listBox1.Items.AddRange((object[])richTextBox1.Lines);
            }

            listBox1.SetSelected(0, true);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox3.Items.Clear();


            textBox1.Text = listBox1.SelectedItem.ToString();

            StreamReader readText = new StreamReader(textBox1.Text + "_saveFile");
            richTextBox2.Text = readText.ReadToEnd();
            readText.Close();

            listBox2.Items.AddRange((object[])richTextBox2.Lines);

            StreamReader LogText = new StreamReader(textBox1.Text + "_LogFile");
            richTextBox2.Text = LogText.ReadToEnd();
            LogText.Close();

            listBox3.Items.AddRange((object[])richTextBox2.Lines);


            // Supprimer les lignes vides dans listBox1
            for (int i = listBox1.Items.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(listBox1.Items[i].ToString()))
                    listBox1.Items.RemoveAt(i);
            }
            for (int i = listBox2.Items.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(listBox2.Items[i].ToString()))
                    listBox2.Items.RemoveAt(i);
            }

            // Supprimer les lignes vides dans listBox3
            for (int i = listBox3.Items.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(listBox3.Items[i].ToString()))
                    listBox3.Items.RemoveAt(i);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != "")
            {
                listBox2.Items.Add(textBox2.Text);

                listBox3.Items.Add("Taked : " + textBox2.Text + " : " + DateTime.Now);
                textBox2.Text = "";

                


            }
            else
            {
                MessageBox.Show("please Enter a text !");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                EditBox.Visible = true;
                Group2.Visible = true;
            
            }
            else
            {
                EditBox.Visible = false;
                Group2.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }



        private void Save_Click(object sender, EventArgs e)
        {
            string SaveFileName = (textBox1.Text + "_saveFile");
            string LogFileName = (textBox1.Text + "_LogFile");

            StreamWriter SaveFile = new StreamWriter(SaveFileName);

            foreach (var SaveItem in listBox2.Items)
                SaveFile.WriteLine(SaveItem);
                SaveFile.Close();

            StreamWriter LogFile = new StreamWriter(LogFileName);

            foreach (var LogItem in listBox3.Items)
                LogFile.WriteLine(LogItem);
                LogFile.Close();


        }



        private void button4_Click(object sender, EventArgs e)
        {
            listBox3.Items.Add("Back : " + listBox2.SelectedItem.ToString() + " : " + DateTime.Now);

            listBox2.Items.Remove(listBox2.SelectedItem);

            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox3.Items.Remove(listBox3.SelectedItem);
        }

        private void work_Load(object sender, EventArgs e)
        {

        }

        private void work_FormClosing(object sender, FormClosingEventArgs e)
        {
            Save_Click(sender, e);

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
