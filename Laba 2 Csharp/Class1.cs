using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_2_Csharp
{



    class Class1
    {
        int k = 0;
        int sum=0;
        private Quadrangle[] arr;

        public Quadrangle[] Arr { get => arr; set => arr = value; }

        public void TEST(TextBox field1, TextBox field2, TextBox field3, TextBox field4, TextBox field5, TextBox field6, TextBox field7, TextBox field8, TextBox field9)
        {
            try
            {
                Quadrangle quadrangle = new Quadrangle(Convert.ToInt16(field1.Text), Convert.ToInt16(field2.Text), Convert.ToInt16(field3.Text), Convert.ToInt16(field4.Text), Convert.ToInt16(field5.Text), Convert.ToInt16(field6.Text), Convert.ToInt16(field7.Text), Convert.ToInt16(field8.Text));
                field9.Text = quadrangle.info();
            }
            catch (FormatException)
            {
                field9.Text = "Введите коректные значения";
            }

        }

        public void TEST2(TextBox field1, TextBox field2, TextBox field3, TextBox field4, TextBox field5, TextBox field6, TextBox field7, TextBox field8, TextBox field9)
        {
            try
            {
                Paralelogram paralelogram = new Paralelogram(Convert.ToInt16(field1.Text), Convert.ToInt16(field2.Text), Convert.ToInt16(field3.Text), Convert.ToInt16(field4.Text), Convert.ToInt16(field5.Text), Convert.ToInt16(field6.Text), Convert.ToInt16(field7.Text), Convert.ToInt16(field8.Text));

                field9.Text = field9.Text + paralelogram.check_paralel();
            }
            catch (FormatException)
            {
                field9.Text = "Введите коректные значения";
            }
        }

        internal void ArrResize(int v)
        {
            Array.Resize(ref arr, v);
        }

        public void Qdr_area(TextBox field1, TextBox field2, TextBox field3, TextBox field4, TextBox field5, TextBox field6, TextBox field7, TextBox field8, TextBox field10)
        {
            try
            {
                Arr[k++] = new Quadrangle(Convert.ToInt16(field1.Text), Convert.ToInt16(field2.Text), Convert.ToInt16(field3.Text), Convert.ToInt16(field4.Text), Convert.ToInt16(field5.Text), Convert.ToInt16(field6.Text), Convert.ToInt16(field7.Text), Convert.ToInt16(field8.Text));
            }
            catch(IndexOutOfRangeException)
            {
                field10.Text = "Нельзя присвоить больше елементов";
            }
        }
        public void MediumArea(TextBox field1,int v)
        {
            double mediumArea=0;
            try
            {
                k = 0;
                for (int i = 0; i < v; i++)
                {
                    sum = sum + Arr[k++].getArea();
                }
                mediumArea = sum / k;

                field1.Text = "Medium Area = " + mediumArea;
            }
            catch(NullReferenceException)
            {
                field1.Text = "Вы ввели меньше елементов чем нужно";
                k -= 1;

            }
        }




        public class Quadrangle
        {
            public int x1, y1, x2, y2, x3, y3, x4, y4;
            public int AB, BC, CD, DA;
            public int diagonal1, diagonal2;
            public int Area, Perimetr;

            public Quadrangle(int X1, int Y1, int X2, int Y2, int X3, int Y3, int X4, int Y4)
            {
                this.x1 = X1;
                this.y1 = Y1;
                this.x2 = X2;
                this.y2 = Y2;
                this.x3 = X3;
                this.y3 = Y3;
                this.x4 = X4;
                this.y4 = Y4;

            }

            public int lineAB()
            {


                AB = Convert.ToInt32(Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2)));

                return AB;
            }

            public int lineBC()
            {


                BC = Convert.ToInt32(Math.Sqrt(Math.Pow(y3 - y2, 2) + Math.Pow(x3 - x2, 2)));

                return BC;
            }

            public int lineCD()
            {


                CD = Convert.ToInt32(Math.Sqrt(Math.Pow(y4 - y3, 2) + Math.Pow(x4 - x3, 2)));

                return CD;
            }

            public int lineDA()
            {


                DA = Convert.ToInt32(Math.Sqrt(Math.Pow(y1 - y4, 2) + Math.Pow(x1 - x4, 2)));

                return DA;
            }

            public int getPerimetr()
            {
                Perimetr = AB + BC + CD + DA;
                return Perimetr;
            }

            public int getDiagonal1()
            {
                diagonal1 = Convert.ToInt32(Math.Sqrt(Math.Pow(y3 - y1, 2) + Math.Pow(x3 - x1, 2)));
                return diagonal1;
            }
            public int getDiagonal2()
            {
                diagonal2 = Convert.ToInt32(Math.Sqrt(Math.Pow(y4 - y2, 2) + Math.Pow(x4 - x2, 2)));
                return diagonal2;
            }
            public int getArea()
            {
                getDiagonal1();
                getDiagonal2();
                Area = Convert.ToInt32((diagonal2 * diagonal1) / 2);
                return Area;
            }

            public string info()
            {

                return "Quadrangle Exist \r\n" + " Side AB = " + lineAB() + "\r\n Side BC = " +
                    lineBC() + "\r\n Side CD = " + lineCD() + "\r\n Side DA = " +
                    lineDA() + "\r\n \r\n Diagonal 1 = " + getDiagonal1() + "\r\n Diagonal 2 = " + getDiagonal2() + "\r\n \r\n Perimetr = " +
                    getPerimetr() + "\r\n Area = " + getArea() + "\r\n ";

            }

        }

        class Paralelogram : Quadrangle
        {
            
            public int AB1, BC1, CD1, DA1;
           
            public Paralelogram(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4) : base(x1, y1, x2, y2, x3, y3, x4, y4)
            {

            }
            public int lineAB1()
            {


                AB1 = Convert.ToInt32(Math.Sqrt(Math.Pow(y2 - y1, 2) + Math.Pow(x2 - x1, 2)));

                return AB1;
            }

            public int lineBC1()
            {


                BC1 = Convert.ToInt32(Math.Sqrt(Math.Pow(y3 - y2, 2) + Math.Pow(x3 - x2, 2)));

                return BC1;
            }

            public int lineCD1()
            {


                CD1 = Convert.ToInt32(Math.Sqrt(Math.Pow(y4 - y3, 2) + Math.Pow(x4 - x3, 2)));

                return CD1;
            }
            
            public int lineDA1()
            {


                DA1 = Convert.ToInt32(Math.Sqrt(Math.Pow(y1 - y4, 2) + Math.Pow(x1 - x4, 2)));

                return DA1;
            }

            

            public string check_paralel()
            {
                lineDA1();
                lineCD1();
                lineBC1();
                lineAB1();
                if (AB1 == CD1 && BC1 == DA1) return "This Quadrangl is Paralelogram";

                else return "This Quadrangl is  NOT Paralelogram";

            }

        }


    
    }
}

