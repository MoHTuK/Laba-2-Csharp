using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Laba_2_Csharp
{



    class Class1
    {
        int k = 0;
        int sum = 0;
        private Quadrangle[] arr;
        private Paralelogram[] arr1;


        public Quadrangle[] Arr { get => arr; set => arr = value; }
        public Paralelogram[] Arr1 { get => arr1; set => arr1 = value; }

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

        internal void Arr1Resize(int v)
        {
            Array.Resize(ref arr1, v);
        }

        public void ArrInput(TextBox field1, TextBox field2, TextBox field3, TextBox field4, TextBox field5, TextBox field6, TextBox field7, TextBox field8, TextBox field10)
        {
            try
            {
                Arr[k++] = new Quadrangle(Convert.ToInt16(field1.Text), Convert.ToInt16(field2.Text), Convert.ToInt16(field3.Text), Convert.ToInt16(field4.Text), Convert.ToInt16(field5.Text), Convert.ToInt16(field6.Text), Convert.ToInt16(field7.Text), Convert.ToInt16(field8.Text));
            }
            catch (IndexOutOfRangeException)
            {
                field10.Text = "Нельзя присвоить больше елементов";
            }
        }

        public void ArrParalelInput(TextBox field1, TextBox field2, TextBox field3, TextBox field4, TextBox field5, TextBox field6, TextBox field7, TextBox field8, TextBox field10)
        {
            try
            {
                Arr1[k++] = new Paralelogram(Convert.ToInt16(field1.Text), Convert.ToInt16(field2.Text), Convert.ToInt16(field3.Text), Convert.ToInt16(field4.Text), Convert.ToInt16(field5.Text), Convert.ToInt16(field6.Text), Convert.ToInt16(field7.Text), Convert.ToInt16(field8.Text));
            }
            catch (IndexOutOfRangeException)
            {
                field10.Text = "Нельзя присвоить больше елементов";
            }
        }

        public void MediumArea(TextBox field1, int N)
        {
            double mediumArea = 0;
            try
            {
                k = 0;
                for (int i = 0; i < N; i++)
                {
                    sum = sum + Arr[k++].getArea();
                }
                mediumArea = sum / k;

                field1.Text = "Medium Area = " + mediumArea;
            }
            catch (NullReferenceException)
            {
                field1.Text = "Вы ввели меньше елементов чем нужно";
                k -= 1;

            }
        }

        public void MaxMinArea(TextBox field, int N)
        {
            try
            {
                int max = Arr1[0].getArea(), min = Arr1[0].getArea();

                k = 0;
                for (int i = 0; i < N; i++)
                {
                    if (Arr1[i].getArea() > max)
                        max = Arr1[i].getArea();

                    if (Arr1[i].getArea() < min)
                        min = Arr1[i].getArea();
                }




                field.Text = "Максимальная площадь = " + max + "\r\n Минимальная площадь = " + min;
            }
            catch (Exception)
            {
                field.Text = "Ошибка Вводите все заново";
            }
        }
        public void save(TextBox field1)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string path = saveFileDialog1.FileName;
            BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate));

            for (int i = 0; i <k ; i++)
            {

                writer.Write(Arr[i].x1.ToString());
                writer.Write(Arr[i].x2.ToString());
                writer.Write(Arr[i].x3.ToString());
                writer.Write(Arr[i].x4.ToString());
                writer.Write(Arr[i].y1.ToString());
                writer.Write(Arr[i].y2.ToString());
                writer.Write(Arr[i].y3.ToString());
                writer.Write(Arr[i].y4.ToString());
                counter++;
                
            }
            writer.Write(counter.ToString());
            writer.Close();
            field1.Text = "Exporting succesfull";
        }

        public int counter = 0;
        public void import(TextBox field1)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string path = openFileDialog1.FileName;
            BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));

            counter = reader.ReadInt32();
            for (int i = 0; i < counter; i++)
            {
                if (reader.PeekChar() != -1)
                {
                    Arr[i].x1 = reader.ReadInt32();
                    Arr[i].x2 = reader.ReadInt32();
                    Arr[i].x3 = reader.ReadInt32();
                    Arr[i].x4 = reader.ReadInt32();
                    Arr[i].y1 = reader.ReadInt32();
                    Arr[i].y2 = reader.ReadInt32();
                    Arr[i].y3 = reader.ReadInt32();
                    Arr[i].y4 = reader.ReadInt32();
                    
                    
                }
                else
                {
                    reader.Close();
                    break;
                }
            }
            
        }
        public void showinfo(TextBox field1)
        {
            for(int i=0;i<counter;i++)
            field1.Text += "Quadrangle Exist \r\n" + " Side AB = " + Arr[i].lineAB() + "\r\n Side BC = " +
                Arr[i].lineBC() + "\r\n Side CD = " + Arr[i].lineCD() + "\r\n Side DA = " +
                Arr[i].lineDA() + "\r\n \r\n Diagonal 1 = " + Arr[i].getDiagonal1() + "\r\n Diagonal 2 = " + Arr[i].getDiagonal2() + "\r\n \r\n Perimetr = " +
                Arr[i].getPerimetr() + "\r\n Area = " + Arr[i].getArea() + "\r\n///////////////////////////////////// ";
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

        public class Paralelogram : Quadrangle
        {

            public int AB1, BC1, CD1, DA1;

            public Paralelogram(int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4) : base(x1, y1, x2, y2, x3, y3, x4, y4)
            {

            }



            public string check_paralel()
            {
                lineDA();
                lineCD();
                lineBC();
                lineAB();
                if (AB == CD && BC == DA) return "This Quadrangl is Paralelogram";

                else return "This Quadrangl is  NOT Paralelogram";

            }
        }

    }


}
    


