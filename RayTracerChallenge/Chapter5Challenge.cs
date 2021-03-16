using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    public class Chapter5Challenge
    {
        //this class is the mini project from chapter 5
        //this class casts a ray, finds its intersects with an object in the world space
        //draws it on a wall, then writes it to an image file
        public Chapter5Challenge(){}

        public static void Chapter5RayCaster() 
        {
            //we fire a ray at a sphere, then draw it to a canvas

            //need the origin for the ray
            Point rayOrigin = new Point(0, 0, -5);

            //we need how far along the z axis the wall is from the sphere which is at the origin
            float wallZ = 10.0f;

            //from the distance of the wall from the sphere, using the concepts of similar triangles
            //we can extrapolate the length and width of the wall, i.e length along x and y axis
            //how large it will be
            float temp = (wallZ + (rayOrigin.z * -1.0f)) / (rayOrigin.z * -1.0f);

            //we add an extra one to accomodate the shadow of the object which will be drawn on the wall
            float wallSize = (temp * 2) + 1;

            //we also need to get the maximum and minimum x and y values of the wall which is simply half of 
            //the wallSize when viewed from the center of the unit sphere
            float halfWallSize = wallSize / 2;

            //we need a canvas on which we will draw the wall
            int canvasSize = 100;
            Canvas canvas = new Canvas(canvasSize, canvasSize);

            //the sphere which we are intersecting our ray with
            Sphere s = new Sphere();

            //the simple colour we are drawing on the scene
            //blue for this challenge
            Colour blue = new Colour(0,0,1);

            //size of the pixel on the wall
            float pixelWallSize = wallSize / canvasSize;

            //cycle through the canvas and on each intersection colour pixel
            for(int i = 0; i < canvas.height; i++)
            {
                //compute world y coordinate
                float worldY = halfWallSize - (pixelWallSize * i);

                for(int j = 0; j < canvas.width; j++)
                {
                    //compute world x coordinate
                    float worldX = -halfWallSize + (pixelWallSize * j);

                    //next we need the point on the wall where the ray will finish it's journey starting from origin
                    Point rayEnd = new Point(worldX, worldY, wallZ);

                    //we get the vector from start to end
                    Vector directionVector = rayOrigin.PointPointSubtraction(rayEnd, rayOrigin);

                    //normalize it
                    Vector normalizedDirectionVector = directionVector.VectorNormalization(directionVector);

                    //construct ray from origin and normalized direction vector
                    Ray r = new Ray(rayOrigin, normalizedDirectionVector);

                    //intersect this ray with the sphere
                    List<Intersection> intersections = r.RaySphereIntersection(r, s);

                    //if we have a hit, we colour that point
                    if(Intersection.Hit(intersections) != null)
                    {
                        canvas.CanvasWritePixel(i, j, blue);
                    }

                    //else colour black
                    else
                    {
                        canvas.CanvasWritePixel(i, j, new Colour(0, 0, 0));
                    }
                }
            }

            PPMCreater.PPMCreaterImageFile(canvas, 255);
        }
    }
}
