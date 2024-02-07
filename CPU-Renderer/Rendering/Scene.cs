using CPU_Renderer.Rendering.Configurations;
using CPU_Renderer.Rendering.Graphics;
using CPU_Renderer.Rendering.Lighting;
using CPU_Renderer.Rendering.Models;
using CPU_Renderer.Rendering.PixelOperations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering
{
    public class Scene
    {
        private LockBitmap lockmap;
        private PictureBox pictureBox;
        private List<Model> models;
        private int animationTick = 0;
        private Model rotatingModel;
        private Model rotatingModel2;
        private Model movingModel;
        private Vector3 movingModelPosition = new Vector3(Config.MovingCircleRadius, 0.0f, 0.0f);
        private Vector3 movingModelSize = new Vector3(0.25f, 0.25f, 0.5f);
        private CameraType cameraType = CameraType.Stale;

        public Scene(PictureBox pictureBox)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = bitmap;
            this.lockmap = new LockBitmap(bitmap);
            this.pictureBox = pictureBox;
            InitializeModels();
            Draw();
        }

        public void DoTick()
        {
            MoveModels();
        }

        public void ChangeCamera()
        {
            switch(cameraType)
            {
                case CameraType.Stale:
                    cameraType = CameraType.Following;
                    break;
                case CameraType.Following:
                    cameraType = CameraType.Moving;
                    break;
                default:
                    cameraType = CameraType.Stale;
                    break;
            }
        }

        private void MoveModels()
        {
            animationTick = (animationTick + 1) % Config.FullTicks;
            var newPivot = rotatingModel.Pivot + Vector3.UnitX * 2.0f * MathF.PI / Config.FullTicks;
            rotatingModel.Pivot = (newPivot.X > MathF.PI * 2)? Vector3.Zero : newPivot;

            newPivot = rotatingModel.Pivot + Vector3.One * 2.0f * MathF.PI / Config.FullTicks;
            rotatingModel2.Pivot = (newPivot.X > MathF.PI * 2) ? Vector3.Zero : newPivot;

            float phi = ((float)animationTick / Config.FullTicks) * 2.0f * MathF.PI;
            float x = Config.MovingCircleRadius * MathF.Cos(phi);
            float z = Config.MovingCircleRadius * MathF.Sin(phi);
            movingModelPosition = new Vector3(x, movingModelPosition.Y, z);
            movingModel.Translation = movingModelPosition;
        }

        public void Draw()
        {
            lockmap.LockBits();
            Drawing.ClearLB(lockmap, Config.BackGroundColor);
            lockmap.UnlockBits();
            Render();
        }
        
        private void Render()
        {
            Camera curCam = GetCamera();
            List<Triangle> triangles = new List<Triangle>();
            foreach(var model in models)
            {
                triangles.AddRange(model.CalculateModelMesh(curCam.Position, curCam.Target, curCam.UpVector, Projection.fieldOfView,
                    Projection.aspectRatio, Projection.nearPlane, Projection.farPlane));
            };

            if(Config.BackFaceCulling)
                triangles = triangles.Where(t => !t.BackFaceCulling(curCam.Position)).ToList();

            foreach(var tri in triangles)
            {
                tri.CastToScreen(pictureBox.Width, pictureBox.Height);
            }
            triangles = triangles.Where(t => t.IsOnScreen(pictureBox.Width, pictureBox.Height)).ToList();

            foreach (var tri in triangles)
            {
                tri.pixels = Rasterization.RasterizeWithScanLine(tri);
            }

            Drawing.InitZBuffer(pictureBox.Width, pictureBox.Height);
            lockmap.LockBits();
            foreach (var triangle in triangles)
            {
                if(Config.GridMode)
                    Drawing.DrawTriangleEdges(lockmap, triangle);
                else
                    Drawing.DrawTriangle(lockmap, triangle);
            }
            lockmap.UnlockBits();
        }

        private void InitializeModels()
        {
            movingModel = new Cube(Material.Diffusive, Color.Blue, movingModelPosition, movingModelSize, new Vector3(0, 0, 0));
            rotatingModel = new Sphere(Material.Specular, Color.Green, new Vector3(0, 0, 0), new Vector3(0.25f, 0.25f, 0.25f), new Vector3(0, 0, 0));
            rotatingModel2 = new Cube(Material.Diffusive, Color.Red, new Vector3(2.0f, 2.0f, -3.0f), new Vector3(0.25f, 0.25f, 0.25f), new Vector3(0, 0, 0));
            
            models = new List<Model>()
            {
                rotatingModel,
                movingModel,
                rotatingModel2,
            };
        }

        private Camera GetCamera()
        {
            Camera curCam = new Camera();
            switch (cameraType)
            {
                case CameraType.Stale:
                    curCam = Camera.GetStaleCamera();
                break;
                case CameraType.Following:
                    curCam = Camera.GetFollowingCamera(movingModelPosition);
                break;
                case CameraType.Moving:
                    curCam = Camera.GetMovingCamera(movingModelPosition);
                break;
            }
            return curCam;
        }
    }
}
