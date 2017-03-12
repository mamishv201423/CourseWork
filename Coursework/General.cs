using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Coursework
{    
    public partial class General : Form
    {
        //Конструктор
        public General()
        {        
            InitializeComponent();
        }       
        
        //Button input to Personal cabinet
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && textBox2.Text != String.Empty)
            {
                Form2 newForm2 = new Form2();
                newForm2.Show();
            }            
        }

        //Button input to Registretion cabinet
        private void button2_Click(object sender, EventArgs e)
        {
            Registration newForm3 = new Registration();
            newForm3.Show();
            
        }
    }
}
