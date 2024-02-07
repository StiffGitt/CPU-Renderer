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
        public static float k_a = 0.1f;
        public float A_C = 1f;
        public float A_L = 0.09f;
        public float A_Q = 0.032f;
        public Vector3 Position { get; set; }
    }
}
