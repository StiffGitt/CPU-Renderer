using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering.Lighting
{
    public class Material
    {
        public float K_s {get; set;}
        public float K_d {get; set;}
        public float K_a {get; set;}
        public int Alfa {get; set; }

        public static Material Specular = new Material()
        {
            K_s = 0.6f,
            K_d = 0.3f,
            K_a = 0.1f,
            Alfa = 6,
        };

        public static Material Diffusive = new Material()
        {
            K_s = 0.2f,
            K_d = 0.6f,
            K_a = 0.2f,
            Alfa = 3,
        };
    }
}
