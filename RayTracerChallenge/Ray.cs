using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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

        //this method is used to return the collection of t values
        //which when added to a ray's origin which represent points along the
        //ray where an intersection took place
        public List<Intersection> RaySphereIntersection(Ray r, Sphere s)
        {
            //get the inverse of whatever transformation we would apply to the sphere
            //and apply it to the original ray to get a transformed ray which retains
            //the same relation to the sphere, as if the sphere itself was transformed
            //not the ray
            Matrix4 inverseTransformation = new Matrix4(4, 4);
            inverseTransformation.matrix = Matrix4.Matrix4MatrixInversion(s.transformation.matrix);
            Ray transformedRay = r.RayTransformation(r, inverseTransformation);

            Vector sphereToRay = transformedRay.origin.PointPointSubtraction(transformedRay.origin, s.origin);
            float a = transformedRay.direction.VectorDotProduct(transformedRay.direction, transformedRay.direction);
            float b = 2 * transformedRay.direction.VectorDotProduct(transformedRay.direction, sphereToRay);
            float c = transformedRay.direction.VectorDotProduct(sphereToRay, sphereToRay) - 1.0f;

            float discrimnant = (b * b) - (4 * a * c);

            if(discrimnant < 0)
            {
                //no intersection, return nothing
                return null;
            }

            float discrimnantRoot = (float)(Math.Sqrt(discrimnant));

            float t1 = (-b - discrimnantRoot) / (2 * a);
            float t2 = (-b + discrimnantRoot) / (2 * a);

            List<Intersection> intersections = new List<Intersection>();

            if (t1 >= t2)
            {
                intersections.Add(new Intersection(t1, s));
                intersections.Add(new Intersection(t2, s));
                return intersections;
            }
            else
            {
                intersections.Add(new Intersection(t2, s));
                intersections.Add(new Intersection(t1, s));
                return intersections;
            }
        }

        //applies an inverse of the transformation that we want to apply to a sphere
        //such that our assumption of unit spehere at origin (0,0,0) is maintained
        public Ray RayTransformation(Ray r, Matrix4 matrix)
        {
            //apply matrix transformation to original ray to return a new one
            Point transformedPosition = r.origin.PointMatrixMultiplication(r.origin, matrix);

            //apply matrix transformation to ray's direction vector to return a new one
            Vector transformedDirection = r.direction.VectorMatrixMultiplication(r.direction, matrix);

            //return the transformed ray
            return new Ray(transformedPosition, transformedDirection);
        }
    }
}
