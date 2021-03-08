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

            m1.matrix[0, 0] = 2;
            m1.matrix[0, 1] = 3;
            m1.matrix[0, 2] = 4;
            m1.matrix[0, 3] = 5;

            Matrix4 c = new Matrix4(4, 4);
            c.matrix = m1.Matrix4MatrixMultiplication(m1.matrix, m2.matrix);
            Matrix4.Matrix4MatrixDisplayer(c.matrix);

            Matrix4 m3 = new Matrix4(4, 4);
            m3.matrix[0, 0] = 1;
            m3.matrix[0, 1] = 2;
            m3.matrix[0, 2] = 3;
            m3.matrix[0, 3] = 4;

            m3.matrix[1, 0] = 2;
            m3.matrix[1, 1] = 4;
            m3.matrix[1, 2] = 4;
            m3.matrix[1, 3] = 2;

            m3.matrix[2, 0] = 8;
            m3.matrix[2, 1] = 6;
            m3.matrix[2, 2] = 4;
            m3.matrix[2, 3] = 1;

            m3.matrix[3, 0] = 0;
            m3.matrix[3, 1] = 0;
            m3.matrix[3, 2] = 0;
            m3.matrix[3, 3] = 1;

            Vector v1 = new Vector(1, 2, 3, 0);
            Vector v2 = v1.VectorMatrixMultiplication(v1, m3);

            Point p1 = new Point(1, 2, 3, 1);
            Point p2 = p1.PointMatrixMultiplication(p1, m3);
        }
    }
}
