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
        public static Vector3 Ambient = Vector3.One * 55.0f / 255.0f;
        public Vector3 Diffuse { get; set; }
        public Vector3 Specular { get; set; } = Vector3.One * 240.0f / 255.0f;
        public float A_C { get; set; } = 1f;
        public float A_L { get; set; } = 0.09f;
        public float A_Q { get; set; } = 0.032f;
        public Vector3 Position { get; set; }
    }
}
