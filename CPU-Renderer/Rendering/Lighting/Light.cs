using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering.Lighting
{
    public class Light
    {
        public static Color Ambient = Color.FromArgb(55, 55, 55);
        public Color Diffuse { get; set; }
        public Color Specular { get; set; }
        public float A_C { get; set; } = 1f;
        public float A_L { get; set; } = 0.09f;
        public float A_Q { get; set; } = 0.032f;
        public Vector3 Position { get; set; }
    }
}
