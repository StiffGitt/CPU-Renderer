using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering.Lighting
{
    public class TravellingLight : Light
    {
        public Vector3 BottomPos { get; set; }
        public Vector3 TopPos { get; set;}
        private int tickCount = 20;
        private int curTick = 0;
        private bool movingUp = true;
        public TravellingLight(Vector3 BottomPos, Vector3 TopPos, Vector3 Diffuse, Vector3 Specular)
        {
            this.BottomPos = BottomPos;
            this.TopPos = TopPos;
            base.Diffuse = Diffuse;
            base.Specular = Specular;
            base.Position = BottomPos;
        }
        public void Move()
        {
            curTick++;
            if (curTick == tickCount)
            {
                movingUp = !movingUp;
                curTick = 0;
            }
            if(movingUp)
                Position = Position + (TopPos - BottomPos) / tickCount;
            else
                Position = Position - (TopPos - BottomPos) / tickCount;
        }
    }
}
