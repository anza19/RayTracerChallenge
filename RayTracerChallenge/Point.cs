using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    //Point inherits from Tuple
    public class Point : TupleRT
    {
        public Point() : base()
        {

        }

        //Point has a w value of 1
        public Point(float x, float y, float z, float w = 1.0f) : base(x, y, z, w)
        {
            Console.WriteLine($"Point created. x = {x}, y = {y}, z = {z}, w = {w}");
        }

        //this method adds a vector to a point and determines new point
        //after moving in direction of vector
        public Point PointVectorAddition(Point p, Vector v)
        {
            //in point-vector addition, we add each component of the point to the component of the vector
            //so a.x adds to b.x etc etc...
            float x = p.x + v.x;
            float y = p.y + v.y;
            float z = p.z + v.z;
            float w = p.w + v.w;

            Point result = new Point(x, y, z, w);
            return result;
        }

        //this method takes two points and subtracts them
        public Vector PointPointSubtraction(Point p1, Point p2)
        {
            //in point - point subtraction we subtract the components of each point from each other
            //this results in a vector, which points in the direction from p2 to p1
            float x = p1.x - p2.x;
            float y = p1.y - p2.y;
            float z = p1.z - p2.z;
            float w = p1.w - p2.w;

            Vector result = new Vector(x, y, z, w);
            return result;
        }

        //this method subtracts a vector from a point, resulting in a point
        public Point PointVectorSubtraction(Point p, Vector v)
        {
            float x = p.x - v.x;
            float y = p.y - v.y;
            float z = p.z - v.z;
            float w = p.w - v.w;

            Point result = new Point(x, y, z, w);
            return result;
        }

        //returns the negation of a point
        public Point PointNegate(Point p)
        {
            return new Point(-p.x, -p.y, -p.z);
        }

        //this method multiplies a matrix to a point in order to transform it
        public Point PointMatrixMultiplication(Point p, Matrix4 mat4)
        {
            float[] temp = new float[4];
            for (int i = 0; i < 4; i++)
            {
                float m = mat4.matrix[i, 0] * p.x + mat4.matrix[i, 1] * p.y + mat4.matrix[i, 2] * p.z + mat4.matrix[i, 3] * p.w;
                temp[i] = m;
            }

            float x = temp[0];
            float y = temp[1];
            float z = temp[2];
            float w = temp[3];

            return new Point(x, y, z, 1.0f);
        }

    }
}
