using System;
using System.Collections.Generic;
using System.Text;


namespace RayTracerChallenge
{
    public class Sphere
    {
        public Point origin;
        public int radius;
        public Matrix4 transformation;
        public static int sphereId = 0;

        //our sphere is simplified by being centered at the origin and having unit length
        public Sphere() 
        {
            origin = new Point(x: 0, y: 0, z: 0);
            radius = 1;

            //the default transformation is the identity matrix;
            transformation = new Matrix4(4, 4);

            Console.WriteLine($"sphereId: {sphereId}");

            //ensuring each sphereId is unique
            sphereId++;
        }

        //this method sets a transformation to a circle's transformation matrix
        public void SphereSetTransformation(Matrix4 transformationMatrix)
        {
            this.transformation = transformationMatrix;
        }

        //getting surface normal vector
        public Vector SphereSurfaceNormalVector(Sphere sphere, Point worldPoint)
        {
            //transform point from world space to object space

            //invert transformation matrix
            float[,] inverseTransformation = Matrix4.Matrix4MatrixInversion(sphere.transformation.matrix);
            Matrix4 inverseTransformationMatrix = new Matrix4(4, 4);
            inverseTransformationMatrix.matrix = inverseTransformation;

            //multiply the inverted transformation matrix to the world point to transform it into
            //object space
            Point objectPoint = worldPoint.PointMatrixMultiplication(worldPoint, inverseTransformationMatrix);

            //get the normal vector
            //this is done by getting the vector that travels from the origin of the sphere to the objectPoint
            Vector objectNormal = objectPoint.PointPointSubtraction(objectPoint, new Point(0, 0, 0));

            //transform it into world space
            //first get the transpose of the inverted transformation matrix
            float[,] transposedInverted = Matrix4.Matrix4MatrixTranspose(inverseTransformationMatrix.matrix);
            Matrix4 transposedInvertedMatrix = new Matrix4(4, 4);
            transposedInvertedMatrix.matrix = transposedInverted;

            //compute world normal
            Vector worldNormal = objectNormal.VectorMatrixMultiplication(objectNormal, transposedInvertedMatrix);
            worldNormal.w = 0f;

            //normalize it
            return worldNormal.VectorNormalization(worldNormal);
        }
    }
}
