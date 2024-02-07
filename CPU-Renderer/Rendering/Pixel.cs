﻿using System;
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

        public Pixel CastToScreen(int width, int height)
        {
            Vector4 screenPos;
            screenPos = P / P.W;

            screenPos = new Vector4()
            {
                X = ((1 + screenPos.X) * width) / 2,
                Y = ((1 + screenPos.Y) * height) / 2,
                Z = (P.Z + 1) / 2,
                W = screenPos.W
            };

            return new Pixel()
            {
                P = screenPos, N = N, Color = Color
            };
        }

        public bool IsOnScreen(int width, int height)
        {
            return P.X > 0 && P.X < width && P.Y > 0 && P.Y < height;
        }
    }
}
