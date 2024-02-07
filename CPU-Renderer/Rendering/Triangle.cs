using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering
{
    public class Triangle
    {
        public Pixel A { get; set; }
        public Pixel B { get; set; }
        public Pixel C { get; set; }

        public List<Pixel> pixels = new List<Pixel>();

        public void CastToScreen(int width, int height)
        {
            A = A.CastToScreen(width, height);
            B = B.CastToScreen(width, height);
            C = C.CastToScreen(width, height);
        }

        public bool IsOnScreen(int width, int height)
        {
            return A.IsOnScreen(width, height) || B.IsOnScreen(width, height) || C.IsOnScreen(width, height);
        }

        public bool BackFaceCulling(Vector3 camPos)
        {
            return A.IsBackFace(camPos) && B.IsBackFace(camPos) && C.IsBackFace(camPos);
        }
    }
}
