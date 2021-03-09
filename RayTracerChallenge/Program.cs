using System;

namespace RayTracerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix4 test = new Matrix4(4, 4);
            Matrix4 trans = test.Matrix4MatrixTranslation(5, -3, 2);
            Matrix4.Matrix4MatrixDisplayer(trans.matrix);

            Point p1 = new Point(-3, 4, 5);

            Point newPoist = p1.PointMatrixMultiplication(p1, trans);

        }
    }
}
