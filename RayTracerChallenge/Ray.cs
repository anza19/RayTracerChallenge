using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    public class Ray
    {
        public Point origin;
        public Vector direction;

        public Ray() {}

        public Ray(Point origin, Vector direction)
        {
            this.origin = origin;
            this.direction = direction;

            Console.WriteLine("Ray created");
        }

        //this method computes the position of a ray after a time interval 't' has passed
        public Point RayPosition(Ray r, float t)
        {

            //this is computed using the formula
            //ray.origin + ray.direction * t
            Vector v = r.direction.VectorScalarMultiplication(r.direction, t);
            Point p = r.origin.PointVectorAddition(r.origin, v);

            return p;
        }

        public float[] RaySphereIntersection(Ray r, Sphere s)
        {
            Vector sphereToRay = r.origin.PointPointSubtraction(r.origin, s.origin);
            float a = r.direction.VectorDotProduct(r.direction, r.direction);
            float b = 2 * r.direction.VectorDotProduct(r.direction, sphereToRay);
            float c = r.direction.VectorDotProduct(sphereToRay, sphereToRay) - 1.0f;

            float discrimnant = (b * b) - (4 * a * c);

            if(discrimnant < 0)
            {
                //no intersection, return nothing
                return null;
            }

            float discrimnantRoot = (float)(Math.Sqrt(discrimnant));

            float t1 = (-b - discrimnantRoot) / (2 * a);
            float t2 = (-b + discrimnantRoot) / (2 * a);

            if(t1 >= t2)
            {
                return new float[] { t1, t2 };
            }
            return new float[] { t2, t1 };
        }

    }
}
