using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_2_Csharp
{
    public partial class Form1 : Form
    {
        Class1 main = new Class1();
        bool firstTime = true;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            main.TEST(textBox1,textBox2,textBox3,textBox4,textBox5, textBox6, textBox7, textBox8, textBox9);
            main.TEST2(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (firstTime)
            {
                main.Arr = new Class1.Quadrangle[Convert.ToInt32(numericUpDown1.Value)];
                firstTime = false;
            }
                main.Qdr_area(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox10);
            
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            main.ArrResize(Convert.ToInt32(numericUpDown1.Value));
        }

        private void button3_Click(object sender, EventArgs e)
        {
          main.MediumArea(textBox10, (int)numericUpDown1.Value);
         
        }
    }
}
