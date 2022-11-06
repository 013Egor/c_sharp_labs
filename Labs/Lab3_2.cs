using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labs
{
    public partial class Lab3_2 : Form
    {
        Pen myPen = new Pen(Color.Black);
        Font drawFont = new Font("Arial", 16);
        SolidBrush drawBrush = new SolidBrush(Color.Black);
        public Lab3_2(Form1 home)
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
            int[] abc = new int[(int)numericUpDown1.Value];
            Random random = new Random();
            for (int i = 0; i < abc.Length; i++)
            {
                abc[i] = random.Next(0, 100);
            }
            Graphics g = pictureBox1.CreateGraphics();
           
            MessageBox.Show(minimum(abc.Length - 1, abc, 0, g) + "");
            
            
        }
        private int minTwo(int a, int b)
        {

            return a < b ? a : b;
        }
        private int minimum(int id, int[] array, int level, Graphics g)
        {
            
            String res = "";
            for (int i = 0; i <= id; i++)
            {
               res += array[i] + " ";
            }
            g.DrawString(res,drawFont, drawBrush, 10, level*30);
            if (id == 1)
            {
                int temp = minTwo(array[id], array[0]);
                g.DrawString(" | " + array[id] + " <--> " + array[0] + " ==> " + temp, drawFont, drawBrush, (id + 3) * 30, level * 30);

                return temp;
            }
            else
            {
                int at = minimum(id - 1, array, level + 1, g);

                int ff = minTwo(array[id], at);
                g.DrawString(" | " + array[id] + " <--> " + at + " ==> " + ff, drawFont, drawBrush, (id + 3) * 30, level * 30);
                return ff;
            }

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int size = (int)numericUpDown1.Value;
            pictureBox1.Height = 30 * size;
            pictureBox1.Width = 30 * (size + 3) + 200;
            Size f = new Size();
            f.Height = 30 * (size + 3);
            f.Width = 30 * (size + 4) + 200;
            ClientSize = f;
        }
    }
}
