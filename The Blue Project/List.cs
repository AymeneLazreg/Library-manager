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
    public partial class List : Form
    {
        public List()
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
            if(listBox1.SelectedItem.ToString() != "")
            {
                string selectedItem = listBox1.SelectedItem.ToString();

                if (File.Exists(selectedItem))
                {
                    StreamReader info = new StreamReader(selectedItem);
                    richTextBox2.Text = info.ReadToEnd();
                    info.Close();

                    label1.Visible = false;
                }
                else
                {
                    label1.Visible = true;
                }


                string Data = richTextBox2.Text;
                richTextBox3.Text = Data;

                if (richTextBox3.Lines.Length > 0)
                {
                    listBox2.Items.AddRange((object[])richTextBox3.Lines);
                }


                string checkbox_value = richTextBox3.Text;
                char[] splitters = new char[] { ':' };
                string[] laCase = checkbox_value.Split(splitters);



                char[] splitters2 = new char[] { ';' };

                string Name_value2 = laCase[1];
                string Surname_value2 = laCase[2];
                string Date_value2 = laCase[3];
                string Adress_value2 = laCase[4];
                string Phone_value2 = laCase[5];



                string[] NameNew = Name_value2.Split(splitters2);
                string[] SurnameNew = Surname_value2.Split(splitters2);
                string[] DateNew = Date_value2.Split(splitters2);
                string[] AdressNew = Adress_value2.Split(splitters2);
                string[] PhoneNew = Phone_value2.Split(splitters2);

                Name.Text = NameNew[0];
                Surname.Text = SurnameNew[0];
                DateOfBirth.Text = DateNew[0];
                Adress.Text = AdressNew[0];
                Phone.Text = PhoneNew[0];


                char[] splitterNumber = new char[] { '@' };
                string[] NumberSplit = checkbox_value.Split(splitterNumber);
                string Number_value2 = NumberSplit[0];

                Number.Text = Number_value2;

                CurrentName.Text = listBox1.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Please Select a Valid User !");
                listBox1.SelectedItems.Remove("");
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
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

        

        private void ApplyChanges_Click(object sender, EventArgs e)
        {
            if (Name.Text != "" && Surname.Text != "")
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





                File.Delete(CurrentName.Text);
                
                File.Move("test.txt", CurrentName.Text);

                
                    


                label1.Visible = false;

                

                MessageBox.Show("Account : " + Name.Text + " " + Surname.Text + " Modified Succefully !");

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem.ToString() != "")
            {
                button1.PerformClick();
            }
        }
    }
}
