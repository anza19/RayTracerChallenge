using System;
using System.Collections.Generic;

namespace RayTracerChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Chapter5Challenge.Chapter5RayCaster();

            Sphere s = new Sphere();
            Matrix4 translationMatrix = new Matrix4(4, 4);
            translationMatrix = translationMatrix.Matrix4MatrixTranslation(0, 1, 0);
            s.SphereSetTransformation(translationMatrix);

            Vector normal = s.SphereSurfaceNormalVector(s, new Point(0, 1.70711f, -0.70711f));
        
        }
    }
}
