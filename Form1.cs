using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplikacjaFizycznaElektrostatyka
{
    public partial class Form1 : Form
    {
        Graphics g; Pen p; Point cursor;
        int k = 0, n = 0; Point[] punkty_czerwone = new Point[2];
        Point[] punkty_niebieskie = new Point[2];
        public Form1()
        {
            InitializeComponent();      

        }
        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = new Point(e.X, e.Y);
            label1X.Text = "X= " + e.X;
            label2Y.Text = "Y= " + e.Y;
        }
        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            label1X.Text = "X= ";
            label2Y.Text = "Y= ";
        }
       
        int scale = 15;
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            //kod tworzacy uklad wspolrzednych
            e.Graphics.DrawLine(Pens.BlueViolet, panel4.Width / 2, 0, panel4.Width / 2, panel4.Height);
            e.Graphics.DrawLine(Pens.BlueViolet, 0, panel4.Height / 2, panel4.Width, panel4.Height / 2);
            Point absZero = new Point(panel4.Width / 2, panel4.Height / 2);
            int i = absZero.X;
            while (i < panel4.Width)
            {
                i += scale;
                e.Graphics.DrawLine(Pens.BlueViolet, i, absZero.Y - 4, i, absZero.Y + 4);
            }
            e.Graphics.DrawLine(Pens.BlueViolet, absZero.X, 0, absZero.X, panel4.Height);
            e.Graphics.DrawLine(Pens.BlueViolet, 0, absZero.Y, panel4.Width, absZero.Y);

            while (i < panel4.Width)
            {
                i += scale;
                e.Graphics.DrawLine(Pens.BlueViolet, i, absZero.Y - 4, i, absZero.Y + 4);
            }
            i = absZero.X;
            while (i > 0)
            {
                i -= scale;
                e.Graphics.DrawLine(Pens.BlueViolet, i, absZero.Y - 4, i, absZero.Y + 4);
            }
            i = absZero.Y;
            while (i < panel4.Height)
            {
                i += scale;
                e.Graphics.DrawLine(Pens.BlueViolet, absZero.X - 4, i, absZero.X + 4, i);
            }
            i = absZero.Y;
            while (i > 0)
            {
                i -= scale;
                e.Graphics.DrawLine(Pens.BlueViolet, absZero.X - 4, i, absZero.X + 4, i);
            }

            /*int X = 0;
            int Y = 0;
            int count = 10;
            
                for (int k = -10; k <= count; k++)
                {
                    X = k;
                    Y = 2 * X;
                    e.Graphics.FillEllipse(Brushes.DarkGreen, (absZero.X + (X * scale)) - 2,
                    (absZero.Y - (Y * scale)) - 2, 4, 4);
                }*/
        }

        Point point1, point2, point1a, point2a;


        private void Form1_Load(object sender, EventArgs e)
        {
          MessageBox.Show("Dzięki niemu nauczysz sie jak działają na siebie ładunki dodatnie, ujemne.\n\n Gdy między ładunkami pojawia się CZERWONA kreska oznacza ona, że ładunki dodatnie odpychają się od siebie. \n Gdy między ładunkami pojawia się NIEBIESKA kreska oznacza ona, że ładunki ujemne odpychają się od siebie. \n Gdy między ładunkami pojawia się CZARNA kreska oznacza ona, że ładunki Przyciągają się do siebie.\n\n UWAGA! \n Jeśli nie pojawi się pole wokół ładunku oznacza to ze trzeba rozstawić szerzej ładunki. ", "Witam w programie!", MessageBoxButtons.OK);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            k = 0; n = 0;
            Array.Clear(punkty_czerwone, 0, k);
            Array.Clear(punkty_niebieskie, 0, n);
            g.Clear(Color.White);
            p.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g = panel4.CreateGraphics();

            Pen blackPen = new Pen(Color.Black, 1);
            Pen blackPen1 = new Pen(Color.Red, 1);
            Pen blackPen2 = new Pen(Color.Blue, 1);

            if (k == 2 && n == 2)
            {

                for (int i = 0; i < k; i++)
                {
                    point1 = punkty_czerwone[i]; i++;
                    point1a = punkty_czerwone[i];
                    g.DrawLine(blackPen1, point1, point1a);

                    for (int j = 0; j < n; j++)
                    {
                        point2 = punkty_niebieskie[j]; j++;
                        point2a = punkty_niebieskie[j];

                        g.DrawLine(blackPen, point1, point2);
                        g.DrawLine(blackPen, point1a, point2);


                        g.DrawLine(blackPen2, point2, point2a);

                        g.DrawLine(blackPen, point2a, point1);
                        g.DrawLine(blackPen, point2a, point1a);
                        //czesc opdowiedzialna za pole 
                        int dlugosc1 = (int)Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
                        int dlugosca = (int)Math.Sqrt(Math.Pow((point1.X - point2a.X), 2) + Math.Pow((point1.Y - point2a.Y), 2));
                        int dlugosc11 = (int)Math.Sqrt(Math.Pow((point1a.X - point2.X), 2) + Math.Pow((point1a.Y - point2.Y), 2));
                        int dlugoscaa = (int)Math.Sqrt(Math.Pow((point1a.X - point2a.X), 2) + Math.Pow((point1a.Y - point2a.Y), 2));

                        double polowa1 = dlugosc1 / 2;
                        double polowaa = dlugosca / 2;
                        double polowa11 = dlugosc11 / 2;
                        double polowaaa = dlugoscaa / 2;

                        /*
                        MessageBox.Show("punkty1: x=" + point1.X + "y=" +
                            point1.Y + "\n punkt2: x= " + point2.X + "y=" + point2.Y +
                            "\n punkt2a: x= " + point2a.X + "y=" + point2a.Y +
                            "\npolowa1=" + polowa1 + "\npolowa=" + polowaa + "\npolowa11=" + polowa11 + "\npolowaaa=" + polowaaa);
                        */
                        //POLE
                    
                       // double polowa = (polowa1 + polowaa + polowa11 + polowaaa) /4;

                        double[] x = { polowa1 , polowaa, polowa11, polowaaa };
                       
                        double polowa = x.Min();

                        if (polowa <= 25 && polowa >= 24)
                        {
                            polowa += 5;
                        }
                        else
                        {
                            polowa += 1;
                        }
                        int jj = 0;
                        for (int ii = 0; jj < polowa; ii += 10)
                        {
                            g.DrawEllipse(blackPen1, point1a.X - jj, point1a.Y - jj, ii, ii);
                            g.DrawEllipse(blackPen1, point1.X - jj, point1.Y - jj, ii, ii);
                            g.DrawEllipse(blackPen2, point2a.X - jj, point2a.Y - jj, ii, ii);
                            g.DrawEllipse(blackPen2, point2.X - jj, point2.Y - jj, ii, ii);
                            jj += 5;
                        }

                    }
                    
                }
            }
            else if (n == 2 && k == 0)
            {
                for (int j = 0; j < n; j++)
                {
                    point2 = punkty_niebieskie[j]; j++;
                    point2a = punkty_niebieskie[j];

                    g.DrawLine(blackPen2, point2, point2a);
                    //czesc opdowiedzialna za pole 
                    int dlugosc1 = (int)Math.Sqrt(Math.Pow((point2.X - point2a.X), 2) + Math.Pow((point2.Y - point2a.Y), 2));
                    double polowa1 = (dlugosc1 /2) +80;

                    /*
                    MessageBox.Show("\n punkt2: x= " + point2.X + "y=" + point2.Y +
                        "\n punkt2a: x= " + point2a.X + "y=" + point2a.Y +
                        "\npolowa1=" + polowa1);*/

                    //POLE
                    if (polowa1 < 10)
                    {
                        polowa1 += 10;
                    }
                    int jj = 0;
                    for (int ii = 0; jj < polowa1; ii += 10)
                    {
                        g.DrawEllipse(blackPen2, point2a.X - jj, point2a.Y - jj, ii, ii);
                        g.DrawEllipse(blackPen2, point2.X - jj, point2.Y - jj, ii, ii);
                        jj += 5;
                    }
                }
                
            }
            else if (n == 0 && k == 2)
            {
                for (int i = 0; i < k; i++)
                {
                    point2 = punkty_czerwone[i]; i++;
                    point2a = punkty_czerwone[i];

                    g.DrawLine(blackPen1, point2, point2a);
                    
                    //czesc opdowiedzialna za pole 
                    int dlugosc1 = (int)Math.Sqrt(Math.Pow((point2.X - point2a.X), 2) + Math.Pow((point2.Y - point2a.Y), 2));
                    double polowa1 = (dlugosc1 / 2 )+ 80;

                    /*
                    MessageBox.Show("\n punkt2: x= " + point2.X + "y=" + point2.Y +
                        "\n punkt2a: x= " + point2a.X + "y=" + point2a.Y +
                        "\npolowa1=" + polowa1);*/

                    //POLE

                    if (polowa1 < 10)
                    {
                        polowa1 += 10;
                    }               
                    int jj = 0;
                    for (int ii = 0; jj < polowa1; ii += 10)
                    {
                        g.DrawEllipse(blackPen1, point2a.X - jj, point2a.Y - jj, ii, ii);
                        g.DrawEllipse(blackPen1, point2.X - jj, point2.Y - jj, ii, ii);
                        jj += 5;
                    }
                }
                
            }
            else if (k == 1 && n==2)
            {
                for (int i = 0; i < k; i++)
                {
                    point1 = punkty_czerwone[i];  

                    for (int j = 0; j < n; j++)
                    {
                        point2 = punkty_niebieskie[j]; j++;
                        point2a = punkty_niebieskie[j];

                        g.DrawLine(blackPen, point1, point2);

                        g.DrawLine(blackPen2, point2, point2a);

                        g.DrawLine(blackPen, point2a, point1);
                        
                        //czesc opdowiedzialna za pole 
                        int dlugosc1 = (int)Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
                        int dlugosca = (int)Math.Sqrt(Math.Pow((point1.X - point2a.X), 2) + Math.Pow((point1.Y - point2a.Y), 2));
                        double polowa1 = dlugosc1 / 2;
                        double polowaa = dlugosca / 2;

                        /*
                        MessageBox.Show("punkty1: x=" + point1.X + "y=" +
                            point1.Y + "\n punkt2: x= " + point2.X + "y=" + point2.Y +
                            "\n punkt2a: x= " + point2a.X + "y=" + point2a.Y +
                            "\npolowa1=" + polowa1 + "\npolowa=" + polowaa );*/

                        //POLE
                        double polowa;
                        if (polowa1 < polowaa)
                        {
                            polowa = polowa1;
                        }
                        else
                        {
                            polowa = polowaa;
                        }
                        
                        int jj = 0;
                        for (int ii = 0; jj < polowa; ii += 10)
                        {
                            g.DrawEllipse(blackPen1, point1.X - jj, point1.Y - jj, ii, ii);
                            g.DrawEllipse(blackPen2, point2a.X - jj, point2a.Y - jj, ii, ii);
                            g.DrawEllipse(blackPen2, point2.X - jj, point2.Y - jj, ii, ii);
                            jj += 5;
                        }
                    }
                    
                    

                }
            }
            else if (n == 1 && k == 2) 
            {
                for (int i = 0; i < n; i++)
                {
                    point1 = punkty_niebieskie[i];

                    for (int j = 0; j < k; j++)
                    {
                        point2 = punkty_czerwone[j]; j++;
                        point2a = punkty_czerwone[j];

                        g.DrawLine(blackPen, point1, point2);

                        g.DrawLine(blackPen1, point2, point2a);

                        g.DrawLine(blackPen, point2a, point1);
                        
                        //czesc opdowiedzialna za pole 
                        int dlugosc1 = (int)Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
                        int dlugosca = (int)Math.Sqrt(Math.Pow((point1.X - point2a.X), 2) + Math.Pow((point1.Y - point2a.Y), 2));
                        double polowa1 = dlugosc1 / 2;
                        double polowaa = dlugosca / 2;
                        /*
                        MessageBox.Show("punkty1: x=" + point1.X + "y=" + 
                            point1.Y + "\n punkt2: x= " + point2.X + "y=" + point2.Y + 
                            "\n punkt2a: x= " + point2a.X + "y="+ point2a.Y + 
                            "\npolowa1="+ polowa1 + "\npolowa=" + polowaa);*/

                        //POLE
                        double polowa;
                        if (polowa1 <  polowaa)
                        {
                            polowa = polowa1;
                        }
                        else
                        {
                            polowa = polowaa;
                        }
                        int jj = 0;
                        for (int ii = 0; jj < polowa; ii += 10)
                        {
                            g.DrawEllipse(blackPen2, point1.X - jj, point1.Y - jj, ii, ii);
                            g.DrawEllipse(blackPen1, point2a.X - jj, point2a.Y - jj, ii, ii);
                            g.DrawEllipse(blackPen1, point2.X - jj, point2.Y - jj, ii, ii);
                            jj += 5;
                        }

                    }
                    

                }
            }
            else if (n == 1 && k == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    point1 = punkty_niebieskie[i];

                    for (int j = 0; j < k; j++)
                    {
                        point2 = punkty_czerwone[j]; 

                        g.DrawLine(blackPen, point1, point2);

                        g.DrawLine(blackPen, point2, point1);

                        //czesc opdowiedzialna za pole 
                        int dlugosc = (int)Math.Sqrt(Math.Pow((point1.X - point2.X), 2) + Math.Pow((point1.Y - point2.Y), 2));
                        double polowa = dlugosc / 2;
                        //int srodekX = Math.Abs((point1.X + point2.X) / 2);
                       // int srodekY = Math.Abs((point1.Y + point2.Y) / 2);
                        //MessageBox.Show("punkty1: x=" + point1.X + "y=" + point1.Y + "\n punkt2: x= " + point2.X + "y=" + point2.Y + "\nsrodek x=" + srodekX + "y=" + srodekY + "\ndlugosc: " + dlugosc + " polowa: " + polowa);

                        //POLE
                        int jj = 0;
                        for (int ii = 0; jj < polowa; ii += 10)
                        {
                            g.DrawEllipse(blackPen2, point1.X - jj, point1.Y - jj, ii, ii);
                            g.DrawEllipse(blackPen1, point2.X - jj, point2.Y - jj, ii, ii);
                            jj += 5;
                        }

                        //g.DrawEllipse(blackPen2, point1.X - 30, point1.Y - 30, 60, 60);

                    }
                    
                }
            }

        }

        private void panel4_Click(object sender, EventArgs e)
        {

            g = panel4.CreateGraphics();
            p = new Pen(Color.Red, 20);

            if (radioButton1.Checked == true && radioButton2.Checked == false)
            {
                if (k < 2)
                {
                    g.DrawEllipse(p, cursor.X -10, cursor.Y-10 , 20, 20);
                    punkty_czerwone[k++] = new Point(cursor.X, cursor.Y);
                }
                else
                {
                    MessageBox.Show("Możesz uzyć maksymalnie 2 ładunków dodoatnich!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (radioButton2.Checked == true && radioButton1.Checked == false)
            {
                if (n < 2)
                {
                    p = new Pen(Color.Blue, 20);
                    g.DrawEllipse(p, cursor.X - 10, cursor.Y - 10, 20, 20);
                    punkty_niebieskie[n++] = new Point(cursor.X, cursor.Y);
                }
                else
                {
                    MessageBox.Show("Możesz uzyć maksymalnie 2 ładunków ujemnych!", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



        }

    }

}

