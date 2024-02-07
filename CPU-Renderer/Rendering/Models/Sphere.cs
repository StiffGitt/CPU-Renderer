using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering.Models
{
    public class Sphere : Model
    {
        private Color color;
        private List<Triangle> mesh;
        private float r = 1.0f;
        public static int parallelsCount = 10;
        public static int meridiansCount = 10;

        public Sphere(Color color, Vector3 translation, Vector3 scale, Vector3 pivot)
        {
            this.color = color;
            base.Translation = translation;
            base.Scale = scale;
            base.Pivot = pivot;
            MakeTriangulation();
        }

        private void MakeTriangulation()
        {
            mesh = new List<Triangle>();
            float pStep = MathF.PI / parallelsCount;
            float mStep = 2.0f * MathF.PI / meridiansCount;

            for(int i = 0; i < parallelsCount; i++)
            {
                float pAngle = pStep * i, pAngleNext = pStep * ((i + 1) % parallelsCount);
                for (int j = 0;  j < meridiansCount; j++)
                {
                    float mAngle = mStep * j, mAngleNext = mStep * ((j + 1) % meridiansCount);
                    Vector4 P1 = new Vector4(
                        r * MathF.Sin(pAngle) * MathF.Cos(mAngle), r * MathF.Cos(pAngle), r * MathF.Sin(pAngle) * MathF.Sin(mAngle), 1);
                    Vector4 P2 = new Vector4(
                        r * MathF.Sin(pAngle) * MathF.Cos(mAngleNext), r * MathF.Cos(pAngle), r * MathF.Sin(pAngle) * MathF.Sin(mAngleNext), 1);
                    Vector4 P3 = new Vector4(
                        r * MathF.Sin(pAngleNext) * MathF.Cos(mAngleNext), r * MathF.Cos(pAngleNext), r * MathF.Sin(pAngleNext) * MathF.Sin(mAngleNext), 1);
                    Vector4 P4 = new Vector4(
                        r * MathF.Sin(pAngleNext) * MathF.Cos(mAngle), r * MathF.Cos(pAngleNext), r * MathF.Sin(pAngleNext) * MathF.Sin(mAngle), 1);
                    Vector4 N1 = Vector4.Normalize(new Vector4(P1.X, P1.Y, P1.Z, 1));
                    Vector4 N2 = Vector4.Normalize(new Vector4(P2.X, P2.Y, P2.Z, 1));
                    Vector4 N3 = Vector4.Normalize(new Vector4(P3.X, P3.Y, P3.Z, 1));
                    Vector4 N4 = Vector4.Normalize(new Vector4(P4.X, P4.Y, P4.Z, 1));

                    mesh.Add(new Triangle()
                    {
                        A = new Pixel() { P = P1, N = N1, Color = color },
                        B = new Pixel() { P = P3, N = N3, Color = color },
                        C = new Pixel() { P = P2, N = N2, Color = color }
                    });

                    mesh.Add(new Triangle()
                    {
                        A = new Pixel() { P = P1, N = N1, Color = color },
                        B = new Pixel() { P = P4, N = N4, Color = color },
                        C = new Pixel() { P = P3, N = N3, Color = color }
                    });
                }
            }
        }

        protected override List<Triangle> GetTriangulation()
        {
            return mesh;
        }
    }
}
