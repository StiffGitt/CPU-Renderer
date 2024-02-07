using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering.Models
{
    public abstract class Model
    {
        public Vector3 Translation { get; set; }
        public Vector3 Scale { get; set; }
        public Vector3 Pivot { get; set; }


        public List<Triangle> CalculateModelMesh(Vector3 cameraPos, Vector3 cameraTarget, Vector3 upVector, 
            float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            var mesh = GetTriangulation();
            var Proj = GetProjMatrix(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance);
            var View = GetViewMatrix(cameraPos, cameraTarget, upVector);
            var Model = GetModelMatrix();
            var MVP = Proj * View * Model;
            Matrix4x4.Invert(Matrix4x4.Transpose(Model), out var MNormal);

            var transformedMesh = new List<Triangle>();
            //Parallel.ForEach(mesh, triangle =>
            foreach(var triangle in mesh)
            {
                var P = triangle.A.P.ApplyMatrix(MVP);
                var A = new Pixel()
                {
                    P = P / P.W,
                    N = Vector4.Normalize(triangle.A.N.ApplyMatrix(MNormal)),
                    Color = triangle.A.Color
                };

                P = triangle.B.P.ApplyMatrix(MVP);
                var B = new Pixel()
                {
                    P = P / P.W,
                    N = Vector4.Normalize(triangle.B.N.ApplyMatrix(MNormal)),
                    Color = triangle.B.Color
                };

                P = triangle.C.P.ApplyMatrix(MVP);
                var C = new Pixel()
                {
                    P = P / P.W,
                    N = Vector4.Normalize(triangle.C.N.ApplyMatrix(MNormal)),
                    Color = triangle.C.Color
                };

                transformedMesh.Add(new Triangle() { A = A, B = B, C = C});
            }

            return transformedMesh;
        }

        protected abstract List<Triangle> GetTriangulation();

        protected Matrix4x4 GetModelMatrix()
        {
            Matrix4x4 Ms = Matrix4x4.Transpose(Matrix4x4.CreateScale(Scale));
            Matrix4x4 Mt = Matrix4x4.Transpose(Matrix4x4.CreateTranslation(Translation));
            Matrix4x4 Mr = Matrix4x4.Transpose(Matrix4x4.CreateFromYawPitchRoll(Pivot.X, Pivot.Y, Pivot.Z));

            return Ms * Mt * Mr;
        }

        protected Matrix4x4 GetViewMatrix(Vector3 CameraPos, Vector3 CameraTarget, Vector3 UpVector)
        {
            Vector3 D = CameraPos - CameraTarget;
            Vector3 R = Vector3.Cross(UpVector, D);
            Vector3 U = Vector3.Cross(D, R);
            Matrix4x4 V1 = new Matrix4x4(
                R.X, R.Y, R.Z, 0,
                U.X, U.Y, U.Z, 0,
                D.X, D.Y, D.Z, 0,
                0, 0, 0, 1);
            Matrix4x4 V2 = new Matrix4x4(
                1, 0, 0, -CameraPos.X,
                0, 1, 0, -CameraPos.Y,
                0, 0, 1, -CameraPos.Z,
                0, 0, 0, 1);
            return V1 * V2;
            //return Matrix4x4.Transpose(Matrix4x4.CreateLookAt(CameraPos, CameraTarget, UpVector));
        }

        protected Matrix4x4 GetProjMatrix(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
        {
            float ctgfov = 1.0f / (float)Math.Tan(Utils.AngleToRadians(fieldOfView / 2));
            return new Matrix4x4(
                ctgfov / aspectRatio, 0, 0, 0,
                0, ctgfov, 0, 0,
                0, 0, (farPlaneDistance + nearPlaneDistance) / (farPlaneDistance - nearPlaneDistance), (-2 * farPlaneDistance * nearPlaneDistance) / (farPlaneDistance - nearPlaneDistance),
                0, 0, 1, 0
                );
        }
    }
}
