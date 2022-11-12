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
using System.Drawing.Drawing2D;

namespace Labs
{
    public partial class Lab_3 : Form
    {
        private int mode;
        private Point movePt;
        private Point nullPt = new Point(int.MaxValue, 0);

        private SolidBrush brush = new SolidBrush(Color.Transparent);
        private Pen pen = new Pen(Color.Black);
        private Point startPt;

        int A = 50;
        int F = 1;
        int nterms = 1;

        private Form1 form1;
        public Lab_3(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            openFileDialog1.InitialDirectory = saveFileDialog1.InitialDirectory = Directory.GetCurrentDirectory();
            pen.StartCap = pen.EndCap = LineCap.Round;
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
       
        private void Lab_3_Load(object sender, EventArgs e)
        {

        }

       private void button1_Click(object sender, EventArgs e)
       {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            g.Dispose();
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = openFileDialog1.FileName;
                try
                {
                    Image im = new Bitmap(s);
                    Graphics g = Graphics.FromImage(im);
                    g.Dispose();
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    pictureBox1.Image = im;
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Файл" + s + "недопустимый формат", "Ошибка");
                    form1.textBox1.AppendText(exc.StackTrace);
                    return;
                }
                pictureBox1.Image = new Bitmap(s);
                Text = "Редактор изображения";
                saveFileDialog1.FileName = Path.ChangeExtension(s, "png");
                openFileDialog1.FileName = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s0 = saveFileDialog1.FileName;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = saveFileDialog1.FileName;
                if (s.ToUpper() == s0.ToUpper())
                {
                    s0 = Path.GetDirectoryName(s0) + "\\($$##$$).png";
                    pictureBox1.Image.Save(s0);
                    pictureBox1.Image.Dispose();

                    File.Delete(s);
                    File.Move(s0, s);
                    pictureBox1.Image = new Bitmap(s);
                }
                else
                {
                    pictureBox1.Image.Save(s);
                    Text = "Редактор изображений" + s;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            g.Dispose();
            pictureBox1.Invalidate();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            pen.Width = (int)numericUpDown1.Value;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            if (!rb.Checked) return;
            mode = 0;
        }

        public void DrawFigure(Rectangle r, Graphics g)
        {
            g.FillRectangle(brush, r);
            g.DrawRectangle(pen, r);
        }

        private Rectangle PtToRect(Point p1, Point p2)
        {
            int x = Math.Min(p1.X, p2.X), y = Math.Min(p1.Y, p2.Y);
            int w = Math.Abs(p2.X - p1.X), h = Math.Abs(p2.Y - p1.Y);
            return new Rectangle(x, y, w, h);
        }

        private void redrawFourier()
        {
            Graphics g = Graphics.FromImage(pictureBox1.Image);
            g.Clear(Color.White);
            pen.Color = Color.Black;
            g.DrawLine(pen, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(pen, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);
            pen.Width = Convert.ToInt32(numericUpDown1.Value);
            pen.Color = Color.Red;


            int Interval = pictureBox1.Width;

            double yp = 0, yy1 = 0, yy2 = 0;
            int angle = 0;
            int xtemp = 0;
            int ytemp = pictureBox1.Height / 2;
            int flag = 0;
            if (radioButton4.Checked)
                flag = 0;
            else if (radioButton5.Checked)
                flag = 1;
            else if (radioButton6.Checked)
                flag = 2;

            if (flag == 0)
            {
                for (int i = 0; i < Interval; i++)
                {
                    for (int j = 1; j < nterms; j++)
                    {
                        yy1 = A / ((2 * j));
                        double arg = ((j * 2)) * F * 0.01397 * angle;
                        yy2 = Math.Sin(arg);
                        yp = yp + yy1 * yy2;
                    }
                    g.DrawLine(pen, xtemp, ytemp, i, pictureBox1.Height / 2 + (int)Math.Truncate(yp));
                    xtemp = i;
                    ytemp = pictureBox1.Height / 2 + (int)Math.Truncate(yp);

                    yp = 0;
                    angle = angle + 1;
                }
            }
            else if (flag == 1)
            {
                for (int i = 0; i < Interval; i++)
                {
                    for (int j = 1; j < nterms; j++)
                    {
                        yy1 = A / ((2 * j - 1));
                        double arg = ((j * 2 - 1)) * F * 0.01397 * angle;
                        yy2 = Math.Sin(arg);
                        yp = yp + yy1 * yy2;
                    }
                    g.DrawLine(pen, xtemp, ytemp, i, pictureBox1.Height / 2 + (int)Math.Truncate(yp));
                    xtemp = i;
                    ytemp = pictureBox1.Height / 2 + (int)Math.Truncate(yp);

                    yp = 0;
                    angle = angle + 1;
                }
            }
            else if (flag == 2)
            {
                for (int i = 0; i < Interval; i++)
                {
                    for (int j = 1; j < nterms; j++)
                    {
                        int sign = 0;
                        yy1 = A / ((2 * j - 1) * (2 * j - 1));
                        if ((j - 1) % 2 == 0) sign = 1;
                        else sign = -1;
                        double arg = ((j * 2 - 1)) * F * 0.01397 * angle;
                        yy2 = Math.Sin(arg);
                        yp = yp + sign * yy1 * yy2;
                    }
                    g.DrawLine(pen, xtemp, ytemp, i, pictureBox1.Height / 2 + (int)Math.Truncate(yp));
                    xtemp = i;
                    ytemp = pictureBox1.Height / 2 + (int)Math.Truncate(yp);

                    yp = 0;
                    angle = angle + 1;
                }
            }


            pen.Color = Color.Black;
            g.Dispose();
            pictureBox1.Invalidate();
            pictureBox1.Update();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPt == nullPt)
            {
                return;
            }
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                Rectangle rect = new Rectangle(e.Location.X, e.Location.Y, (int)pen.Width, (int)pen.Width);
                switch (mode)
                {
                    case 0:
                        g.DrawLine(pen, startPt, e.Location);
                        g.Dispose();
                        startPt = e.Location;
                        pictureBox1.Invalidate();
                        pictureBox1.Update();
                        break;
                    case 1:
                        Console.WriteLine(pen.Width);
                        g.DrawEllipse(pen, rect);
                        g.Dispose();
                        startPt = e.Location;
                        pictureBox1.Invalidate();
                        pictureBox1.Update();
                        break;
                    case 2:
                        Console.WriteLine(pen.Width);
                        g.DrawRectangle(pen, rect);
                        g.Dispose();
                        startPt = e.Location;
                        pictureBox1.Invalidate();
                        pictureBox1.Update();
                        break;
                }
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            movePt = startPt = e.Location;

        }

       private void label1_BackColorChanged(object sender, EventArgs e)
       {
           pen.Color = label1.BackColor;
       }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startPt == nullPt)
            {
                return;
            }
            if (mode >= 1)
            {
                Graphics g = Graphics.FromImage(pictureBox1.Image);
                switch (mode)
                {
                    case 0:
                        g.DrawLine(pen, startPt, movePt);
                        break;
                }
                g.Dispose();
                pictureBox1.Invalidate();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                mode = 1;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                mode = 2;
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            redrawFourier();
            radioButton4.Checked = true;
        }

        private void numericUpDown2_ValueChanged_1(object sender, EventArgs e)
        {
            nterms = (int)numericUpDown2.Value;
            redrawFourier();
        }

        private void numericUpDown3_ValueChanged_1(object sender, EventArgs e)
        {
            A = (int)numericUpDown3.Value;
            redrawFourier();
        }

        private void numericUpDown4_ValueChanged_1(object sender, EventArgs e)
        {
            F = (int)numericUpDown4.Value;
            redrawFourier();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            Label lb = sender as Label;
            colorDialog1.Color = lb.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lb.BackColor = colorDialog1.Color;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            redrawFourier();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            redrawFourier();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            redrawFourier();
        }
    }
}