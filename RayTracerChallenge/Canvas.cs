using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    public class Canvas
    {
        public int width;
        public int height;
        public Colour[,] pixels;
        public Canvas() { }
        public Canvas(int width, int height)
        {
            this.width = width;
            this.height = height;
            CanvasCreate(width, height);
        }

        //we create a black canvas
        public void CanvasCreate(int width, int height)
        {
            pixels = new Colour[width,height];
            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    pixels[i, j] = new Colour(0.0f, 0.0f, 0.0f);
                }
            }
        }

        //this writes a pixel to a position on the canvas
        //we take a blank canvas and iterate over it until we find the correct position
        //at that point we set the colour value from black to colour we want
        public void CanvasWritePixel(int xPosition, int yPosition, Colour c)
        {
            //placing check to ensure position are within the canvas itself
            if((xPosition >= 0 && xPosition < width) && (yPosition >= 0 && yPosition < height))
            {
                pixels[xPosition, yPosition] = c;
            }
        }

    }
}
