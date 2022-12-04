using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Labs.Lab_4
{
    public partial class Lab4 : Form
    {
        Form home_form;
        public string s;
        public MatchCollection myMatch;
        public string signatura;
        public string[] form = new string[] { "Lab_2.cs", "Lab_3.cs", "Lab3_1_2.cs", "Lab3_2.cs", "Lab3_tree.cs", "Lab4.cs"};
        public Lab4(Form1 HomeForm)
        {
            InitializeComponent();
            home_form = HomeForm;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;
            s = richTextBox1.Text;
            signatura = comboBox1.Text;

            MatchCollection matches = Class1.Find(s, signatura);
            myMatch = matches;
            textBox1.Text = "Все вхождения строки " + signatura + " в исходном тексте: " + "\r\n";
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    textBox1.Text += match.Index + "-ая позиция" + "\t" + match.Value + "\r\n";
                }
            }
            else
            {
                textBox1.Text = "Совпадений не найдено";
            }
        }

        Color[] myColor = new Color[] { Color.Red, Color.Blue, Color.Yellow, Color.Lime, Color.CadetBlue, Color.Gold, Color.Pink, Color.ForestGreen, Color.Indigo, Color.Cyan, Color.Orange, Color.LightSalmon };

        int col = 0;
        private void SetSelectionStyle(int startIndex, int lenght, FontStyle style)
        {
            richTextBox1.Select(startIndex, lenght);
            richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, richTextBox1.SelectionFont.Style | style);
            richTextBox1.SelectionColor = myColor[col % 12];
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Select(0, richTextBox1.MaxLength);
            richTextBox1.SelectionColor = Color.Black;
            s = richTextBox1.Text;
            signatura = comboBox1.Text;
            MatchCollection matches = Class1.Find(s, signatura);
            myMatch = matches;
            foreach (Match m in myMatch)
            {
                SetSelectionStyle(m.Index, m.Length, FontStyle.Regular);
            }
            col++;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int count = 0;
            bool check = false;
            richTextBox1.Select(0, richTextBox1.MaxLength);
            richTextBox1.SelectionColor = Color.Black;
            textBox1.Text = "";
            s = richTextBox1.Text;
            for (int i = 0; i < form.Length; i++)
            {
                MatchCollection matches = Class1.Find(s, form[i]);
                myMatch = matches;
                if (matches.Count > 0)
                {
                    foreach (Match m in myMatch)
                    {
                        SetSelectionStyle(m.Index, m.Length, FontStyle.Regular);
                        count++;
                    }
                    check = true;
                    textBox1.Text += "Исключение появлялось в форме " + form[i] + " " + count + " раз\r\n";
                    count = 0;
                }

            }
            if (check != true)
            {
                textBox1.Text = "Исключений в формах не обнаруженно";
            }
            col++;

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            richTextBox1.Select(0, richTextBox1.MaxLength);
            richTextBox1.SelectionColor = Color.Black;
            int pos = (int)numericUpDown1.Value;
            int count = 0;
            s = richTextBox1.Text;
            MatchCollection matches = Class1.Find(s, "stringtonumber");
            foreach (Match m in matches)
            {
                if (count >= pos)
                    SetSelectionStyle(m.Index, m.Length, FontStyle.Regular);
                count++;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Parse("27-11-2022");

            DateTime endDate = DateTime.Parse("30-11-2022"); 
            s = richTextBox1.Text;
            MatchCollection matches = Class1.Date(s);
            foreach (Match match in matches)
            {
                DateTime dateTime = DateTime.Parse(match.Value.Replace(".", "-"));
                if (dateTime > startDate && dateTime < endDate)
                {
                    SetSelectionStyle(match.Index, match.Length, FontStyle.Regular);
                    String extraText = "\\egor";
                    richTextBox1.Select(match.Index + match.Length, 1);
                    richTextBox1.SelectedText = extraText;
                    SetSelectionStyle(match.Index + (extraText.Length - 1), extraText.Length - 1, FontStyle.Regular);
                }
            }
        }
    }
}
