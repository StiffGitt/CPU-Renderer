using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering.Models
{
    public class Cube : Model
    {
        private const int wallTriCount = 10;
        private Color color;
        private List<Triangle> mesh;

        public Cube(Color color, Vector3 translation, Vector3 scale, Vector3 pivot)
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
            // Front wall
            TriangulateFrontBack(new Vector4(0, 0, 1, 1), new Vector4(0, 0, 1, 1));
            // Back wall
            TriangulateFrontBack(new Vector4(0, 0, 0, 1), new Vector4(0, 0, -1, 1));
            // Left wall
            TriangulateLeftRight(new Vector4(0, 0, 0, 1), new Vector4(-1, 0, 0, 1));
            // Right wall
            TriangulateLeftRight(new Vector4(1, 0, 0, 1), new Vector4(1, 0, 0, 1));
            // Bottom wall
            TriangulateBottomUp(new Vector4(0, 0, 0, 1), new Vector4(0, -1, 0, 1));
            // Up wall
            TriangulateBottomUp(new Vector4(0, 1, 0, 1), new Vector4(0, 1, 0, 1));
        }

        private void TriangulateFrontBack(Vector4 start, Vector4 N)
        {
            float off = 1.0f / wallTriCount;
            for (int i = 0; i < wallTriCount; i++)
            {
                for (int j = 0; j < wallTriCount; j++)
                {
                    Vector4 A = new Vector4(start.X + j * off, start.Y + i * off, start.Z, start.W);
                    Vector4 B = new Vector4(start.X + (j + 1) * off, start.Y + (i + 1) * off, start.Z, start.W);
                    Vector4 C = new Vector4(start.X + (j + 1) * off, start.Y + i * off, start.Z, start.W);
                    mesh.Add(new Triangle()
                    {
                        A = new Pixel() { P = A, N = N, Color = color },
                        B = new Pixel() { P = B, N = N, Color = color },
                        C = new Pixel() { P = C, N = N, Color = color }
                    });

                    A = new Vector4(start.X + j * off, start.Y + i * off, start.Z, start.W);
                    B = new Vector4(start.X + j  * off, start.Y + (i + 1) * off, start.Z, start.W);
                    C = new Vector4(start.X + (j + 1) * off, start.Y + (i + 1) * off, start.Z, start.W);
                    mesh.Add(new Triangle()
                    {
                        A = new Pixel() { P = A, N = N, Color = color },
                        B = new Pixel() { P = B, N = N, Color = color },
                        C = new Pixel() { P = C, N = N, Color = color }
                    });
                }
            }
        }

        private void TriangulateLeftRight(Vector4 start, Vector4 N)
        {
            float off = 1.0f / wallTriCount;
            for (int i = 0; i < wallTriCount; i++)
            {
                for (int j = 0; j < wallTriCount; j++)
                {
                    Vector4 A = new Vector4(start.X, start.Y + j * off, start.Z + i * off, start.W);
                    Vector4 B = new Vector4(start.X, start.Y + (j + 1) * off, start.Z + (i + 1) * off, start.W);
                    Vector4 C = new Vector4(start.X, start.Y + (j + 1) * off, start.Z + i * off, start.W);
                    mesh.Add(new Triangle()
                    {
                        A = new Pixel() { P = A, N = N, Color = color },
                        B = new Pixel() { P = B, N = N, Color = color },
                        C = new Pixel() { P = C, N = N, Color = color }
                    });

                    A = new Vector4(start.X, start.Y + j * off, start.Z + i * off, start.W);
                    B = new Vector4(start.X, start.Y + j * off, start.Z + (i + 1) * off, start.W);
                    C = new Vector4(start.X, start.Y + (j + 1) * off, start.Z + (i + 1) * off, start.W);
                    mesh.Add(new Triangle()
                    {
                        A = new Pixel() { P = A, N = N, Color = color },
                        B = new Pixel() { P = B, N = N, Color = color },
                        C = new Pixel() { P = C, N = N, Color = color }
                    });
                }
            }
        }

        private void TriangulateBottomUp(Vector4 start, Vector4 N)
        {
            float off = 1.0f / wallTriCount;
            for (int i = 0; i < wallTriCount; i++)
            {
                for (int j = 0; j < wallTriCount; j++)
                {
                    Vector4 A = new Vector4(start.X + j * off, start.Y, start.Z + i * off, start.W);
                    Vector4 B = new Vector4(start.X + (j + 1) * off, start.Y, start.Z + (i + 1) * off, start.W);
                    Vector4 C = new Vector4(start.X + (j + 1) * off, start.Y, start.Z + i * off, start.W);
                    mesh.Add(new Triangle()
                    {
                        A = new Pixel() { P = A, N = N, Color = color },
                        B = new Pixel() { P = B, N = N, Color = color },
                        C = new Pixel() { P = C, N = N, Color = color }
                    });

                    A = new Vector4(start.X + j * off, start.Y, start.Z + i * off, start.W);
                    B = new Vector4(start.X + j * off, start.Y, start.Z + (i + 1) * off, start.W);
                    C = new Vector4(start.X + (j + 1) * off, start.Y, start.Z + (i + 1) * off, start.W);
                    mesh.Add(new Triangle()
                    {
                        A = new Pixel() { P = A, N = N, Color = color },
                        B = new Pixel() { P = B, N = N, Color = color },
                        C = new Pixel() { P = C, N = N, Color = color }
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
