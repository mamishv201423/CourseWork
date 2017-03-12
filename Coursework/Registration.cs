using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursework
{
    public partial class Registration : Form
    {
        //Конструктор
        public Registration()
        {
            InitializeComponent();
        }

        //Registration to be available succesful
        private void button1_Click(object sender, EventArgs e)
        {
            Registration newForm3 = new Registration();
            FileInfo RegistrationFile = new FileInfo(@"E:\KI 14-4\The third course\C#\Coursework\Coursework\bin\RegistrationFile.txt");
            FileStream fstr = RegistrationFile.Create();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "txt files (*.txt) | *.txt | All files(*.*) | *.* ";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, textBox1.Text + "\t" + textBox2.Text + "\t" + textBox3.Text + "\t" + textBox4.Text + "\t" + textBox5.Text);
            }
            //fstr.Write(textBox1.Text + "\t" + textBox2.Text + "\t" + textBox3.Text + "\t" + textBox4.Text + "\t" + textBox5.Text);
            fstr.Close();
        }
    }
}
