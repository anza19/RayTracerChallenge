using System;

namespace RayTracerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Canvas can = new Canvas(100, 100);
            can.CanvasWritePixel(50, 50, new Colour(1f, 0f, 0f));
            can.CanvasWritePixel(50, 51, new Colour(0f, 1f, 0f));
            can.CanvasWritePixel(50, 52, new Colour(0f, 0f, 1f));
            PPMCreater.PPMCreaterImageFile(can, 255);
        }
    }
}
