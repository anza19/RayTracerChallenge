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
            //Matrix4MatrixDisplayer(matrix);
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

        //this method compares two matrices to see if they are the same
        public static bool Matrix4MatrixComparison(float[,] matrixA, float[,] matrixB)
        {
            //we cycle through both matrices
            //if the entries at ith row and jth column don't match, return false as they are not the same
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (matrixA[i, j] != matrixB[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        //this method multiplies two matrices together
        //matrix multiplication is achieved by progressively, multiplying each row of the first matrix
        //to the columns of the second matrix
        //with each entry at a given row-column being calculated using the following formula
        //M(i,j) = A(i,0)*B(0,j) + A(i,1)*B(1,j) + A(i,2)*B(2,j) + A(i,3)*B(3,j); i row, j column
        public float[,] Matrix4MatrixMultiplication(float[,] a, float[,] b)
        {
            float[,] matrixM = new float[4, 4];

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    //M(i,j) = A(i,0)*B(0,j) + A(i,1)*B(1,j) + A(i,2)*B(2,j) + A(i,3)*B(3,j); i row, j column
                    float m = a[i, 0] * b[0, j] + a[i, 1] * b[1, j] + a[i, 2] * b[2, j] + a[i, 3] * b[3, j];
                    matrixM[i, j] = m;
                }
            }

            return matrixM;
        }

        public Matrix4 Matrix4IdentityMatrixCreater(Matrix4 mat)
        {
            //takes a matrix and creates an identity matrix out of it
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == j)
                    {
                        mat.matrix[i, j] = 1.0f;
                    }
                    else
                    {
                        mat.matrix[i, j] = 0.0f;
                    }
                }
            }

            return mat;
        }

        //this method returns the transpose of a matrix
        //transposing is the process where a row becomes a column, and every column becomes a row
        public static float[,] Matrix4MatrixTranspose(float[,] matrix)
        {
            float[,] transposedMatrix = new float[4, 4];
            for(int i = 0; i < 4; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    //every m[i,j] entry becomes m[j,i]
                    //and vice versa
                    transposedMatrix[i, j] = matrix[j, i];
                }
            }

            return transposedMatrix;
        }

        //computing matrix inversion using solution found here: https://stackoverflow.com/questions/1148309/inverting-a-4x4-matrix
        public static float[,] Matrix4MatrixInversion(float[,] m)
        {
            float[,] invertedMatrix = new float[4, 4];

            var A2323 = m[2,2] * m[3,3] - m[2,3] * m[3,2];
            var A1323 = m[2,1] * m[3,3] - m[2,3] * m[3,1];
            var A1223 = m[2,1] * m[3,2] - m[2,2] * m[3,1];
            var A0323 = m[2,0] * m[3,3] - m[2,3] * m[3,0];
            var A0223 = m[2,0] * m[3,2] - m[2,2] * m[3,0];
            var A0123 = m[2,0] * m[3,1] - m[2,1] * m[3,0];
            var A2313 = m[1,2] * m[3,3] - m[1,3] * m[3,2];
            var A1313 = m[1,1] * m[3,3] - m[1,3] * m[3,1];
            var A1213 = m[1,1] * m[3,2] - m[1,2] * m[3,1];
            var A2312 = m[1,2] * m[2,3] - m[1,3] * m[2,2];
            var A1312 = m[1,1] * m[2,3] - m[1,3] * m[2,1];
            var A1212 = m[1,1] * m[2,2] - m[1,2] * m[2,1];
            var A0313 = m[1,0] * m[3,3] - m[1,3] * m[3,0];
            var A0213 = m[1,0] * m[3,2] - m[1,2] * m[3,0];
            var A0312 = m[1,0] * m[2,3] - m[1,3] * m[2,0];
            var A0212 = m[1,0] * m[2,2] - m[1,2] * m[2,0];
            var A0113 = m[1,0] * m[3,1] - m[1,1] * m[3,0];
            var A0112 = m[1,0] * m[2,1] - m[1,1] * m[2,0];

            var det = m[0,0] * (m[1,1] * A2323 - m[1,2] * A1323 + m[1,3] * A1223)
                - m[0,1] * (m[1,0] * A2323 - m[1,2] * A0323 + m[1,3] * A0223)
                + m[0,2] * (m[1,0] * A1323 - m[1,1] * A0323 + m[1,3] * A0123)
                - m[0,3] * (m[1,0] * A1223 - m[1,1] * A0223 + m[1,2] * A0123);
            det = 1 / det;

            invertedMatrix[0,0] = det * (m[1,1] * A2323 - m[1,2] * A1323 + m[1,3] * A1223);
            invertedMatrix[0,1] = det * -(m[0,1] * A2323 - m[0,2] * A1323 + m[0,3] * A1223);
            invertedMatrix[0,2] = det * (m[0,1] * A2313 - m[0,2] * A1313 + m[0,3] * A1213);
            invertedMatrix[0,3] = det * -(m[0,1] * A2312 - m[0,2] * A1312 + m[0,3] * A1212);
            invertedMatrix[1,0] = det * -(m[1,0] * A2323 - m[1,2] * A0323 + m[1,3] * A0223);
            invertedMatrix[1,1] = det * (m[0,0] * A2323 - m[0,2] * A0323 + m[0,3] * A0223);
            invertedMatrix[1,2] = det * -(m[0,0] * A2313 - m[0,2] * A0313 + m[0,3] * A0213);
            invertedMatrix[1,3] = det * (m[0,0] * A2312 - m[0,2] * A0312 + m[0,3] * A0212);
            invertedMatrix[2,0] = det * (m[1,0] * A1323 - m[1,1] * A0323 + m[1,3] * A0123);
            invertedMatrix[2,1] = det * -(m[0,0] * A1323 - m[0,1] * A0323 + m[0,3] * A0123);
            invertedMatrix[2,2] = det * (m[0,0] * A1313 - m[0,1] * A0313 + m[0,3] * A0113);
            invertedMatrix[2,3] = det * -(m[0,0] * A1312 - m[0,1] * A0312 + m[0,3] * A0112);
            invertedMatrix[3,0] = det * -(m[1,0] * A1223 - m[1,1] * A0223 + m[1,2] * A0123);
            invertedMatrix[3,1] = det * (m[0,0] * A1223 - m[0,1] * A0223 + m[0,2] * A0123);
            invertedMatrix[3,2] = det * -(m[0,0] * A1213 - m[0,1] * A0213 + m[0,2] * A0113);
            invertedMatrix[3,3] = det * (m[0,0] * A1212 - m[0,1] * A0212 + m[0,2] * A0112);

            return invertedMatrix;
        }

        //Translation matrix construction
        //a translation matrix is a matrix that when applied to a point moves it to a new location
        //when multiplied to a vector does nothing because 0 component of w cancels operation
        public Matrix4 Matrix4MatrixTranslation(float x, float y, float z)
        {
            //to construct a translation matrix we firstly need an identity matrix
            Matrix4 tempyMatrix = new Matrix4(4, 4);
            Matrix4 translationMatrix = tempyMatrix.Matrix4IdentityMatrixCreater(tempyMatrix);

            //once we have our identity matrix, we simply change the values of
            //T03 to x, T13 to y and T23 to z
            translationMatrix.matrix[0, 3] = x;
            translationMatrix.matrix[1, 3] = y;
            translationMatrix.matrix[2, 3] = z;

            return translationMatrix;
        }
    }
}
