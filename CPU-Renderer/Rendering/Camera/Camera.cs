using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering
{
    public class Camera
    {
        private static Vector3 defaultUp = new Vector3(0.0f, 1.0f, 0.0f);
        public Vector3 Position { get; set; }
        public Vector3 Target { get; set; }
        public Vector3 UpVector { get; set; }

        public static Camera GetStaleCamera()
        {
            return new Camera()
            {
                Position = new Vector3(0.0f, 0.0f, 3.0f),
                Target = new Vector3(0.0f, 0.0f, 0.0f),
                UpVector = defaultUp
            };
        }

        public static Camera GetFollowingCamera(Vector3 target)
        {
            return new Camera()
            {
                Position = new Vector3(0.0f, -10.0f, 5.0f),
                Target = target,
                UpVector = defaultUp
            };
        }

        public static Camera GetMovingCamera(Vector3 positon)
        {
            return new Camera()
            {
                Position = positon,
                Target = new Vector3(0.0f, 0.0f, 0.0f),
                UpVector = defaultUp
            };
        }
    }
}
