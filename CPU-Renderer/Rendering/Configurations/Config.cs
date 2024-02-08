using CPU_Renderer.Rendering.PixelOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering.Configurations
{
    public static class Config
    {
        public static Color BackGroundColor = Color.DarkGray;
        public static int FullTicks = 150;
        public static float MovingCircleRadius = 5.0f;
        public static bool BackFaceCulling = false;
        public static bool GridMode = false;
        public static ShadingTypes ShadingType = ShadingTypes.Constant;
        public static float FogIntensity = 1.0f;
    }
}
