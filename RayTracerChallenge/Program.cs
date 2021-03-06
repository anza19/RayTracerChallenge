using System;

namespace RayTracerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(1, 2, 3);
            Point p1 = new Point(1, 2, 3);

            Projectile proj = new Projectile(p1, v1);
        }
    }
}
