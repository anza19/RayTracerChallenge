using System;
using System.Collections.Generic;

namespace RayTracerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Sphere sp = new Sphere();
            Ray r = new Ray(new Point(0, 0, 0), new Vector(0, 0, 1));

            List<Intersection> intersections = r.RaySphereIntersection(r, sp);
            Intersection hit = Intersection.Hit(intersections);
            Console.WriteLine($"{hit.t}, {hit.sphereIntersected.radius}");
        }
    }
}
