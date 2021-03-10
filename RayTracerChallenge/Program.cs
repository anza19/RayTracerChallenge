using System;

namespace RayTracerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Ray r1 = new Ray(new Point(2, 3, 4), new Vector(1, 0, 0));
            Point x = r1.RayPosition(r1, 1);

            Sphere sp = new Sphere();
            Ray r = new Ray(new Point(0, 0, 0), new Vector(0, 0, 1));

            float[] intersection = r.RaySphereIntersection(r, sp);
            Console.WriteLine(intersection[0]);
            Console.WriteLine(intersection[1]);
        }
    }
}
