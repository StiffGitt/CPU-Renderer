using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering
{
    public struct Pixel
    {
        public Vector4 P { get; set; }
        public Vector4 N { get; set; }
        public Color Color { get; set; }
    }
}
