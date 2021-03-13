using System;
using System.Collections.Generic;
using System.Text;


namespace RayTracerChallenge
{
    public class Sphere
    {
        public Point origin;
        public int radius;
        public static int sphereId = 0;

        //our sphere is simplified by being centered at the origin and having unit length
        public Sphere() 
        {
            origin = new Point(x: 0, y: 0, z: 0);
            radius = 1;

            Console.WriteLine($"sphereId: {sphereId}");

            //ensuring each sphereId is unique
            sphereId++;
        }
    }
}
