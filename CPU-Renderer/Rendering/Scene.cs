using CPU_Renderer.Rendering.Configurations;
using CPU_Renderer.Rendering.Graphics;
using CPU_Renderer.Rendering.Lighting;
using CPU_Renderer.Rendering.Models;
using CPU_Renderer.Rendering.PixelOperations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering
{
    public class Scene
    {
        private int animationTick = 0;
        private Renderer renderer;
        private Model rotatingModel;
        private Model rotatingModel2;
        private Model movingModel;
        private TravellingLight travellingLight;
        private Vector3 movingModelPosition = new Vector3(Config.MovingCircleRadius, 0.0f, 0.0f);
        private Vector3 movingModelSize = new Vector3(0.1f, 0.1f, 0.1f);
        private CameraType cameraType = CameraType.Stale;

        public Scene(PictureBox pictureBox)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = bitmap;
            renderer = new Renderer();
            renderer.lockmap = new LockBitmap(bitmap);
            InitializeModels();
            InitializeLights();
            Draw();
        }

        public void DoTick()
        {
            MoveScene();
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

        private void MoveScene()
        {
            animationTick = (animationTick + 1) % Config.FullTicks;
            var newPivot = rotatingModel.Pivot + Vector3.UnitX * 2.0f * MathF.PI / Config.FullTicks;
            rotatingModel.Pivot = Utils.NormalizePivot(newPivot);

            newPivot = rotatingModel.Pivot + Vector3.One * 2.0f * MathF.PI / Config.FullTicks;
            rotatingModel2.Pivot = Utils.NormalizePivot(newPivot);

            float phi = ((float)animationTick / Config.FullTicks) * 2.0f * MathF.PI;
            float x = Config.MovingCircleRadius * MathF.Cos(phi);
            float z = Config.MovingCircleRadius * MathF.Sin(phi);
            movingModelPosition = new Vector3(x, movingModelPosition.Y, z);
            movingModel.Translation = movingModelPosition;

            travellingLight.Move();
        }

        public void Draw()
        {
            renderer.ClearMap();
            renderer.curCam = GetCamera();
            renderer.Render();
            ConfigurationForm.FrameCount++;
        }
        
       

        private void InitializeModels()
        {
            movingModel = new Sphere(Material.Diffusive, Color.FromArgb(4, 4, 255), movingModelPosition, movingModelSize, new Vector3(0, 0, 0));
            rotatingModel = new Sphere(Material.Specular, Color.FromArgb(10, 125, 10), new Vector3(0, 0, 0), new Vector3(0.25f, 0.25f, 0.25f), new Vector3(0, 0, 0));
            rotatingModel2 = new Cube(Material.Diffusive, Color.FromArgb(255, 2, 2), new Vector3(2.0f, 2.0f, -3.0f), new Vector3(0.25f, 0.25f, 0.25f), new Vector3(0, 0, 0));
            
            renderer.models = new List<Model>()
            {
                rotatingModel,
                movingModel,
                rotatingModel2,
            };
        }

        private void InitializeLights()
        {
            travellingLight = new TravellingLight(new Vector3(-4.0f, -10.0f, 0.0f), new Vector3(0.0f, -4.0f, 0.0f),
                new Vector3(125, 125, 0), new Vector3(125, 125, 0));
            renderer.lights = new List<Light>()
            {
                new Light()
                { 
                    Position = new Vector3(1.0f, 1.0f, 1.0f),
                    Diffuse = new Vector3(125, 125, 125),
                },
                travellingLight
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
