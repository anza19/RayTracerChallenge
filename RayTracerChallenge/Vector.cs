using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    //Vector inherits from Tuple
    public class Vector : TupleRT
    {
        public Vector() : base()
        {

        }

        //Vectors have a w value of 0
        public Vector(float x, float y, float z, float w = 0.0f): base(x, y, z, w)
        {
            Console.WriteLine($"Vector created. x = {x}, y = {y}, z = {z}, w = {w}");
        }

        //this method performs vector addition
        public Vector VectorAddition(Vector a, Vector b)
        {
            //in vector addition, we add each component of one vector to the component of the other vector
            //so a.x adds to b.x etc etc...
            float x = a.x + b.x;
            float y = a.y + b.y;
            float z = a.z + b.z;
            float w = a.w + b.w;

            Vector result = new Vector(x, y, z, w);
            return result;
        }

        //this method performs vector subtraction
        public Vector VectorSubtraction(Vector a, Vector b)
        {
            //in vector subtraction, we subtract each component of one vector to the component of the other vector
            //so a.x - b.x etc etc...
            float x = a.x - b.x;
            float y = a.y - b.y;
            float z = a.z - b.z;
            float w = a.w - b.w;

            Vector result = new Vector(x, y, z, w);
            return result;
        }

        //returns the negation of a vector
        public Vector VectorNegate(Vector v)
        {
            return new Vector(-v.x, -v.y, -v.z);
        }

        //Scalar multiplication method
        //this method multiples a scalar to a vector
        public Vector VectorScalarMultiplication(Vector v, float scalar)
        {
            float x = scalar * v.x;
            float y = scalar * v.y;
            float z = scalar * v.z;
            float w = 0.0f;

            return new Vector(x, y, z, w);
        }

        //this method computes the magnitude of the vector
        //in the context of vectors, magnitude is defined as the length of the vector
        //its how far you would travel in a straight line if you walked from
        //one end of the vector to another
        //it is computed using Pythagorean theorem
        public float VectorMagnitude (Vector v)
        {
            float xSquared = v.x * v.x;
            float ySquared = v.y * v.y;
            float zSquared = v.z * v.z;
            float wSquared = 0.0f;

            //pythagorean theorem
            float magnitude = (float)Math.Sqrt(xSquared + ySquared + zSquared + wSquared);
            return magnitude;
        }

        //this method normalizes any arbitrary vector
        //what that means is that it converts a vector V to a vector with magnitude 1
        //this method ensures that our vector calculations are anchored relative to a common scale
        //If you were to skip normalizing your ray vectors or your surface normals, your calculations would be
        //scaled differently for every ray you cast
        public Vector VectorNormalization(Vector v)
        {
            float magnitude = VectorMagnitude(v);
            return new Vector(v.x / magnitude, v.y / magnitude, v.z / magnitude, 0.0f);
        }

        //this method returns the dot product between two vectors
        //dot product is computed by multiplying each component of one vector
        //to the subsequent component of another vector
        //then computing their sum
        //smaller the dot product, larger the angle between the two vectors
        public float VectorDotProduct(Vector a, Vector b)
        {
            float x = a.x * b.x;
            float y = a.y * b.y;
            float z = a.z * b.z;
            float w = 0.0f;

            float dotProduct = x + y + z + w;
            return dotProduct;
        }

        //this method returns the cross product of two vectors
        //the cross product returns a vector perpendicular to the original two vectors
        //resultant vector is always perpendicular to the input vectors
        public Vector VectorCrossProduct(Vector a, Vector b)
        {
            float x = (a.y * b.z) - (a.z * b.y); 
            float y = (a.z * b.x) - (a.x * b.z); 
            float z = (a.x * b.y) - (a.y * b.x);

            return new Vector(x, y, z, 0.0f);
        }
    }
}
