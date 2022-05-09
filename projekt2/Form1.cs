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


namespace projekt2
{
    
    public partial class Form1 : Form
    {
        private int wid = 0, hei = 0;
        private int wid2 = 0, hei2 = 0;
        int biggerWid = 0, biggerHei = 0;

        protected int checkRGBRange(int input)
        {
            if (input > 255)
                return 255;
            else if (input < 0)
                return 0;
            else
                return input;
        }

        protected double checkRGBRange(double input)
        {
            if (input > 1.0)
                return 1.0;
            else if (input < 0.0)
                return 0.0;
            else
                return input;
        }

        private void TransformacjaLiniowa(double[] promptValue)
        {
            double a = promptValue[0], b = promptValue[1];
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            Color k1, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    k3 = Color.FromArgb(checkRGBRange((int)(a * k1.R + b)), checkRGBRange((int)(a * k1.G + b)),
                        checkRGBRange((int)(a * k1.B + b)));
                    b3.SetPixel(x, y, k3);
                }
            }
            pictureBox3.Refresh();
        }

        private void TransformacjaPotegowa(double[] promptValue)
        {
            double a = promptValue[0], b = promptValue[1]/10;

            if (b < 0)
                b = 1 / (-b);

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            Color k1, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    k1 = b1.GetPixel(x, y);

                    int red = k1.R;
                    int green = k1.G;
                    int blue = k1.B;

                    double redDouble, blueDouble, greenDouble;
                    redDouble = (double)red / 255.0; greenDouble = (double)green / 255.0; blueDouble = (double)blue / 255.0;

                    redDouble = checkRGBRange(a * Math.Pow(redDouble, b));
                    greenDouble = checkRGBRange(a * Math.Pow(greenDouble, b));
                    blueDouble = checkRGBRange(a * Math.Pow(blueDouble, b));

                    red = (int)(redDouble * 255);
                    green = (int)(greenDouble * 255);
                    blue = (int)(blueDouble * 255);

                    k3 = Color.FromArgb(checkRGBRange(red), checkRGBRange(green),
                        checkRGBRange(blue));
                    b3.SetPixel(x, y, k3);
                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieSuma()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;


            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = k1.R + k2.R;
                        g = k1.G + k2.G;
                        b = k1.B + k2.B;

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));

                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
           
            pictureBox3.Refresh();
        }

        private void MieszanieOdejmowanie()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = k1.R + k2.R - 255;
                        g = k1.G + k2.G - 255;
                        b = k1.B + k2.B - 255;

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieRoznica()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = Math.Abs(k1.R - k2.R);
                        g = Math.Abs(k1.G - k2.G);
                        b = Math.Abs(k1.B - k2.B);

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieMnozenie()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = k1.R * k2.R;
                        g = k1.G * k2.G;
                        b = k1.B * k2.B;

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieMnozenieOdwrotnosci()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = 255 - (255 - k1.R) * (255 - k2.R);
                        g = 255 - (255 - k1.G) * (255 - k2.G);
                        b = 255 - (255 - k1.B) * (255 - k2.B);

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieNegacja()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = 255 - Math.Abs(255 - k1.R - k2.R);
                        g = 255 - Math.Abs(255 - k1.G - k2.G);
                        b = 255 - Math.Abs(255 - k1.B - k2.B);

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieCiemniejsze()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = (k1.R < k2.R) ? k1.R : k2.R;
                        g = (k1.G < k2.G) ? k1.G : k2.G;
                        b = (k1.B < k2.B) ? k1.B : k2.B;

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieJasniejsze()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = (k1.R > k2.R) ? k1.R : k2.R;
                        g = (k1.G > k2.G) ? k1.G : k2.G;
                        b = (k1.B > k2.B) ? k1.B : k2.B;

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieWylaczenie()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = k1.R + k2.R - 2 * k1.R * k2.R;
                        g = k1.G + k2.G - 2 * k1.G * k2.G;
                        b = k1.B + k2.B - 2 * k1.B * k2.B;

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieNakladka()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = (k1.R < 255 / 2) ? 2 * k1.R * k2.R : 255 - 2 * (255 - k1.R) * (255 - k2.R);
                        g = (k1.G < 255 / 2) ? 2 * k1.G * k2.G : 255 - 2 * (255 - k1.G) * (255 - k2.G);
                        b = (k1.B < 255 / 2) ? 2 * k1.B * k2.B : 255 - 2 * (255 - k1.B) * (255 - k2.B);

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieOstreSwiatlo()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = (k2.R < 255 / 2) ? 2 * k1.R * k2.R : 255 - 2 * (255 - k1.R) * (255 - k2.R);
                        g = (k2.G < 255 / 2) ? 2 * k1.G * k2.G : 255 - 2 * (255 - k1.G) * (255 - k2.G);
                        b = (k2.B < 255 / 2) ? 2 * k1.B * k2.B : 255 - 2 * (255 - k1.B) * (255 - k2.B);

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieLagodneSwiatlo()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = (k2.R < 255 / 2) ? (int)(2 * k1.R * k2.R + Math.Pow(k1.R, 2) * (255 - 2 * k2.R))
                            : (int)(Math.Sqrt(k1.R) * (2 * k2.R - 255) + (2 * k1.R) * (255 - k2.R));
                        g = (k2.G < 255 / 2) ? (int)(2 * k1.G * k2.G + Math.Pow(k1.G, 2) * (255 - 2 * k2.G))
                            : (int)(Math.Sqrt(k1.G) * (2 * k2.G - 255) + (2 * k1.G) * (255 - k2.G));
                        b = (k2.B < 255 / 2) ? (int)(2 * k1.B * k2.B + Math.Pow(k1.B, 2) * (255 - 2 * k2.B))
                            : (int)(Math.Sqrt(k1.B) * (2 * k2.B - 255) + (2 * k1.B) * (255 - k2.B));

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieRozcienczenie()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;
                        if (k2.R == 255) r = 255;
                        else r = k1.R / (255 - k2.R);
                        if (k2.G == 255) g = 255;
                        else g = k1.G / (255 - k2.G);
                        if (k2.B == 255) b = 255;
                        else b = k1.B / (255 - k2.B);
                       

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieWypalenie()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;
                        if (k2.R == 0) r = 255;
                        else r = 255 - (255 - k1.R) / k2.R;
                        if (k2.G == 0) g = 255;
                        else g = 255 - (255 - k1.G) / k2.G;
                        if (k2.B == 0) b = 255;
                        else b = 255 - (255 - k1.B) / k2.B; 

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszanieReflectMode()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = (int)(Math.Pow(k1.R, 2) / (255 - k2.R));
                        g = (int)(Math.Pow(k1.G, 2) / (255 - k2.G));
                        b = (int)(Math.Pow(k1.B, 2) / (255 - k2.B));

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private void MieszaniePrzezroczystosc(double alfa)
        {            
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            int smallerWid = (wid > wid2) ? wid2 : wid;
            int smallerHei = (hei > hei2) ? hei2 : hei;

            Color k1, k2, k3;
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    if (x < smallerWid && y < smallerHei)
                    {
                        k1 = b1.GetPixel(x, y);
                        k2 = b2.GetPixel(x, y);

                        int r, g, b;

                        r = (int)((1 - alfa) * k2.R + alfa * k1.R);
                        g = (int)((1 - alfa) * k2.G + alfa * k1.G);
                        b = (int)((1 - alfa) * k2.B + alfa * k1.B);

                        k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));


                        b3.SetPixel(x, y, k3);
                    }
                    else
                    {
                        if (wid == biggerWid)
                            b3.SetPixel(x, y, b1.GetPixel(x, y));
                        else
                            b3.SetPixel(x, y, b2.GetPixel(x, y));
                    }

                }
            }
            pictureBox3.Refresh();
        }

        private int[] kontrastW1(Color k1, int promptValue)
        {
            int red, green, blue;
            if (promptValue >= 0)
            {
                red = (127 / (127 - promptValue)) * (k1.R - promptValue);
                green = (127 / (127 - promptValue)) * (k1.G - promptValue);
                blue = (127 / (127 - promptValue)) * (k1.B - promptValue);
            }
            else
            {
                red = (int)(((127 + promptValue) / (double)127) * k1.R - promptValue);
                green = (int)(((127 + promptValue) / (double)127) * k1.G - promptValue);
                blue = (int)(((127 + promptValue) / (double)127) * k1.B - promptValue);
            }

            return new int[]{ red,green,blue};
        }

        private int[] kontrastW2(Color k1, int c)
        {
            int red = k1.R, green = k1.G, blue = k1.B;
            if (c >= 0)
            {
                if(red<127)
                    red = ((127 - c) / 127) * red;
                else
                    red = ((127 - c) / 127) * red + 2 * c;
                //////
                if (green < 127)
                    green = ((127 - c) / 127) * green;
                else
                    green = ((127 - c) / 127) * green + 2 * c;
                //////
                if (blue < 127)
                    blue = ((127 - c) / 127) * blue;
                else
                    blue = ((127 - c) / 127) * blue + 2 * c;
            }
            else
            {
                if (red < 127 + c)
                    red = (127 / (127 + c)) * red;
                else if (red > 127 - c)
                    red = (127 * red + 255 * c) / (127 + c);
                else
                    red = 127;
                //////
                if (green < 127 + c)
                green = (127 / (127 + c)) * green;
                else if (green > 127 - c)
                    green = (127 * green + 255 * c) / (127 + c);
                else
                    green = 127;
                //////
                if (blue < 127 + c)
                blue = (127 / (127 + c)) * blue;
                else if (blue > 127 - c)
                    blue = (127 * blue + 255 * c) / (127 + c);
                else
                    blue = 127;
            }

            return new int[] { red, green, blue };
        }

        private void Histogram(char c)
        {
            Bitmap bmp = (Bitmap)pictureBox3.Image;
            int[] histogram = new int[256];
            float max = 0;
            int Value=0;

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    if (c == 'r')
                        Value = bmp.GetPixel(i, j).R;
                    else if (c == 'g')
                        Value = bmp.GetPixel(i, j).G;
                    else if (c == 'b')
                        Value = bmp.GetPixel(i, j).B;

                    histogram[Value]++;
                    if (max < histogram[Value])
                        max = histogram[Value];
                }
            }

            int histHeight = 128;
            Bitmap img = new Bitmap(256, histHeight + 10);
            using (Graphics g = Graphics.FromImage(img))
            {
                for (int i = 0; i < histogram.Length; i++)
                {
                    float pct = (float)histogram[i] / max;   // What percentage of the max is this value?
                    g.DrawLine(Pens.Black,
                        new Point(i, img.Height - 5),
                        new Point(i, img.Height - 5 - (int)(pct * histHeight))  // Use that percentage of the height
                        );
                }
            }

            if (c == 'r')
                PromptHistogram.ShowDialog("Histogram składnika R",img);
            else if (c == 'g')
                PromptHistogram.ShowDialog("Histogram składnika G",img);
            else if (c == 'b')
                PromptHistogram.ShowDialog("Histogram składnika B",img);

        }
    
        private void WyrownanieHistogramu()
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            Color k1,k3;
            int NM = wid * hei;
            int r, g, b;
            int[] histR = LiczHistBarwy('r');
            int[] histG = LiczHistBarwy('g');
            int[] histB = LiczHistBarwy('b');
            int[] histcR = new int[256];
            int[] histcG = new int[256];
            int[] histcB = new int[256];
            
            for(int i=0;i<256;i++)
            {
                histcR[i] = LiczHistKumul(histcR, histR, i);
                histcG[i] = LiczHistKumul(histcG, histG, i);
                histcB[i] = LiczHistKumul(histcB, histB, i);
            }

            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {
                    k1 = b1.GetPixel(x, y);

                    r = (int)(255 * histcR[k1.R] / (double)NM);
                    g = (int)(255 * histcR[k1.G] / (double)NM);
                    b = (int)(255 * histcR[k1.B] / (double)NM);

                    k3 = Color.FromArgb(checkRGBRange(r), checkRGBRange(g), checkRGBRange(b));

                    b3.SetPixel(x, y, k3);
                }
            }

            pictureBox3.Refresh();
        }
        private int[] LiczHistBarwy(char c)
        {
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            int Value = 0;
            int[] hist = new int[256];

            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {
                    if (c == 'r')
                        Value = b1.GetPixel(x, y).R;
                    else if (c == 'g')
                        Value = b1.GetPixel(x, y).G;
                    else if (c == 'b')
                        Value = b1.GetPixel(x, y).B;

                    hist[Value]++;
                }
            }
            return hist;
        }
        private int LiczHistKumul(int[] histc, int[] hist, int i)
        {
            if(i==0)
            {
                return hist[0];
            }    
            else
            {
                return hist[i] + histc[i-1];
            }
        }

        private int[][] FiltrGenColorArray(char c)
        {
            int[][] result = new int[wid][];
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Color k1;

            for (int i = 0; i < wid; i++)
                result[i] = new int[hei];

            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {
                    k1 = b1.GetPixel(x, y);
                    if (c == 'r')
                        result[x][y] = k1.R;
                    else if(c=='g')
                        result[x][y] = k1.G;
                    else
                        result[x][y] = k1.B;
                }
            }

            return result;
        }

        private void FiltrRobertsPion()
        {
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int sumR, sumG, sumB;
            int[][] mask = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, 0 }, new int[] { 0, -1, 0 } };
            int[][] arrR = FiltrGenColorArray('r');
            int[][] arrG = FiltrGenColorArray('g');
            int[][] arrB = FiltrGenColorArray('b');

            Color k2;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {

                    if (x == 0 || x == wid - 1 || y == 0 || y == hei - 1)
                    {
                        b2.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        sumR = 0; sumG = 0; sumB = 0;

                        for(int i=-1;i<2;i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                sumR += arrR[x + i][y + j] * mask[i+1][j+1];
                                sumG += arrG[x + i][y + j] * mask[i+1][j+1];
                                sumB += arrB[x + i][y + j] * mask[i+1][j+1];
                            }
                        }

                        k2 = Color.FromArgb(checkRGBRange(sumR/1), checkRGBRange(sumG/1), checkRGBRange(sumB/1));

                        b2.SetPixel(x, y, k2);
                    }

                }
            }

            pictureBox2.Refresh();

            MieszanieSuma();
        }

        private void FiltrRobertsPoziom()
        {
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int sumR, sumG, sumB;
            int[][] mask = new int[][] { new int[] { 0, 0, 0 }, new int[] { 0, 1, -1 }, new int[] { 0, 0, 0 } };
            int[][] arrR = FiltrGenColorArray('r');
            int[][] arrG = FiltrGenColorArray('g');
            int[][] arrB = FiltrGenColorArray('b');

            Color k2;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {

                    if (x == 0 || x == wid - 1 || y == 0 || y == hei - 1)
                    {
                        b2.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        sumR = 0; sumG = 0; sumB = 0;

                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                sumR += arrR[x + i][y + j] * mask[i + 1][j + 1];
                                sumG += arrG[x + i][y + j] * mask[i + 1][j + 1];
                                sumB += arrB[x + i][y + j] * mask[i + 1][j + 1];
                            }
                        }

                        k2 = Color.FromArgb(checkRGBRange(sumR / 1), checkRGBRange(sumG / 1), checkRGBRange(sumB / 1));

                        b2.SetPixel(x, y, k2);
                    }

                }
            }

            pictureBox2.Refresh();

            MieszanieSuma();
        }

        private void FiltrPrewittPion()
        {
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int sumR, sumG, sumB;
            int[][] mask = new int[][] { new int[] { 1, 0, -1 }, new int[] { 1, 0, -1 }, new int[] { 1, 0, -1 } };
            int[][] arrR = FiltrGenColorArray('r');
            int[][] arrG = FiltrGenColorArray('g');
            int[][] arrB = FiltrGenColorArray('b');

            Color k2;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {

                    if (x == 0 || x == wid - 1 || y == 0 || y == hei - 1)
                    {
                        b2.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        sumR = 0; sumG = 0; sumB = 0;

                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                sumR += arrR[x + i][y + j] * mask[i + 1][j + 1];
                                sumG += arrG[x + i][y + j] * mask[i + 1][j + 1];
                                sumB += arrB[x + i][y + j] * mask[i + 1][j + 1];
                            }
                        }

                        k2 = Color.FromArgb(checkRGBRange(sumR / 1), checkRGBRange(sumG / 1), checkRGBRange(sumB / 1));

                        b2.SetPixel(x, y, k2);
                    }

                }
            }

            pictureBox2.Refresh();

            MieszanieSuma();
        }

        private void FiltrPrewittPoziom()
        {
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int sumR, sumG, sumB;
            int[][] mask = new int[][] { new int[] { 1, 1, 1 }, new int[] { 0, 0, 0 }, new int[] { -1, -1, -1 } };
            int[][] arrR = FiltrGenColorArray('r');
            int[][] arrG = FiltrGenColorArray('g');
            int[][] arrB = FiltrGenColorArray('b');

            Color k2;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {

                    if (x == 0 || x == wid - 1 || y == 0 || y == hei - 1)
                    {
                        b2.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        sumR = 0; sumG = 0; sumB = 0;

                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                sumR += arrR[x + i][y + j] * mask[i + 1][j + 1];
                                sumG += arrG[x + i][y + j] * mask[i + 1][j + 1];
                                sumB += arrB[x + i][y + j] * mask[i + 1][j + 1];
                            }
                        }

                        k2 = Color.FromArgb(checkRGBRange(sumR / 1), checkRGBRange(sumG / 1), checkRGBRange(sumB / 1));

                        b2.SetPixel(x, y, k2);
                    }

                }
            }

            pictureBox2.Refresh();

            MieszanieSuma();
        }

        private void FiltrSobelPion()
        {
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int sumR, sumG, sumB;
            int[][] mask = new int[][] { new int[] { 1, 0, -1 }, new int[] { 2, 0, -2 }, new int[] { 1, 0, -1 } };
            int[][] arrR = FiltrGenColorArray('r');
            int[][] arrG = FiltrGenColorArray('g');
            int[][] arrB = FiltrGenColorArray('b');

            Color k2;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {

                    if (x == 0 || x == wid - 1 || y == 0 || y == hei - 1)
                    {
                        b2.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        sumR = 0; sumG = 0; sumB = 0;

                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                sumR += arrR[x + i][y + j] * mask[i + 1][j + 1];
                                sumG += arrG[x + i][y + j] * mask[i + 1][j + 1];
                                sumB += arrB[x + i][y + j] * mask[i + 1][j + 1];
                            }
                        }

                        k2 = Color.FromArgb(checkRGBRange(sumR / 1), checkRGBRange(sumG / 1), checkRGBRange(sumB / 1));

                        b2.SetPixel(x, y, k2);
                    }

                }
            }

            pictureBox2.Refresh();

            MieszanieSuma();
        }

        private void FiltrSobelPoziom()
        {
            Bitmap b2 = (Bitmap)pictureBox2.Image;

            int sumR, sumG, sumB;
            int[][] mask = new int[][] { new int[] { 1, 2, 1 }, new int[] { 0, 0, 0 }, new int[] { -1, -2, -1 } };
            int[][] arrR = FiltrGenColorArray('r');
            int[][] arrG = FiltrGenColorArray('g');
            int[][] arrB = FiltrGenColorArray('b');

            Color k2;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {

                    if (x == 0 || x == wid - 1 || y == 0 || y == hei - 1)
                    {
                        b2.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        sumR = 0; sumG = 0; sumB = 0;

                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                sumR += arrR[x + i][y + j] * mask[i + 1][j + 1];
                                sumG += arrG[x + i][y + j] * mask[i + 1][j + 1];
                                sumB += arrB[x + i][y + j] * mask[i + 1][j + 1];
                            }
                        }

                        k2 = Color.FromArgb(checkRGBRange(sumR / 1), checkRGBRange(sumG / 1), checkRGBRange(sumB / 1));

                        b2.SetPixel(x, y, k2);
                    }

                }
            }

            pictureBox2.Refresh();

            MieszanieSuma();
        }

        private void FiltrLaplace()
        {
            Cursor = Cursors.Default;
            PromptFiltryLaplace.ShowDialog("Wybierz wariant maski");
            Cursor = Cursors.WaitCursor;

            int[][] mask;

            if (PromptFiltryLaplace.rb1.Checked)
                mask = new int[][] { new int[] { 0, -1, 0 }, new int[] { -1, 4, -1 }, new int[] { 0, -1, 0 } };
            else if (PromptFiltryLaplace.rb2.Checked)
                mask = new int[][] { new int[] { -1, -1, -1 }, new int[] { -1, 8, -1 }, new int[] { -1, -1, -1 } };
            else if (PromptFiltryLaplace.rb3.Checked)
                mask = new int[][] { new int[] { -2, 1, -2 }, new int[] { 1, 4, 1 }, new int[] { -2, 1, -2 } };
            else
                return;

            Bitmap b2 = (Bitmap)pictureBox2.Image;
            int sumR, sumG, sumB;
            int[][] arrR = FiltrGenColorArray('r');
            int[][] arrG = FiltrGenColorArray('g');
            int[][] arrB = FiltrGenColorArray('b');

            Color k2;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {

                    if (x == 0 || x == wid - 1 || y == 0 || y == hei - 1)
                    {
                        b2.SetPixel(x, y, Color.Black);
                    }
                    else
                    {
                        sumR = 0; sumG = 0; sumB = 0;

                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                sumR += arrR[x + i][y + j] * mask[i + 1][j + 1];
                                sumG += arrG[x + i][y + j] * mask[i + 1][j + 1];
                                sumB += arrB[x + i][y + j] * mask[i + 1][j + 1];
                            }
                        }

                        k2 = Color.FromArgb(checkRGBRange(sumR / 1), checkRGBRange(sumG / 1), checkRGBRange(sumB / 1));

                        b2.SetPixel(x, y, k2);
                    }

                }
            }

            pictureBox2.Refresh();

            MieszanieSuma();
        }

        private void FiltrMin()
        {
            Cursor = Cursors.Default;
            int r = PromptFiltryPromien.ShowDialog("Wybierz promień filtru");
            Cursor = Cursors.WaitCursor;

            if (r == 0)
                return;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            int minR, minG, minB;
            int[][] arrR = FiltrGenColorArray('r');
            int[][] arrG = FiltrGenColorArray('g');
            int[][] arrB = FiltrGenColorArray('b');

            Color k3;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {

                    if (x <= r || x >= wid - r - 1 || y <= r || y >= hei - r - 1)
                    {
                        b3.SetPixel(x, y, b1.GetPixel(x,y));
                    }
                    else
                    {
                        minR = arrR[x][y]; minG = arrG[x][y]; minB = arrB[x][y];

                        for (int i = -r; i <= r; i++)
                        {
                            for (int j = -r; j <= r; j++)
                            {
                                if (arrR[x + i][y + j] < minR)
                                    minR = arrR[x + i][y + j];
                                if (arrG[x + i][y + j] < minG)
                                    minG = arrG[x + i][y + j];
                                if (arrB[x + i][y + j] < minB)
                                    minB = arrB[x + i][y + j];
                            }
                        }

                        k3 = Color.FromArgb(checkRGBRange(minR), checkRGBRange(minG), checkRGBRange(minB));

                        b3.SetPixel(x, y, k3);
                    }

                }
            }

            pictureBox3.Refresh();

        }

        private void FiltrMax()
        {
            Cursor = Cursors.Default;
            int r = PromptFiltryPromien.ShowDialog("Wybierz promień filtru");
            Cursor = Cursors.WaitCursor;

            if (r == 0)
                return;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            int maxR, maxG, maxB;
            int[][] arrR = FiltrGenColorArray('r');
            int[][] arrG = FiltrGenColorArray('g');
            int[][] arrB = FiltrGenColorArray('b');

            Color k3;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {

                    if (x <= r || x >= wid - r - 1 || y <= r || y >= hei - r - 1)
                    {
                        b3.SetPixel(x, y, b1.GetPixel(x, y));
                    }
                    else
                    {
                        maxR = arrR[x][y]; maxG = arrG[x][y]; maxB = arrB[x][y];

                        for (int i = -r; i <= r; i++)
                        {
                            for (int j = -r; j <= r; j++)
                            {
                                if (arrR[x + i][y + j] > maxR)
                                    maxR = arrR[x + i][y + j];
                                if (arrG[x + i][y + j] > maxG)
                                    maxG = arrG[x + i][y + j];
                                if (arrB[x + i][y + j] > maxB)
                                    maxB = arrB[x + i][y + j];
                            }
                        }

                        k3 = Color.FromArgb(checkRGBRange(maxR), checkRGBRange(maxG), checkRGBRange(maxB));

                        b3.SetPixel(x, y, k3);
                    }

                }
            }

            pictureBox3.Refresh();

        }

        private void FiltrMedianowy()
        {
            Cursor = Cursors.Default;
            int r = PromptFiltryPromien.ShowDialog("Wybierz promień filtru");
            Cursor = Cursors.WaitCursor;

            if (r == 0)
                return;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;
            int medR, medG, medB, divider = (2 * r + 1) * (2 * r + 1);
            int[][] arrR = FiltrGenColorArray('r');
            int[][] arrG = FiltrGenColorArray('g');
            int[][] arrB = FiltrGenColorArray('b');

            Color k3;
            for (int x = 0; x < wid; x++)
            {
                for (int y = 0; y < hei; y++)
                {

                    if (x <= r || x >= wid - r - 1 || y <= r || y >= hei - r - 1)
                    {
                        b3.SetPixel(x, y, b1.GetPixel(x, y));
                    }
                    else
                    {
                        medR = 0; medG = 0; medB = 0;

                        for (int i = -r; i <= r; i++)
                        {
                            for (int j = -r; j <= r; j++)
                            {

                                medR += arrR[x + i][y + j];
                                medG += arrG[x + i][y + j];
                                medB += arrB[x + i][y + j];
                            }
                        }

                        medR /= divider; medG /= divider; medB /= divider;

                        k3 = Color.FromArgb(checkRGBRange(medR), checkRGBRange(medG), checkRGBRange(medB));

                        b3.SetPixel(x, y, k3);
                    }

                }
            }

            pictureBox3.Refresh();

        }

        public Form1()
        {
            InitializeComponent();
        }

        //transformacja
        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            double[] promptValue = PromptTransformacja.ShowDialog("Podaj współczynniki");

            if (promptValue[0] == 1.0 && promptValue[1] == 0.0)
                return;   

            Cursor = Cursors.WaitCursor;

            if (PromptTransformacja.rb1.Checked)
                TransformacjaLiniowa(promptValue);
            else if (PromptTransformacja.rb2.Checked)
                TransformacjaPotegowa(promptValue);

            Cursor = Cursors.Default;
        }

        //mieszanie
        private void button6_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null || pictureBox2.Image == null)
                return;

            double promptValue = PromptMieszanie.ShowDialog("Wybierz rodzaj mieszania");

            Cursor = Cursors.WaitCursor;

            int choice=-1;
            for (int i = 0; i < PromptMieszanie.rbArr.Length; i++)
                if (PromptMieszanie.rbArr[i].Checked)
                    choice = i;

            switch (choice)
            {
                case (-1):
                    break;
                case (0):
                    {
                        MieszanieSuma();
                        break;
                    }
                case (1):
                    {
                        MieszanieOdejmowanie();
                        break;
                    }
                case (2):
                    {
                        MieszanieRoznica();
                        break;
                    }
                case (3):
                    {
                        MieszanieMnozenie();
                        break;
                    }
                case (4):
                    {
                        MieszanieMnozenieOdwrotnosci();
                        break;
                    }
                case (5):
                    {
                        MieszanieNegacja();
                        break;
                    }
                case (6):
                    {
                        MieszanieCiemniejsze();
                        break;
                    }
                case (7):
                    {
                        MieszanieJasniejsze();
                        break;
                    }
                case (8):
                    {
                        MieszanieWylaczenie();
                        break;
                    }
                case (9):
                    {
                        MieszanieNakladka();
                        break;
                    }
                case (10):
                    {
                        MieszanieOstreSwiatlo();
                        break;
                    }
                case (11):
                    {
                        MieszanieLagodneSwiatlo();
                        break;
                    }
                case (12):
                    {
                        MieszanieRozcienczenie();
                        break;
                    }
                case (13):
                    {
                        MieszanieWypalenie();
                        break;
                    }
                case (14):
                    {
                        MieszanieReflectMode();
                        break;
                    }
                case (15):
                    {
                        MieszaniePrzezroczystosc(promptValue);
                        break;
                    }
            }

            Cursor = Cursors.Default;
        }

        //czyszczenie wyniku
        private void button7_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = new Bitmap(biggerWid, biggerHei);
        }

        //kontrast
        private void button8_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            int promptValue = PromptKontrast.ShowDialog("Podaj współczynnik");

            if (promptValue == 0)
                return;

            Cursor = Cursors.WaitCursor;

            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            Color k1, k3;
            int red, green, blue;
            int[] rgb = new int[3];
            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    k1 = b1.GetPixel(x, y);

                    if (PromptKontrast.rb1.Checked)
                        rgb = kontrastW1(k1, promptValue);
                    else if (PromptKontrast.rb2.Checked)
                        rgb = kontrastW2(k1, promptValue);
                    else
                    {
                        Cursor = Cursors.Default;
                        return;
                    }

                    k3 = Color.FromArgb(checkRGBRange(rgb[0]), checkRGBRange(rgb[1]),
                        checkRGBRange(rgb[2]));
                    b3.SetPixel(x, y, k3);
                }
            }
            pictureBox3.Refresh();

            Cursor = Cursors.Default;

        }

        //histogram
        private void button9_Click(object sender, EventArgs e)
        {
            if (pictureBox3.Image == null)
                return;

            Cursor = Cursors.WaitCursor;

            Histogram('r');
            Histogram('g');
            Histogram('b');

            Cursor = Cursors.Default;
        }

        //wyrównanie histogramu
        private void button10_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            Cursor = Cursors.WaitCursor;
            WyrownanieHistogramu();
            Cursor = Cursors.Default;
        }

        //skalowanie histogramu
        private void button11_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            int[] promptValue = PromptSkalHist.ShowDialog("Podaj współczynnik");
            int a = promptValue[0], b = promptValue[1], c = promptValue[2], d = promptValue[3];

            Cursor = Cursors.WaitCursor;
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b3 = (Bitmap)pictureBox3.Image;

            Color k1, k3;
            int red, green, blue;

            for (int x = 0; x < biggerWid; x++)
            {
                for (int y = 0; y < biggerHei; y++)
                {
                    k1 = b1.GetPixel(x, y);

                    red = (k1.R - a) * (d - c) / (b - a) + c;
                    green = (k1.G - a) * (d - c) / (b - a) + c;
                    blue = (k1.B - a) * (d - c) / (b - a) + c;

                    k3 = Color.FromArgb(checkRGBRange(red), checkRGBRange(green),
                        checkRGBRange(blue));
                    b3.SetPixel(x, y, k3);
                }
            }


                    pictureBox3.Refresh();
            Cursor = Cursors.Default;
        }

        //filtry
        private void button5_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
                return;

            PromptFiltry.ShowDialog("Wybierz rodzaj filtracji");

            Cursor = Cursors.WaitCursor;

            pictureBox2.Image = new Bitmap(wid, hei);

            int choice = -1;
            for (int i = 0; i < PromptFiltry.rbArr.Length; i++)
                if (PromptFiltry.rbArr[i].Checked)
                    choice = i;

            switch (choice)
            {
                case (-1):
                    break;
                case (0):
                    {
                        FiltrRobertsPion();
                        break;
                    }
                case (1):
                    {
                        FiltrRobertsPoziom();
                        break;
                    }
                case (2):
                    {
                        FiltrPrewittPion();
                        break;
                    }
                case (3):
                    {
                        FiltrPrewittPoziom();
                        break;
                    }
                case (4):
                    {
                        FiltrSobelPion();
                        break;
                    }
                case (5):
                    {
                        FiltrSobelPoziom();
                        break;
                    }
                case (6):
                    {
                        FiltrLaplace(); 
                        break;
                    }
                case (7):
                    {
                        FiltrMin();
                        break;
                    }
                case (8):
                    {
                        FiltrMax();
                        break;
                    }
                case (9):
                    {
                        FiltrMedianowy();
                        break;
                    }
            }

            Cursor = Cursors.Default;
        }

        //odczyt obrazu 2
        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.Load(openFileDialog2.FileName);
                wid2 = pictureBox2.Image.Width;
                hei2 = pictureBox2.Image.Height;

                biggerWid = (wid < wid2) ? wid2 : wid;
                biggerHei = (hei < hei2) ? hei2 : hei;

                pictureBox3.Image = new Bitmap(biggerWid, biggerHei);
            }
        }

        //odczyt obrazu 1
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
                wid = pictureBox1.Image.Width;
                hei = pictureBox1.Image.Height;

                biggerWid = (wid < wid2) ? wid2 : wid;
                biggerHei = (hei < hei2) ? hei2 : hei;

                pictureBox3.Image = new Bitmap(biggerWid, biggerHei);
            }
        }


        //zamknięcie;
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public static class PromptTransformacja
    {
        public static RadioButton rb1;
        public static RadioButton rb2;

        public static double[] ShowDialog(string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            rb1 = new RadioButton() { Left = 10, Top = 5, Text = "Liniowa" }; 
            rb2 = new RadioButton() { Left = 200, Top = 5, Text = "Potęgowa" };

            Label textLabel = new Label() { Left = 10, Top = 30, Text = "Nachylenie" };
            TextBox textBox = new TextBox() { Left = 10, Top = 45, Width = 300, Text = "1,0" };
            Label textLabel2 = new Label() { Left = 10, Top = 65, Text = "Zmiana jasności" };
            TrackBar valTrackBar = new TrackBar() { Left = 10, Top = 80, Width = 300, Minimum = -255, Maximum = 255, Value = 0, TickFrequency = 1 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            Button cancelation = new Button() { Text = "Anuluj", Left = 350, Width = 100, Top = 45, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancelation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(rb1);
            prompt.Controls.Add(rb2);
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(valTrackBar);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelation);
            prompt.Controls.Add(textLabel);
            prompt.Controls.Add(textLabel2);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelation;

            return prompt.ShowDialog() == DialogResult.OK ? new double[] { double.Parse(textBox.Text), valTrackBar.Value } : new double[] { 1.0, 0.0 };
        }
    }

    public static class PromptMieszanie
    {
        public static RadioButton[] rbArr;

        public static double ShowDialog(string caption)
        {
            int radbuttsHei = 20 * 16 + 5;
            Form prompt = new Form()
            {
                Width = 250,
                Height = 500,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            rbArr = new RadioButton[16];
            for(int i=0;i<rbArr.Length;i++)
            {
                rbArr[i] = new RadioButton();
                rbArr[i].Left = 10;
                rbArr[i].Width = prompt.Width;
                rbArr[i].Top = 5 + i * 20;
                prompt.Controls.Add(rbArr[i]);
            }
            rbArr[0].Text = "Suma";
            rbArr[1].Text = "Odejmowanie";
            rbArr[2].Text = "Różnica";
            rbArr[3].Text = "Mnożenie";
            rbArr[4].Text = "Mnożenie odwrotności";
            rbArr[5].Text = "Negacja";
            rbArr[6].Text = "Ciemniejsze";
            rbArr[7].Text = "Jaśniejsze";
            rbArr[8].Text = "Wyłączenie";
            rbArr[9].Text = "Nakładka";
            rbArr[10].Text = "Ostre światło";
            rbArr[11].Text = "Łagodne światło";
            rbArr[12].Text = "Rozcieńczenie";
            rbArr[13].Text = "Wypalenie";
            rbArr[14].Text = "Reflect mode";
            rbArr[15].Text = "Przezroczystość";

            Label textLabel = new Label() { Left = 10, Top = radbuttsHei+10, Width=prompt.Width, Text = "alfa (tylko dla przezroczystości)" };
            TrackBar valTrackBar = new TrackBar() { Left = 10, Top = radbuttsHei+30, Width = 210, Minimum = 0, Maximum = 100, Value = 0, TickFrequency = 1 };
            Button confirmation = new Button() { Text = "Ok", Left = 10, Width = 100, Top = radbuttsHei+80, DialogResult = DialogResult.OK };
            Button cancelation = new Button() { Text = "Anuluj", Left = 125, Width = 100, Top = radbuttsHei+80, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancelation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(valTrackBar);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelation;

            return prompt.ShowDialog() == DialogResult.OK ? (double)valTrackBar.Value/100 : 0.0;
        }
    }

    public static class PromptKontrast
    {
        public static RadioButton rb1;
        public static RadioButton rb2;
        public static int ShowDialog(string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 160,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            rb1 = new RadioButton() { Left = 10, Top = 80, Text = "Wariant 1" };
            rb2 = new RadioButton() { Left = 160, Top = 80, Text = "Wariant 2" };

            Label textLabel = new Label() { Left = 10, Top = 10, Width=prompt.Width, Text = "Wartość kontrastu" };
            TrackBar valTrackBar = new TrackBar() { Left = 10, Top = 30, Width = 300, Minimum = -127, Maximum = 126, Value = 0, TickFrequency = 1 };
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            Button cancelation = new Button() { Text = "Anuluj", Left = 350, Width = 100, Top = 45, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancelation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(rb1);
            prompt.Controls.Add(rb2);
            prompt.Controls.Add(valTrackBar);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelation;

            return prompt.ShowDialog() == DialogResult.OK ? valTrackBar.Value  : 0 ;
        }
    }

    public static class PromptHistogram
    {

        public static void ShowDialog(string caption, Bitmap img)
        {

            Form prompt = new Form()
            {
                Width = 300,
                Height = 250,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            PictureBox pb = new PictureBox() { Left = 10, Top = 10, SizeMode = PictureBoxSizeMode.AutoSize };
            pb.Image = img;

            prompt.Controls.Add(pb);

            prompt.ShowDialog();
        }
    }

    public static class PromptSkalHist
    {
        public static int[] ShowDialog(string caption)
        {
            Form prompt = new Form()
            {
                Width = 500,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };


            Label textLabel1 = new Label() { Left = 10, Top = 10, Width=100, Text = "Parametr a" };
            TextBox textBox1 = new TextBox() { Left = 150, Top = 10, Width = 100, Text = "1,0" };
            Label textLabel2 = new Label() { Left = 10, Top = 30, Width = 100, Text = "Parametr b" };
            TextBox textBox2 = new TextBox() { Left = 150, Top = 30, Width = 100, Text = "1,0" };
            Label textLabel3 = new Label() { Left = 10, Top = 50, Width = 100, Text = "Parametr c" };
            TextBox textBox3 = new TextBox() { Left = 150, Top = 50, Width = 100, Text = "1,0" };
            Label textLabel4 = new Label() { Left = 10, Top = 70, Width = 100, Text = "Parametr d" };
            TextBox textBox4 = new TextBox() { Left = 150, Top = 70, Width = 100, Text = "1,0" };

            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            Button cancelation = new Button() { Text = "Anuluj", Left = 350, Width = 100, Top = 45, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancelation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelation);
            prompt.Controls.Add(textLabel1);
            prompt.Controls.Add(textBox1);
            prompt.Controls.Add(textLabel2);
            prompt.Controls.Add(textBox2);
            prompt.Controls.Add(textLabel3);
            prompt.Controls.Add(textBox3);
            prompt.Controls.Add(textLabel4);
            prompt.Controls.Add(textBox4);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelation;

            return prompt.ShowDialog() == DialogResult.OK ?
                new int[] { int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text), } :
                new int[] { 0, 1, 0, 1 };
        }
    }

    public static class PromptFiltry
    {
        public static RadioButton[] rbArr;

        public static void ShowDialog(string caption)
        {
            int radbuttsHei = 20 * 10 + 5;
            Form prompt = new Form()
            {
                Width = 250,
                Height = 300,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            rbArr = new RadioButton[10];
            for (int i = 0; i < rbArr.Length; i++)
            {
                rbArr[i] = new RadioButton();
                rbArr[i].Left = 10;
                rbArr[i].Width = prompt.Width;
                rbArr[i].Top = 5 + i * 20;
                prompt.Controls.Add(rbArr[i]);
            }
            rbArr[0].Text = "Roberts (pionowy)";
            rbArr[1].Text = "Roberts (poziomy)";
            rbArr[2].Text = "Prewitt (pionowy)";
            rbArr[3].Text = "Prewitt (poziomy)";
            rbArr[4].Text = "Sobel (pionowy)";
            rbArr[5].Text = "Sobel (poziomy)";
            rbArr[6].Text = "Laplace'a";
            rbArr[7].Text = "min";
            rbArr[8].Text = "max";
            rbArr[9].Text = "medianowy";
            
            Button confirmation = new Button() { Text = "Ok", Left = 10, Width = 100, Top = radbuttsHei + 20, DialogResult = DialogResult.OK };
            Button cancelation = new Button() { Text = "Anuluj", Left = 125, Width = 100, Top = radbuttsHei + 20, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancelation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelation);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelation;

            prompt.ShowDialog();
        }
    }

    public static class PromptFiltryLaplace
    {
        public static RadioButton rb1, rb2, rb3;

        public static void ShowDialog(string caption)
        {
            Form prompt = new Form()
            {
                Width = 250,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            rb1 = new RadioButton() { Left = 10, Width = prompt.Width, Top = 10, Text = "-1, 0, 4" };
            rb2 = new RadioButton() { Left = 10, Width = prompt.Width, Top = 30, Text = "-1, 8" };
            rb3 = new RadioButton() { Left = 10, Width = prompt.Width, Top = 50, Text = "-2, 1, 4" };

            Button confirmation = new Button() { Text = "Ok", Left = 10, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            Button cancelation = new Button() { Text = "Anuluj", Left = 125, Width = 100, Top = 80, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancelation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(rb1);
            prompt.Controls.Add(rb2);
            prompt.Controls.Add(rb3);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelation);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelation;

            prompt.ShowDialog();
        }
    }

    public static class PromptFiltryPromien
    {
        public static int ShowDialog(string caption)
        {
            Form prompt = new Form()
            {
                Width = 250,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };

            NumericUpDown nud = new NumericUpDown() { Left = 10, Top = 10, Width = prompt.Width-30, Minimum = 1, Maximum = 20, Value = 1 };

            Button confirmation = new Button() { Text = "Ok", Left = 10, Width = 100, Top = 50, DialogResult = DialogResult.OK };
            Button cancelation = new Button() { Text = "Anuluj", Left = 125, Width = 100, Top = 50, DialogResult = DialogResult.Cancel };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            cancelation.Click += (sender, e) => { prompt.Close(); };

            prompt.Controls.Add(nud);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancelation);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancelation;

            return prompt.ShowDialog() == DialogResult.OK ? (int)nud.Value : 0;
        }
    }

}
