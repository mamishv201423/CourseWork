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
    //Структура по созданию панели с данными
    public struct KnowLP
    {
        //Панели с данными
        public Panel panel;
        public string name;
        public string login;
        public string password;


        public void AddPanel(Panel _panel)
        {
            panel = _panel;
        }

        public void AddLP(string _name, string _login, string _password)
        {
            name = _name;
            login = _login;
            password = _password;
        }
    }

    public partial class Form2 : Form
    {
        private List<KnowLP> VectorKnowLP = new List<KnowLP>();
        private List<KnowLP> VectorKnowLPWrite = new List<KnowLP>();
        private int CountName = 0;
        private int CountLabel;
        public Form2()
        {
            InitializeComponent();
            ReadFile();
            CountLabel = 1 + CountName;
            NewPanelForm();           
        }

        TextBox textbox1 = new TextBox();
        TextBox textbox2 = new TextBox();
        TextBox textbox3 = new TextBox();

        private void ReadFile()
        {
            String line;
            using (StreamReader sr = new StreamReader("FileLP.txt"))
            {
                line = sr.ReadToEnd();
            }
            if (!(String.IsNullOrEmpty(line)))
            {
                string[] MassString = line.Split(' ', '\t');
                for (int i = 0; i < MassString.Length; i += 3)
                {
                    KnowLP _KnowLP = new KnowLP();
                    _KnowLP.AddLP(MassString[i], MassString[i + 1], MassString[i + 2]);
                    VectorKnowLP.Add(_KnowLP);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {                   
            //Создаём или перезаписываем существующий файл

            //StreamWriter sw = File.CreateText("FileLP.txt");
            
            //Записываем текст в поток файла
            //KnowLP _KnowLPWrite = new KnowLP();
            //_KnowLPWrite.AddLP(textbox1.Text, textbox2.Text, textbox3.Text);
            //VectorKnowLPWrite.Add(_KnowLPWrite);
            string[] str = new string[3];            
                str[0] = textbox1.Text;
                str[1] = textbox2.Text;
                str[2] = textbox3.Text;
            System.IO.File.WriteAllLines("FileLP.txt", str);
            //for (int i = 0; i < 3; i++)
            //{
            //    if (i != 2)
            //    {
            //        sw.Write(str[i] + "\t");
            //    }
            //    else sw.Write(str[i]);
            //}
            
            //SaveFileDialog sfd = new SaveFileDialog();
            //File.WriteAllText(sfd.FileName, textbox1.Text + "\t" + textbox2.Text + "\t" + textbox3.Text + "\t");
            
            //Закрываем файл
            //sw.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            CreateNewPanelForm(1);
        }
        private void NewPanelForm()
        {
            if (VectorKnowLP.Count != 0)
            {
                for (int i = 0; i < VectorKnowLP.Count; i++)
                {
                    Panel panel1 = new Panel();
                    Label LName = new Label();
                    Label LLogin = new Label();
                    Label LPassword = new Label();
                    Label label1 = new Label();
                    Label label2 = new Label();
                    Label label3 = new Label();

                    // Initialize the Panel control.
                    panel1.Location = new Point((((i % 3) * (10 + 264 + 20)) + (10)), (((i / 3) * (10 + 152 + 20)) + (10)));
                    panel1.Size = new Size(250, 150);
                    // Set the Borderstyle for the Panel to three-dimensional.
                    panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    panel1.BackColor = System.Drawing.Color.LightSalmon;

                    label1.Text = "Name:";
                    label1.Font = new Font("Name", 12, FontStyle.Bold);
                    label1.Location = new Point(5, 5);
                    label1.Size = new Size(100, 20);

                    label2.Text = "Login:";
                    label2.Font = new Font("Lodin", 12, FontStyle.Bold);
                    label2.Location = new Point(5, 55);
                    label2.Size = new Size(100, 20);

                    label3.Text = "Password:";
                    label3.Font = new Font("Password", 12, FontStyle.Bold);
                    label3.Location = new Point(5, 110);
                    label3.Size = new Size(100, 20);

                    // Initialize the Lable controls.
                    LName.Text = VectorKnowLP[i].name;
                    LName.Font = new Font("Name", 12, FontStyle.Bold);
                    LName.Location = new Point(120, 5);
                    LName.Size = new Size(115, 20);

                    LLogin.Text = VectorKnowLP[i].login;
                    LLogin.Font = new Font("Name", 12, FontStyle.Bold);
                    LLogin.Location = new Point(120, 55);
                    LLogin.Size = new Size(115, 20);

                    LPassword.Text = VectorKnowLP[i].password;
                    LPassword.Font = new Font("Password", 12, FontStyle.Bold);
                    LPassword.Location = new Point(120, 110);
                    LPassword.Size = new Size(115, 20);

                    VectorKnowLP[i].AddPanel(panel1);


                    // Add the Panel control to the form.
                    Controls.Add(panel1);
                    // Add the Button controls to the Panel.
                    panel1.Controls.AddRange(new Control[] { LName, LLogin, LPassword });
                    panel1.Controls.AddRange(new Control[] { label1, label2, label3 });
                }                
            }
            CreateNewPanelForm(0);
        }
        private void CreateNewPanelForm (int k)
        { 
            Panel panel2 = new Panel();
            Label label12 = new Label();
            Label label22 = new Label();
            Label label32 = new Label();
            Button button1 = new Button();
            Button button2 = new Button();

            int j = VectorKnowLP.Count + k;
            panel2.Location = new Point((((j % 3) * (10 + 264 + 20)) + (10)), (((j / 3) * (10 + 152 + 20)) + (10)));
            panel2.Size = new Size(250, 150);
            // Set the Borderstyle for the Panel to three-dimensional.
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            panel2.BackColor = System.Drawing.Color.LightSalmon;

            label12.Text = "Name:";
            label12.Font = new Font("Name", 12, FontStyle.Bold);
            label12.Location = new Point(5, 5);
            label12.Size = new Size(100, 20);

            label22.Text = "Login:";
            label22.Font = new Font("Lodin", 12, FontStyle.Bold);
            label22.Location = new Point(5, 55);
            label22.Size = new Size(100, 20);

            label32.Text = "Password:";
            label32.Font = new Font("Password", 12, FontStyle.Bold);
            label32.Location = new Point(5, 110);
            label32.Size = new Size(100, 20);

            textbox1.Text = "";
            textbox1.Font = new Font("Name", 12, FontStyle.Bold);
            textbox1.Location = new Point(120, 5);
            textbox1.Size = new Size(115, 20);

            textbox2.Text = "";
            textbox2.Font = new Font("Name", 12, FontStyle.Bold);
            textbox2.Location = new Point(120, 55);
            textbox2.Size = new Size(115, 20);

            textbox3.Text = "";
            textbox3.Font = new Font("Password", 12, FontStyle.Bold);
            textbox3.Location = new Point(120, 110);
            textbox3.Size = new Size(115, 20);

            button1.Text = "Add to File";
            button1.Font = new Font("button1", 12, FontStyle.Bold);
            button1.Location = new Point((((j % 3) * (10 + 264 + 20)) + (10)), (((j / 3) * (10 + 152 + 20)) + (150 + 10)));
            button1.Size = new Size(250, 40);
            button1.BackColor = System.Drawing.Color.LightSalmon;
            button1.MouseClick += button1_Click;

            button2.Text = "New Panel";
            button2.Font = new Font("button2", 12, FontStyle.Bold);
            button2.Location = new Point((((j % 3) * (10 + 264 + 20)) + (10)), (((j / 3) * (10 + 152 + 20)) + (190 + 10)));
            button2.Size = new Size(250, 40);
            button2.BackColor = System.Drawing.Color.LightSalmon;
            button2.MouseClick += button2_Click;

            Controls.Add(panel2);
            Controls.AddRange(new Control[] { button1, button2 });
            // Add the Button controls to the Panel.
            panel2.Controls.AddRange(new Control[] { label12, label22, label32 });
            panel2.Controls.AddRange(new Control[] { textbox1, textbox2, textbox3 });
        }
    }
}
