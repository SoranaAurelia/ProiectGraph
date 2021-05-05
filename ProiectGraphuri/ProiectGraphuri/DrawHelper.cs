using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectGraphuri
{
    class DrawHelper
    {
        int circleRadius = 20;
        Pen pen;
        Color penColor = Color.Black;
        int penWidth = 2;
        public Graphics graphics;
        int nmbVertex = 0;
        Font font = new Font("Arial", 10);
        List<Point> vertices = new List<Point>();
        int selectedIndex1 = -1, selectedIndex2 = -1;
        public UndirectedGraph formed_ug = new UndirectedGraph();

        public DrawHelper()
        {
            pen = new Pen(penColor, penWidth);
            //graphics = panel.CreateGraphics();
        }

        public DrawHelper(Color PenColor, int PenWidth, int CircleRadius, Panel panel)
        {
            penColor = PenColor;
            penWidth = PenWidth;
            circleRadius = CircleRadius;

            pen = new Pen(penColor, penWidth);
            //graphics = panel.CreateGraphics();
        }

        public void Clear()
        {
            vertices.Clear();
            nmbVertex = 0;
            graphics.Clear(Color.AliceBlue);
        }

        public void drawVertex(int posX, int posY)
        {
            if (touchMargin(posX, posY) &&
                noIntersections(posX - circleRadius / 2, posY - circleRadius / 2))
            {
                drawNmb(posX, posY);
                graphics.DrawEllipse(pen, posX - circleRadius / 2, posY - circleRadius / 2, circleRadius, circleRadius);
                vertices.Add(new Point(posX - circleRadius / 2, posY - circleRadius / 2));
            }
        }

        public void selectVertex(int posX, int posY)
        {
            int index = 0;
            foreach(Point act in vertices)
            {
                if (distance(posX, posY, act.X, act.Y) <= circleRadius)
                {
                    graphics.DrawEllipse(new Pen(Color.ForestGreen, penWidth), act.X - 2, act.Y - 2, circleRadius+4, circleRadius+4);
                    if (selectedIndex1 == -1)
                        selectedIndex1 = index;
                    else
                    {
                        if(selectedIndex1 == index)
                        {
                            graphics.DrawEllipse(new Pen(Color.AliceBlue, penWidth), vertices[selectedIndex1].X - 2, vertices[selectedIndex1].Y - 2, circleRadius + 4, circleRadius + 4);
                            selectedIndex1 = -1;
                            return;
                        }
                        selectedIndex2 = index;
                        formed_ug.nmbEdges++;
                        formed_ug.addEdge(selectedIndex1 + 1, selectedIndex2 + 1);
                        drawLine(vertices[selectedIndex1], vertices[selectedIndex2]);
                        graphics.DrawEllipse(new Pen(Color.AliceBlue, penWidth), vertices[selectedIndex1].X - 2, vertices[selectedIndex1].Y - 2, circleRadius + 4, circleRadius + 4);
                        graphics.DrawEllipse(new Pen(Color.AliceBlue, penWidth), vertices[selectedIndex2].X - 2, vertices[selectedIndex2].Y - 2, circleRadius + 4, circleRadius + 4);
                        selectedIndex1 = selectedIndex2 = -1;
                    }
                    return;
                }
                index++;

            }
        }
        public void drawLine(Point A, Point B)
        {
            int radius = circleRadius / 2;
            A.X += radius;
            A.Y += radius;
            B.X += radius;
            B.Y += radius;
            double m = 1.0 * (A.Y - B.Y) / (A.X - B.X);
            Point Aaux = new Point(Convert.ToInt32(A.X + sgn(A, B, 'x')*Math.Sqrt(radius * radius / (m * m +1 ))),
                                    Convert.ToInt32(A.Y + sgn(A, B, 'y')*Math.Sqrt(radius * radius / (1/(m * m) + 1))));
            Point Baux = new Point(Convert.ToInt32(B.X - sgn(A, B, 'x')*Math.Sqrt(radius * radius / (m * m + 1))),
                                    Convert.ToInt32(B.Y - sgn(A, B, 'y')*Math.Sqrt(radius * radius / (1 / (m * m) + 1))));


            graphics.DrawLine(pen, Aaux, Baux);
        }

        int sgn(Point A, Point B, char v)
        {
            if(v == 'x')
            {
                if (B.X > A.X)
                    return 1;
                return -1;
            }
            else
            {
                if (B.Y > A.Y)
                    return 1;
                return -1;
            }
        }

        public void drawNmb(int posX, int posY)
        {
            nmbVertex++;
            formed_ug.NmbVertices++;
            SolidBrush drawBrush = new SolidBrush(penColor);
            graphics.DrawString(nmbVertex + "", font, drawBrush, new PointF(posX - circleRadius/2 + 5 - Convert.ToInt32(nmbVertex/10 != 0)*5, posY - circleRadius/2 + 3));
        }



        bool noIntersections(int x, int y)
        {
            foreach(Point act in vertices)
            {
                if (distance(x, y, act.X, act.Y) <= circleRadius+5)
                    return false;
            }
            return true;
        }

        bool touchMargin(int x, int y)
        {
            if (x < circleRadius / 2 + 5 || x > 210 - circleRadius / 2 ||
                y < circleRadius / 2 + 5 || y > 310 - circleRadius / 2)
                return false;
            return true;
        }


        int distance(int xa, int ya, int xb, int yb)
        {
            return Convert.ToInt32(Math.Floor(Math.Sqrt((xa - xb) * (xa - xb) + (ya - yb) * (ya - yb)))) + 1;
        }

    }
}
