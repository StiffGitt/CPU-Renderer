using CPU_Renderer.Rendering.Configurations;
using CPU_Renderer.Rendering.Graphics;
using CPU_Renderer.Rendering.Lighting;
using CPU_Renderer.Rendering.Models;
using CPU_Renderer.Rendering.PixelOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPU_Renderer.Rendering
{
    public class Renderer
    {
        public LockBitmap lockmap;
        public List<Model> models;
        public List<Light> lights;
        public Camera curCam;

        public void ClearMap()
        {
            lockmap.LockBits();
            Drawing.ClearLB(lockmap, Config.BackGroundColor);
            lockmap.UnlockBits();
        }

        public void Render()
        {
            List<Triangle> triangles = new List<Triangle>();
            foreach (var model in models)
            {
                triangles.AddRange(model.CalculateModelMesh(curCam.Position, curCam.Target, curCam.UpVector, Projection.fieldOfView,
                    Projection.aspectRatio, Projection.nearPlane, Projection.farPlane));
            };

            if (Config.BackFaceCulling)
                triangles = triangles.Where(t => !t.BackFaceCulling(curCam.Position)).ToList();

            Parallel.ForEach(triangles, tri =>
            {
                tri.CastToScreen(lockmap.Width, lockmap.Height);
            });
            triangles = triangles.Where(t => t.IsOnScreen(lockmap.Width, lockmap.Height)).ToList();

            Parallel.ForEach(triangles, tri =>
            {
                tri.pixels = Rasterization.RasterizeWithScanLine(tri);
            });

            //Parallel.ForEach(triangles, tri =>
            //{
            //    Shading.DoShading(tri, lights, curCam.Position);
            //});
            foreach (var tri in triangles)
            {
                Shading.DoShading(tri, lights, curCam.Position);
            }

            Drawing.InitZBuffer(lockmap.Width, lockmap.Height);
            lockmap.LockBits();
            foreach (var triangle in triangles)
            {
                if (Config.GridMode)
                    Drawing.DrawTriangleEdges(lockmap, triangle);
                else
                    Drawing.DrawTriangle(lockmap, triangle);
            }
            lockmap.UnlockBits();
        }

    }
}
