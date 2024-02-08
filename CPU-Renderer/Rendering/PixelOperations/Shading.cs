using CPU_Renderer.Rendering.Configurations;
using CPU_Renderer.Rendering.Lighting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CPU_Renderer.Rendering.PixelOperations
{
    public static class Shading
    {
        public static void DoShading(Triangle triangle, List<Light> lights, Vector3 camPos)
        {
            if(Config.ShadingType == ShadingTypes.Constant)
                ConstantShading(triangle, lights, camPos);
            if(Config.ShadingType == ShadingTypes.Gouraud)
                GouraudShading(triangle, lights, camPos);
            if(Config.ShadingType == ShadingTypes.Phong)
                PhongShading(triangle, lights, camPos);
        }

        private static void ConstantShading(Triangle triangle, List<Light> lights, Vector3 camPos)
        {
            var I = Utils.Vec3ToColor(GetPixelIntensity(triangle.A, lights, camPos));
            for (int i = 0; i < triangle.pixels.Count; i++)
            {
                var p = triangle.pixels[i];
                triangle.pixels[i] = new Pixel()
                {
                    P = p.P,
                    N = p.N,
                    WP = p.WP,
                    Color = I,
                    Material = p.Material,
                };
            }
        }

        private static void GouraudShading(Triangle triangle, List<Light> lights, Vector3 camPos)
        {
            var Ia = GetPixelIntensity(triangle.A, lights, camPos);
            var Ib = GetPixelIntensity(triangle.B, lights, camPos);
            var Ic = GetPixelIntensity(triangle.C, lights, camPos);

            for (int i = 0; i < triangle.pixels.Count; i++)
            {
                var p = triangle.pixels[i];
                var bar = Utils.GetBar(new PointF(p.P.X, p.P.Y), triangle);
                Color I = Utils.Vec3ToColor(bar.alfa * Ia + bar.beta * Ib + bar.gamma * Ic);
                triangle.pixels[i] = new Pixel()
                {
                    P = p.P,
                    N = p.N,
                    WP = p.WP,
                    Color = I,
                    Material = p.Material,
                };
            }
        }

        private static void PhongShading(Triangle triangle, List<Light> lights, Vector3 camPos)
        {
            for (int i = 0; i < triangle.pixels.Count; i++)
            {
                var p = triangle.pixels[i];
                Color I = Utils.Vec3ToColor(GetPixelIntensity(p, lights, camPos));
                triangle.pixels[i] = new Pixel()
                {
                    P = p.P,
                    N = p.N,
                    WP = p.WP,
                    Color = I,
                    Material = p.Material,
                };
            }
        }

        private static Vector3 GetPixelIntensity(Pixel p, List<Light> lights, Vector3 camPos)
        {
            Vector3 I = Vector3.Zero;
            var N = Vector3.Normalize(new Vector3(p.N.X, p.N.Y, p.N.Z));
            var V = Vector3.Normalize(camPos - p.WP);
            foreach (Light light in lights)
            {
                var I0 = Utils.Vector3FromColor(p.Color);
                var L = Vector3.Normalize(light.Position - p.WP);
                var R = Vector3.Normalize((2.0f * Vector3.Dot(L, N) * N) - L);
                float cosNL = Vector3.Dot(N, L);
                cosNL = cosNL < 0 ? 0 : cosNL;
                float cosVR = Vector3.Dot(V, R);
                cosVR = cosVR < 0 ? 0 : cosVR;
                float dist = (light.Position - p.WP).Length();

                Vector3 It = Vector3.Zero;
                // Diffuse
                It += p.Material.K_d * cosNL * light.Diffuse * I0;
                // Specular
                It += p.Material.K_s * Utils.PowFloats(cosVR, p.Material.Alfa) * light.Specular * I0;
                // Atenuation
                It *= 1 / (light.A_C + light.A_L * dist + light.A_Q * dist * dist);

                I += It;
            }
            // Ambient
            I += p.Material.K_a * Light.Ambient;

            float fogFactor = CalcFogFactor(p, camPos);
            I = Vector3.Lerp(I, Vector3.One, fogFactor);

            if (I.X > 1)
                I.X = 1;
            if (I.Y > 1)
                I.Y = 1;
            if (I.Z > 1)
                I.Z = 1;

            return I;
        }

        private static float CalcFogFactor(Pixel p, Vector3 camPos)
        {
            float intesity = Config.FogIntensity;
            if (intesity == 0)
                return 1.0f;

            float gradient = intesity * intesity - 5 * intesity + 6;
            float dist = (camPos - p.WP).Length();

            float fog = MathF.Exp(-MathF.Pow(dist / gradient, 4));
            fog = Math.Clamp(fog, 0.0f, 1.0f);

            return fog;
        }
    }
    
}
