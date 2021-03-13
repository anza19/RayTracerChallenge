using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    public class Intersection
    {
        //class that returns t value of intersection
        //t being the scalar which when multiplied to a ray's origin, reflects a point along the ray's path that an intersection took place
        public float t;

        //Object that was intersected with it
        //initially it's all going to be sphere, only object we have in our scene
        public Sphere sphereIntersected;

        public Intersection() { }
        public Intersection(float t, Sphere sphereIntersected)
        {
            this.t = t;
            this.sphereIntersected = sphereIntersected;
        }
    }
}
