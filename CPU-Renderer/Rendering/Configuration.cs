using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Grid_Mesher
{
    public static class Configuration
    {
        public static Bitmap background { get; set; }
        public static Vector3[,] NormalMap {  get; set; }
        public static int ModelTriCount { get; set; } = 100;
        public static float Kd { get; set; } = 0.5f;
        public static float Ks { get; set; } = 0.5f;
        public static Vector3 Il { get; set; } = new Vector3(1, 1, 1);
        public static int M { get; set; } = 10;
    }
}
