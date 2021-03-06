using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    public class Environment
    {
        public Vector gravity;
        public Vector wind;

        public Environment() { }
        public Environment(Vector gravity, Vector wind)
        {
            this.gravity = gravity;
            this.wind = wind;
        }
    }
}
