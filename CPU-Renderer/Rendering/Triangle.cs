using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
