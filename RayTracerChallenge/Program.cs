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
            //Matrix4.Matrix4MatrixDisplayer(c.matrix);

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

            Matrix4 identity = m3.Matrix4IdentityMatrixCreater(m3);
            //Matrix4.Matrix4MatrixDisplayer(identity.matrix);

            Matrix4 m4 = new Matrix4(4, 4);
            m4.matrix[0, 0] = 0;
            m4.matrix[0, 1] = 9;
            m4.matrix[0, 2] = 3;
            m4.matrix[0, 3] = 0;

            m4.matrix[1, 0] = 9;
            m4.matrix[1, 1] = 8;
            m4.matrix[1, 2] = 0;
            m4.matrix[1, 3] = 8;

            m4.matrix[2, 0] = 1;
            m4.matrix[2, 1] = 8;
            m4.matrix[2, 2] = 5;
            m4.matrix[2, 3] = 3;

            m4.matrix[3, 0] = 0;
            m4.matrix[3, 1] = 0;
            m4.matrix[3, 2] = 5;
            m4.matrix[3, 3] = 8;

            Matrix4 tran = new Matrix4(4, 4);
            tran.matrix = Matrix4.Matrix4MatrixTranspose(m4.matrix);
            Matrix4.Matrix4MatrixDisplayer(tran.matrix);
        }
    }
}
