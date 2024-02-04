using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering
{
    public static class Utils
    {
        public static float AngleToRadians(float angle)
        {
            return (float)(angle * Math.PI / 180.0f);
        }
    }
}
