﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering.PixelOperations
{
    public static class Rasterization
    {
        private struct AETev
        {
            public float x;
            public int ymax;
            public float coeff;

            public AETev DoStep()
            {
                return new AETev() { coeff = this.coeff, x = this.x + this.coeff, ymax = this.ymax };
            }
        }

        private static float GetCoeff(Point p1, Point p2)
        {
            Point a = (p1.X >= p2.X) ? p2 : p1;
            Point b = (p1.X >= p2.X) ? p1 : p2;
            return (float)(b.X - a.X) / (b.Y - a.Y);
        }

        public static List<Pixel> RasterizeWithScanLine(Triangle triangle)
        {
            List<Pixel> pixels = new List<Pixel>();
            Point[] points = new Point[] {
                new Point((int)triangle.A.P.X, (int)triangle.A.P.Y),
                new Point((int)triangle.B.P.X, (int)triangle.B.P.Y),
                new Point((int)triangle.C.P.X, (int)triangle.C.P.Y)
            };
            int n = points.Length;
            List<AETev> AET = new List<AETev>();
            int[] sortedPoints = points.Select((x, i) => new KeyValuePair<Point, int>(x, i))
                .OrderBy(x => x.Key.Y).Select(x => x.Value).ToArray();

            int ymin = points[sortedPoints[0]].Y; int ymax = points[sortedPoints[sortedPoints.Length - 1]].Y;
            int lastFound = -1, prev, next;
            for (int y = ymin + 1; y <= ymax; y++)
            {
                while (lastFound < n)
                {
                    Point curPoint = points[sortedPoints[lastFound + 1]];
                    if (curPoint.Y > y - 1)
                        break;
                    lastFound++;
                    prev = (sortedPoints[lastFound] - 1 < 0) ? n - 1 : sortedPoints[lastFound] - 1;
                    next = (sortedPoints[lastFound] + 1) % n;
                    if (points[next].Y > y - 1)
                        AET.Add(new AETev { coeff = GetCoeff(curPoint, points[next]), x = curPoint.X, ymax = points[next].Y });
                    else if (points[next].Y < y - 1)
                        AET.Remove(new AETev { coeff = GetCoeff(curPoint, points[next]), x = curPoint.X, ymax = curPoint.Y });
                    if (points[prev].Y > y - 1)
                        AET.Add(new AETev { coeff = GetCoeff(curPoint, points[prev]), x = curPoint.X, ymax = points[prev].Y });
                    else if (points[prev].Y < y - 1)
                        AET.Remove(new AETev { coeff = GetCoeff(curPoint, points[prev]), x = curPoint.X, ymax = curPoint.Y });
                }

                AET = AET.OrderBy(x => x.x).ToList();

                for (int i = 0; i < AET.Count; i += 2)
                {
                    if (i == AET.Count - 1)
                        continue;
                    for (int x = (int)AET[i].x; x < AET[i + 1].x; x++)
                    {
                        var pf = new PointF(x, y);
                        var bar = Utils.GetBar(pf, triangle);
                        Vector4 P = new Vector4()
                        {
                            X = pf.X,
                            Y = pf.Y,
                            Z = bar.alfa * triangle.A.P.Z + bar.beta * triangle.B.P.Z + bar.gamma * triangle.C.P.Z,
                            W = 1
                        };
                        pixels.Add(new Pixel()
                        {
                            P = P,
                            WP = bar.alfa * triangle.A.WP + bar.beta * triangle.B.WP + bar.gamma * triangle.C.WP,
                            N = bar.alfa * triangle.A.N + bar.beta * triangle.B.N + bar.gamma * triangle.C.N,
                            Color = triangle.A.Color,
                            Material = triangle.A.Material,
                        });
                    }
                }

                for (int i = 0; i < AET.Count; i++)
                {
                    AET[i] = AET[i].DoStep();
                }
            }
            return pixels;
        }

    }
}
