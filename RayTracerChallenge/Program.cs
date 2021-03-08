using System;

namespace RayTracerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            //testing my Matrix4 class
            Matrix4 m = new Matrix4(4, 4);

            //testing comparison class
            Matrix4 m1 = new Matrix4(4, 4);
            Matrix4 m2 = new Matrix4(4, 4);

            //m2.matrix[0, 0] = 5;
            Console.WriteLine(Matrix4.Matrix4MatrixComparison(m1.matrix, m2.matrix));
        }
    }
}
