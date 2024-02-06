﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering
{
    public class Camera
    {
        public Vector3 Position { get; set; }
        public Vector3 Target {  get; set; }
        public Vector3 UpVector { get; set; }
    }
}