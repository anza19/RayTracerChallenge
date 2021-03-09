using System;

namespace RayTracerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            Matrix4 testTwo = new Matrix4(4, 4);
            Matrix4 scale = testTwo.Matrix4MatrixScaling(2, 3, 4);
            Vector v3 = new Vector(-4, 6, 8);
            Vector v4 = v3.VectorMatrixMultiplication(v3, scale);

        }
    }
}
