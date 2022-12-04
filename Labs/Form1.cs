using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Labs.Lab2_BattleShip.Views;
using Labs.Lab_4;

namespace Labs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        } 
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Lab_2 lab_2 = new Lab_2();
            lab_2.Show();
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Texr files(*.txt)|*.txt|All files(*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            string filename = saveFileDialog1.FileName;

            System.IO.File.WriteAllText(filename, textBox1.Text);
            MessageBox.Show("Файл сохранен");
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Texr files(*.txt)|*.txt|All files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            textBox1.Text = fileText;

            MessageBox.Show("Файл открыт");
        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void доп2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Lab_3 lab_3 = new Lab_3(this);
            lab_3.Show();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Lab3_1_2 lab_3_1_2 = new Lab3_1_2(this);
            lab_3_1_2.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Lab3_2 lab_3_2 = new Lab3_2(this);
            lab_3_2.Show();
        }

        private void familyTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lab3_tree lab3_tree = new Lab3_tree(this);
            lab3_tree.Show();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Lab4 lab4 = new Lab4(this);
            lab4.Show();
        }
    }
}
