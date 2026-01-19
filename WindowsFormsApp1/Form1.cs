using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

//4 Connected 
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Point[] vertices = new Point[] { new Point(50, 50), new Point(200, 50), new Point(200, 200), new Point(100, 150), new Point(50, 200) };

            e.Graphics.DrawPolygon(Pens.Black, vertices);

            FourConnectedFill(vertices, e.Graphics);
        }

        private static void FourConnectedFill(Point[] vertices, Graphics g)
        {
            int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue;
            foreach (Point p in vertices)
            {
                if (p.X < minX)
                    minX = p.X;
                if (p.Y < minY)
                    minY = p.Y;
                if (p.X > maxX)
                    maxX = p.X;
                if (p.Y > maxY)
                    maxY = p.Y;
            }

            bool[,] fillState = new bool[maxX - minX + 1, maxY - minY + 1];

            Stack<Point> stack = new Stack<Point>();

            Point seed = new Point((minX + maxX) / 2, (minY + maxY) / 2);

            fillState[seed.X - minX, seed.Y - minY] = true;

            stack.Push(seed);

            while (stack.Count > 0)
            {
                Point pixel = stack.Pop();

                // Check the four neighbors of the pixel
                int x = pixel.X - minX, y = pixel.Y - minY;
                if (x > 0 && !fillState[x - 1, y])
                {
                    fillState[x - 1, y] = true;
                    stack.Push(new Point(pixel.X - 1, pixel.Y));
                }
                if (x < fillState.GetLength(0) - 1 && !fillState[x + 1, y])
                {
                    fillState[x + 1, y] = true;
                    stack.Push(new Point(pixel.X + 1, pixel.Y));
                }
                if (y > 0 && !fillState[x, y - 1])
                {
                    fillState[x, y - 1] = true;
                    stack.Push(new Point(pixel.X, pixel.Y - 1));
                }
                if (y < fillState.GetLength(1) - 1 && !fillState[x, y + 1])
                {
                    fillState[x, y + 1] = true;
                    stack.Push(new Point(pixel.X, pixel.Y + 1));
                }
            }

            // Fill the polygon with the fill state of each pixel
            for (int i = 0; i < vertices.Length; i++)
            {
                vertices[i].X -= minX;
                vertices[i].Y -= minY;
            }
            for (int y = 0; y < fillState.GetLength(1); y++)
            {
                int x1 = -1;
                for (int x = 0; x < fillState.GetLength(0); x++)
                {
                    if (fillState[x, y])
                    {
                        if (x1 == -1)
                            x1 = x;
                        else if (x == fillState.GetLength(0) - 1)
                            g.DrawLine(Pens.Blue, x1 + minX, y + minY, x + minX, y + minY);
                    }
                    else
                    {
                        if (x1 != -1)
                        {
                            g.DrawLine(Pens.Blue, x1 + minX, y + minY, x - 1 + minX, y + minY);
                            x1 = -1;
                        }
                    }
                }
            }
        }
    }
}
