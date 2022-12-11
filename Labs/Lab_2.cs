using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Labs
{
    public partial class Lab_2 : Form
    {
        Form1 home;
        public Lab_2(Form1 home)
        {
            this.home = home;
            InitializeComponent();
            radioButton2.Checked = true;
            numericUpDown1.Minimum = 1;
            numericUpDown2.Minimum = 1;
        }

        public class MyArray
        {
            int[] array;
            float[] createdArray;
            int start;
            int end;
            int randBeg;
            int randEnd;
            bool range;

            public MyArray(int[] a, int s, int e)
            {
                start = s;
                end = e;
                array = a;
                range = false;
            }
            public MyArray(int[] a, int s, int e, int rb, int re)
            {
                start = s;
                end = e;
                array = a;
                randBeg = rb;
                randEnd = re;
                range = true;
            }

            public MyArray(float[] c, int[] a, int s, int e)
            {
                start = s;
                end = e;
                array = a;
                createdArray = c;
                range = false;
            }

            public void FillArray()
            {
                Random random = new Random();
                for (int i = start; i < end; i++)
                {
                   if (range)
                   {
                       array[i] = random.Next(randBeg, randEnd);
                    }
                    else
                    {
                        array[i] = random.Next();
                    }
                    
                }
            }

            public void Run()
            {
                for (int i = start; i < end; i++)
                {
                    createdArray[i] = i % 2 == 0 ? array[i] * array[i] : (float) array[i] / (i + 1);
                }
            }

            public void Find()
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % 5 == 0)
                    {
                        createdArray[i] = 0;
                        break;
                    }
                }
            }
            public void Replace()
            {
                for (int i = start; i < end; i++)
                {
                    if (i % 2 == 1)
                    {
                        createdArray[i] = i * i;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Value = 0;
                long startAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                MyArray myArray;
                int size = dataGridView1.ColumnCount - 1;
                int[] array = new int[size];
                int threadAmount = 5;
                Thread[] threads = new Thread[threadAmount];
                int step = (int)size / threadAmount;

                if (radioButton2.Checked || radioButton3.Checked)
                {
                    for (int i = 0; i < threadAmount; i++)
                    {
                        int endArray = i == threadAmount - 1 ? array.Length : step * (i + 1);
                        if (radioButton3.Checked)
                        {
                            myArray = new MyArray(array, step * i, endArray, (int)numericUpDown3.Value, (int)numericUpDown4.Value);
                        }
                        else
                        {
                            myArray = new MyArray(array, step * i, endArray);
                        }

                        threads[i] = new Thread(myArray.FillArray);
                        threads[i].Start();
                    }

                    for (int i = 0; i < threadAmount; i++)
                    {
                        threads[i].Join();
                    }
                }
                else
                {
                    string arrayItem = "";

                    try
                    {
                        for (int i = 1; i < dataGridView1.Columns.Count; i++)
                        {
                            arrayItem = dataGridView1.Rows[0].Cells[i].Value + "";
                            array[i - 1] = Int32.Parse(arrayItem);
                        }
                    }
                    catch (Exception exc)
                    {
                        System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n### " + DateTime.Now.ToUniversalTime());
                        System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n" + exc.StackTrace);
                        home.textBox1.AppendText("\n### " + DateTime.Now.ToUniversalTime() + "\n" + exc.StackTrace);
                        MessageBox.Show("Некорректный ввод: " + arrayItem);
                        return;
                    }
                }
                progressBar1.PerformStep();
                //Вывод изначального массива
                dataGridView1.Rows.Clear();
                object[] tempRow = new object[(int)size + 1];
                tempRow[0] = "Изначальный массив";
                for (int i = 0; i < size; i++)
                {
                    tempRow[i + 1] = array[i];
                }
                dataGridView1.Rows.Add(tempRow);
                progressBar1.PerformStep();
                //Основа
                float[] result = new float[size];
                for (int i = 0; i < threadAmount; i++)
                {
                    int endArray = i == threadAmount - 1 ? array.Length : step * (i + 1);

                    myArray = new MyArray(result, array, step * i, endArray);
                    threads[i] = new Thread(myArray.Run);
                    threads[i].Start();
                }
                for (int i = 0; i < threadAmount; i++)
                {
                    threads[i].Join();
                }
                object[] temp = new object[(int)size + 1];
                temp[0] = "Результат 1:";
                for (int i = 0; i < size; i++)
                {
                    temp[i + 1] = result[i];
                }
                dataGridView1.Rows.Add(temp);
                progressBar1.PerformStep();
                //Поиск первого значения кратного 5:
                result = new float[size];
                for (int i = 0; i < size; i++) result[i] = array[i];

                myArray = new MyArray(result, array, 0, size);
                Thread thread = new Thread(myArray.Find);
                thread.Start();
                thread.Join();

                temp = new object[(int)size + 1];
                temp[0] = "Результат 1:";
                for (int i = 0; i < size; i++)
                {
                    temp[i + 1] = result[i];
                }
                dataGridView1.Rows.Add(temp);
                progressBar1.PerformStep();
                //Замена элементов с нечетными номерами:
                result = new float[size];
                for (int i = 0; i < size; i++) result[i] = array[i];
                for (int i = 0; i < threadAmount; i++)
                {
                    int endArray = i == threadAmount - 1 ? array.Length : step * (i + 1);

                    myArray = new MyArray(result, array, step * i, endArray);
                    threads[i] = new Thread(myArray.Replace);
                    threads[i].Start();
                }
                for (int i = 0; i < threadAmount; i++)
                {
                    threads[i].Join();
                }
                temp = new object[(int)size + 1];
                temp[0] = "Результат 2:";
                for (int i = 0; i < size; i++)
                {
                    temp[i + 1] = result[i];
                }
                dataGridView1.Rows.Add(temp);
                long endAction = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                progressBar1.PerformStep();
                label4.Text = (endAction - startAction) + "";
            } catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", Environment.NewLine);
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "### " + DateTime.Now.ToUniversalTime() + "\n" + exc.StackTrace);
                MessageBox.Show("Произошла ошибка");
            }
           
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns.Clear();
                Decimal size = this.numericUpDown1.Value;
                numericUpDown2.Value = size < numericUpDown2.Value ? size : numericUpDown2.Value;

                dataGridView1.Columns.Add("Arrays", "");
                dataGridView1.Columns[0].ReadOnly = true;
                for (int i = 0; i < size; i++)
                {
                    dataGridView1.Columns.Add("Pos " + i, "" + i);
                }
            }
            catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n### " + DateTime.Now.ToUniversalTime());
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n" + exc.StackTrace);
                MessageBox.Show("Произошла ошибка");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ReadOnly = !radioButton1.Checked;
                panel1.Visible = false;
            }
            catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n### " + DateTime.Now.ToUniversalTime());
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n" + exc.StackTrace);
                MessageBox.Show("Произошла ошибка");
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ReadOnly = radioButton2.Checked;
                panel1.Visible = false;
            }
            catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n### " + DateTime.Now.ToUniversalTime());
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n" + exc.StackTrace);
                MessageBox.Show("Произошла ошибка");
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.ReadOnly = radioButton2.Checked;
                panel1.Visible = true;
            }
            catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n### " + DateTime.Now.ToUniversalTime());
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n" + exc.StackTrace);
                MessageBox.Show("Произошла ошибка");
            }

        }
    }
}
