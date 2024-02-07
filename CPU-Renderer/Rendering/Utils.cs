using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering
{
    public static class Utils
    {
        public static float AngleToRadians(float angle)
        {
            return (float)(angle * Math.PI / 180.0f);
        }

        public static float PowFloats(float a, int b)
        {
            float pow = 1;
            for (int i = 0; i < b; i++)
            {
                pow *= a;
            }
            return pow;
        }

        public static (float alfa, float beta, float gamma) GetBar(PointF P, Triangle triangle)
        {
            var A = triangle.A.P;
            var B = triangle.B.P;
            var C = triangle.C.P;
            float alfa = ((B.Y * C.X - C.Y * B.X) + (C.Y * P.X - P.Y * C.X) + (P.Y * B.X - B.Y * P.X)) /
                ((B.Y * C.X - C.Y * B.X) + (C.Y * A.X - A.Y * C.X) + (A.Y * B.X - B.Y * A.X));
            float beta = ((C.Y * A.X - A.Y * C.X) + (A.Y * P.X - P.Y * A.X) + (P.Y * C.X - C.Y * P.X)) /
                ((B.Y * C.X - C.Y * B.X) + (C.Y * A.X - A.Y * C.X) + (A.Y * B.X - B.Y * A.X));
            float gamma = 1 - alfa - beta;
            return (alfa, beta, gamma);
        }
        public static Color Vec3ToColor(Vector3 I)
        {
            return Color.FromArgb((byte)(I.X * 255), (byte)(I.Y * 255), (byte)(I.Z * 255));
        }

        public static Vector3 Vector3FromColor(Color color)
        {
            return new Vector3()
            {
                X = (float)color.R / 255,
                Y = (float)color.G / 255,
                Z = (float)color.B / 255,
            };
        }
    }
}
