using System;
using System.Collections.Generic;
using System.Linq;

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

        //this method returns the hit from a collection of intersection records
        //the hit is the visiible intersection
        //that is the object from a list of intersections that we can actually see and ultimately render
        //hit will never be behind the ray's origin, since that's effectively behind the camera
        //so you can ignore all intersections with negative t values
        public static Intersection Hit(List<Intersection> intersections)
        {
            if (intersections == null)
            {
                Console.WriteLine("no intersection took place");
                return null;
            }

            //if both intersections are negative, return nothing
            if(intersections.Last().t < 0 && intersections.First().t < 0)
            {
                return null;
            }

            //if just the smaller number is negative, return first element
            else if(intersections.Last().t < 0 && intersections.First().t > 0)
            {
                return intersections.First();
            }

            //just return the last number
            else
            {
                return intersections.Last();
            }    
        }
    }
}
