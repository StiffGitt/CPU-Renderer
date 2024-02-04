using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering.Model
{
    public abstract class Model
    {
        public Vector3 Translation { get; set; }
        public Vector3 Scale { get; set; }
        public Vector3 Pivot { get; set; }


        protected List<Vector4> GetTransformedTriangles(List<Vector4> vertices)
        {

        }

        protected abstract List<Triangle> GetTriangulation();

        protected Matrix4x4 GetModelMatrix()
        {
            Matrix4x4 Ms = Matrix4x4.CreateScale(Scale);
            Matrix4x4 Mt = Matrix4x4.CreateTranslation(Translation);
            Matrix4x4 Mr = Matrix4x4.CreateFromYawPitchRoll(Pivot.X, Pivot.Y, Pivot.Z);

            return Ms * Mt * Mr;
        }

        protected Matrix4x4 GetViewMatrix(Vector3 CameraPos, Vector3 CameraTarget, Vector3 UpVector)
        {
            return Matrix4x4.CreateLookAt(CameraPos, CameraTarget, UpVector);
        }

        protected Matrix4x4 GetProjMatrix(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            return Matrix4x4.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance);
        }
    }
}
