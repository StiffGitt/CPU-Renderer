using CPU_Renderer.Rendering.Configurations;
using CPU_Renderer.Rendering.Models;
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
        private Camera curCam;

        public Scene(PictureBox pictureBox)
        {
            Bitmap bitmap = new Bitmap(pictureBox.Size.Width, pictureBox.Size.Height);
            pictureBox.Image = bitmap;
            this.lockmap = new LockBitmap(bitmap);
            this.pictureBox = pictureBox;
            InitializeModels();
            InitializeCamera();
            Render();
        }

        private void Render()
        {
            List<Triangle> triangles = new List<Triangle>();
            foreach(var model in models)
            {
                triangles.AddRange(model.CalculateModelMesh(curCam.Position, curCam.Target, curCam.UpVector, Projection.fieldOfView,
                    Projection.aspectRatio, Projection.nearPlane, Projection.farPlane));
            };
        }

        private void InitializeModels()
        {
            models = new List<Model>();
            Cube cube = new Cube(Color.Red, new Vector3(0.5f, 0.5f, -0.5f), new Vector3(0.5f, 0.5f, 0.5f), new Vector3(0,0,0));
            models.Add(cube);
        }

        private void InitializeCamera() 
        {
            curCam = new Camera()
            {
                Position = new Vector3(0.5f, 0.5f, 3.0f),
                Target = new Vector3(0.0f, 0.5f, 0.5f),
                UpVector = new Vector3(0, 0, 1)
            };
        }
    }
}
