using System;

namespace RayTracerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            Matrix4 m2 = new Matrix4(4, 4);
            Matrix4 rotatZ = m2.Matrix4MatrixShear(xZ:1.0f);
            Point p3 = new Point(2, 3, 4);

            Point p4 = p3.PointMatrixMultiplication(p3, rotatZ);
        }
    }
}
