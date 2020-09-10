using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KURSOVA_original
{
    public partial class Form1 : Form
    {   

        Bitmap bmp;
        Graphics g;
        Pen pen;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            int a = e.X;     //Знаходження кординат початкової точки заливки!
            int b = e.Y;
            int maxpixels = 1680 * 1050;
            int[] Mx = new int[maxpixels];
            int[] My = new int[maxpixels];

            Color startColor = bmp.GetPixel(a, b);

            int N = 0;                                              //найденное число внутренних элементов.
            int Ntek = 0;                                           //текущий анализируемый элемент

            bmp.SetPixel(a, b, Color.Red);
            Mx[Ntek] = a;
            My[Ntek] = b;


            for (int i = 0; i < maxpixels; i++)
            {

                if (b > 0 && bmp.GetPixel(a, b - 1).Equals(startColor))
                {
                 
                    bmp.SetPixel(a, b - 1, Color.Red);
                    N += 1;
                    Ntek += 1;
                    Mx[Ntek] = a;
                    My[Ntek] = b - 1;

                }


                if (a + 1 < bmp.Width && bmp.GetPixel(a + 1, b).Equals(startColor))
                {
               
                    bmp.SetPixel(a + 1, b, Color.Red);
                    N += 1;
                    Ntek += 1;
                    Mx[Ntek] = a + 1;
                    My[Ntek] = b;

                }



                if (b + 1 < bmp.Height && bmp.GetPixel(a, b + 1).Equals(startColor))
                {
                
                    bmp.SetPixel(a, b + 1, Color.Red);
                    N += 1;
                    Ntek += 1;
                    Mx[Ntek] = a;
                    My[Ntek] = b + 1;

                }

                if (a > 0 && bmp.GetPixel(a - 1, b).Equals(startColor))
                {
                   
                    bmp.SetPixel(a - 1, b, Color.Red);
                    N += 1;
                    Ntek += 1;
                    Mx[Ntek] = a - 1;
                    My[Ntek] = b;

                }


                if (i + 1 <= Ntek)
                {
                    a = Mx[i + 1];
                    b = My[i + 1];
                }
                else
                {
                    MessageBox.Show(string.Format("Ваша фигура зафарбована; {0} steps made", i));
                    break;
                }

            }

            pictureBox1.Image = bmp;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

       
        private void Draw( float x1, float y1, float x2, float y2)
        {

            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pen = new Pen(Color.Black, 8);
            g.DrawRectangle(pen, x1, y1, x2, y2);
            pictureBox1.Image = bmp;

            

        }   // Function draw rectangle

       


        private void button1_Click(object sender, EventArgs e)
        {
            float x1;
            float y1;
            float x2;
            float y2;

            x1 = Convert.ToSingle(textBox1.Text);
            y1 = Convert.ToSingle(textBox2.Text);
            x2 = Convert.ToSingle(textBox3.Text);
            y2 = Convert.ToSingle(textBox4.Text);
            Draw(x1, y1, x2, y2);
        }  // Draw button!

       

         private void Choose_Color(object sender, EventArgs e)
         {
            DialogResult colorResult = colorDialog1.ShowDialog();    //Отображает форму как модальное диалоговое окно.

            if (colorResult == DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
         }    //background color*

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' ) && (e.KeyChar <= '9')) 
            {
                return;
            }

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (textBox1.Text.IndexOf(',') != 1)
                {
                    e.Handled = true;
                }
                return;
            }


        }           //character check

        
    }
}
