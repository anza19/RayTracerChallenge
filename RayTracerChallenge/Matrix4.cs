using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    public class Matrix4
    {
        public int rows;
        public int columns;
        public float[,] matrix;

        public Matrix4() { }
        public Matrix4(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;

            //creating our n x m matrix
            float[,] tempMatrix = new float[rows, columns];
            matrix = Matrix4MatrixCreater(tempMatrix);
            Matrix4MatrixDisplayer(matrix);
        }

        //this method fills a 4x4 method with numbers
        //if I do not pass in any numbers by default it will initialize an identity matrix
        public static float[,] Matrix4MatrixCreater(float[,] matrix, float m00 = 1.0f, float m01 = 0.0f, float m02 = 0.0f, float m03 = 0.0f,
                    float m10 = 0.0f, float m11 = 1.0f, float m12 = 0.0f, float m13 = 0.0f,
                    float m20 = 0.0f, float m21 = 0.0f, float m22 = 1.0f, float m23 = 0.0f,
                    float m30 = 0.0f, float m31 = 0.0f, float m32 = 0.0f, float m33 = 1.0f)
        {
            //first we fill up Row #0 aka the first row
            matrix[0, 0] = m00;
            matrix[0, 1] = m01;
            matrix[0, 2] = m02;
            matrix[0, 3] = m03;

            //next we fill up Row #1, aka the second row
            matrix[1, 0] = m10;
            matrix[1, 1] = m11;
            matrix[1, 2] = m12;
            matrix[1, 3] = m13;

            //then Row #2 aka the third row
            matrix[2, 0] = m20;
            matrix[2, 1] = m21;
            matrix[2, 2] = m22;
            matrix[2, 3] = m23;
            
            //then Row #3 aka the fourth and final row
            matrix[3, 0] = m30;
            matrix[3, 1] = m31;
            matrix[3, 2] = m32;
            matrix[3, 3] = m33;

            return matrix;
        }

        //debugging method that prints the created matrix
        public static void Matrix4MatrixDisplayer(float[,] matrix)
        {
            Console.WriteLine($"{matrix[0, 0]}, {matrix[0, 1]}, {matrix[0, 2]}, {matrix[0, 3]}");
            Console.WriteLine($"{matrix[1, 0]}, {matrix[1, 1]}, {matrix[1, 2]}, {matrix[1, 3]}");
            Console.WriteLine($"{matrix[2, 0]}, {matrix[2, 1]}, {matrix[2, 2]}, {matrix[2, 3]}");
            Console.WriteLine($"{matrix[3, 0]}, {matrix[3, 1]}, {matrix[3, 2]}, {matrix[3, 3]}");
        }
    }
}
