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


    }
}
