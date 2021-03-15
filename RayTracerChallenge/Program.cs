using System;
using System.Collections.Generic;

namespace RayTracerChallenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Canvas canvas = new Canvas(100, 100);
            Colour blue = new Colour(1, 1, 0);
            Sphere shape = new Sphere();
            Point rayOrigin = new Point(0, 0, -5);

            float wallZ = 10.0f;
            float wallSize = 7.0f;
            float pixelSize = wallSize / 100;
            float halfSize = wallSize / 2;

            for(int i = 0; i < canvas.height; i++)
            {
                float worldY = halfSize - (pixelSize * i);
                for(int j = 0; j < canvas.width; j++)
                {
                    float worldX = -halfSize + (pixelSize * j);
                    Point position = new Point(worldX, worldY, wallZ);

                    Vector direction = position.PointPointSubtraction(position, rayOrigin);
                    Vector normalized = direction.VectorNormalization(direction);

                    Ray r = new Ray(rayOrigin, normalized);
                    List<Intersection> intersections = r.RaySphereIntersection(r, shape);

                    if(Intersection.Hit(intersections) != null)
                    {
                        Random rnd = new Random();
                        float red = rnd.Next(0, 2);
                        Console.WriteLine($"red:{red}");
                        float g = rnd.Next(0, 2);
                        Console.WriteLine($"g:{g}");
                        float b = rnd.Next(0, 2);
                        Console.WriteLine($"b:{b}");
                        canvas.CanvasWritePixel(j, i, new Colour(red, g, b));
                    }
                    else
                    {
                        canvas.CanvasWritePixel(j, i, new Colour(0,0,0));
                    }
                }

            }

            PPMCreater.PPMCreaterImageFile(canvas, 255);
        }
    }
}
