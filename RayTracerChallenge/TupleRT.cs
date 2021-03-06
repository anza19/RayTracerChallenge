using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    //Tuple is the parent class that Points and Vectors will inherit from.
    public class TupleRT
    {
        public float x;
        public float y;
        public float z;
        public float w;

        public TupleRT() { }

        public TupleRT(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }
    }
}
