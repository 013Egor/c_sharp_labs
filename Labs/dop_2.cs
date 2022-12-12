using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labs.course
{
    public partial class dop_2 : Form
    {
        Form1 home;
        public dop_2(Form1 home)
        {
            this.home = home;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string message = textBox1.Text.ToLower();
            string key = textBox2.Text.ToLower();
            try
            {
                if (message.Length == 0 || key.Length == 0)
                {
                    throw new Exception("Пустые данные");
                }
                foreach (char item in message)
                {
                    if (item < 'a' || item > 'z')
                    {
                        throw new Exception("Ошибка в сообщении: символ " + item + "");
                    }
                }
                foreach (char item in key)
                {
                    if (item < 'a' || item > 'z')
                    {
                        throw new Exception("Ключ: символ " + item + "");
                    }
                }
            } catch (Exception exc)
            {
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n### " + DateTime.Now.ToUniversalTime());
                System.IO.File.AppendAllText("Errors_Lab_2.txt", "\n" + exc.StackTrace);
                home.textBox1.AppendText("\n### " + DateTime.Now.ToUniversalTime() + "\n" + exc.StackTrace);
                MessageBox.Show("Некорректный ввод: " + exc.Message);
                return;
            }
            int id = 0;
            int initialKeySize = key.Length;
            while (key.Length < message.Length)
            {
                key += key.ElementAt(id);
                id++;
                id = id % initialKeySize;
            }
            MessageBox.Show("Сообщение: " + message + "\nКлюч: " + key);
            int aLetter = 'a';
            int mod = 'z';
            string code = "";
            for (int i = 0; i < message.Length; i++)
            {
                int a = key.ElementAt(i);
                int diff = a - aLetter;
                char result = (char)((int)message.ElementAt(i) + diff);
                Console.WriteLine((char)result);
                if (result > mod)
                {
                    result = (char)(aLetter - 1  + (result) % mod);
                }
                code += result; 
            }

            MessageBox.Show("Шифр: " + code);
        }
    }
}
