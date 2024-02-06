using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_Renderer.Rendering
{
    public static class Drawing
    {
        private static void DrawLineDown(LockBitmap lb, Color color, Point a, Point b)
        {
            int dx = b.X - a.X, dy = b.Y - a.Y, yi = 1;
            if (dy < 0)
            {
                yi = -1;
                dy = -dy;
            }
            int d0 = (2 * dy) - dx;
            for (int x = a.X, y = a.Y; x <= b.X; x++)
            {
                lb.SetPixel(x, y, color);
                if (d0 > 0)
                {
                    y += yi;
                    d0 += 2 * (dy - dx);
                }
                else
                    d0 += 2 * dy;
            }

        }
        private static void DrawLineUp(LockBitmap lb, Color color, Point a, Point b)
        {
            int dx = b.X - a.X, dy = b.Y - a.Y, xi = 1;
            if (dx < 0)
            {
                xi = -1;
                dx = -dx;
            }
            int d0 = (2 * dx) - dy;
            for (int x = a.X, y = a.Y; y <= b.Y; y++)
            {
                lb.SetPixel(x, y, color);
                if (d0 > 0)
                {
                    x += xi;
                    d0 += 2 * (dx - dy);
                }
                else
                    d0 += 2 * dx;
            }
        }
        private static void DrawLineWithBresenham(LockBitmap lb, Color color, Point a, Point b)
        {
            if (Math.Abs(b.Y - a.Y) < Math.Abs(b.X - a.X))
            {
                if (a.X > b.X)
                    DrawLineDown(lb, color, b, a);
                else
                    DrawLineDown(lb, color, a, b);
            }
            else
            {
                if (a.Y > b.Y)
                    DrawLineUp(lb, color, b, a);
                else
                    DrawLineUp(lb, color, a, b);
            }
        }
        public static void DrawLine(LockBitmap lb, Color color, Point a, Point b)
        {
            DrawLineWithBresenham(lb, color, new Point(a.X, lb.Height - a.Y), new Point(b.X, lb.Height - b.Y));
        }

        public static void ClearLB(LockBitmap lb, Color c)
        {
            for (int x = 0; x < lb.Width; x++)
                for (int y = 0; y < lb.Height; y++)
                    lb.SetPixel(x, y, c);
        }

        public static void DrawTriangleEdges(LockBitmap lb, Triangle triangle)
        {
            Point A = new Point((int)triangle.A.P.X, (int)triangle.A.P.Y);
            Point B = new Point((int)triangle.B.P.X, (int)triangle.B.P.Y);
            Point C = new Point((int)triangle.C.P.X, (int)triangle.C.P.Y);
            var points = new Point[] {A, B, C};
            for (int i = 0; i < points.Length; i++)
            {
                if (points[i].X >= lb.Width)
                    points[i] = new Point(lb.Width - 1, points[i].Y);
                if (points[i].X <= 0)
                    points[i] = new Point(1, points[i].Y);
                if (points[i].Y >= lb.Height)
                    points[i] = new Point(points[i].X, lb.Height - 1);
                if (points[i].Y <= 0)
                    points[i] = new Point(points[i].X, 1);
            }
            try
            {
                Drawing.DrawLine(lb, triangle.A.Color, points[2], points[0]);
                Drawing.DrawLine(lb, triangle.A.Color, points[0], points[1]);
                Drawing.DrawLine(lb, triangle.A.Color, points[1], points[2]);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
