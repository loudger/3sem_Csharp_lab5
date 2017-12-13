using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using DistanceLibrary;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> words = new List<string>();
      

        private void Form1_Load(object sender, EventArgs e)
        {
            //--
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //-
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();

            if (file.ShowDialog() == DialogResult.OK)
            {
                Stopwatch time = new Stopwatch();
                time.Start();

                string text = File.ReadAllText(file.FileName);
                char[] seps = new char[] { ' ', '.', ',', '!', '?', '/', '\t', '\n', '(', ')' };
                string[] textArray = text.Split(seps);
                foreach (string word in textArray)
                {
                    string trimmedWord = word.Trim();
                    if (!words.Contains(trimmedWord))
                    {
                        words.Add(trimmedWord);
                    }
                }
                richTextBox1.Text = text.ToString();
                time.Stop();
                label1.Text = "Затраченное время на загрузку файла: " + time.Elapsed.ToString();
            }
            else
            {
                MessageBox.Show("Что-то не так!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string wordToFind = textBox1.Text.Trim();
            textBox1.Text = wordToFind;
            int maxDistance = Convert.ToInt32(textBox2.Text);
            if (!string.IsNullOrEmpty(wordToFind) && words.Count > 0)
            {
                string wordToFindUpper = wordToFind.ToUpper();
                List<string> tempList = new List<string>();

                Stopwatch time = new Stopwatch();
                time.Start();

                foreach (string str in words)
                {
                    if (Distance.CalculateDistance(str.ToUpper(), wordToFindUpper) <= maxDistance)
                    {
                        tempList.Add(str);
                    }
                }

                time.Stop();
                label1.Text = "Затраченное время на поиск слова: " + time.Elapsed.ToString();
                listBox2.BeginUpdate();
                listBox2.Items.Clear();

                foreach (string str in tempList)
                {
                    listBox2.Items.Add(str);
                }
                listBox2.EndUpdate();
            }
            else
            {
                MessageBox.Show("Что-то не то!");
            }
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //-
        }

    }
}
