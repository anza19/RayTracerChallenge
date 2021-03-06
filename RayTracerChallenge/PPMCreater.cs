using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    public class PPMCreater
    {
        //structure of PPM file
        //every PPM file begins with a header consisting of the following 3 lines
        //first the string: P3, followed by a new line
        //second, a line with the image WIDTH and HEIGHT
        //third, specifies the MAXIMUM colour value
        //e.g:
        /*
         * P3
         * 80 40
         * 255
         */
        public Canvas canvas;

        public PPMCreater() { }

        //this method writes a canvas to PPM image file
        //for extreme simplicity what I have done is I write one pixel to an image at a time
        //this is not optimised but easy to understand to debug the image
        public static void PPMCreaterImageFile(Canvas canvas, int maxValue)
        {
            string header = $"P3\n{canvas.width} {canvas.height}\n{maxValue}\n";
            string rgbValues = "";
            for(int i = 0; i < canvas.width; i++)
            {
                for(int j = 0; j < canvas.height; j++)
                {
                    //we have to clamp the pixels r,g and b value such that they do not exceed [0,255]
                    int r = PPMImageScaler(canvas.pixels[i, j].r, 1, 0);
                    int g = PPMImageScaler(canvas.pixels[i, j].g, 1, 0);
                    int b = PPMImageScaler(canvas.pixels[i, j].b, 1, 0);

                    rgbValues += r + " " + g + " " + b +"\n";
                }
            }

            //concatenate the header and rgbstring
            string image = header + rgbValues;
            File.WriteAllText("C:\\Users\\p1252c6\\source\\repos\\RayTracerChallenge\\RayTracerChallenge\\image.ppm", image);

        }

        //this method clamps an r,g and b value between [0, 255]
        public static int PPMImageScaler(float chroma, int maxValue, int minValue = 0)
        {
            //if it exceeds maxValue, simply return maxValue
            if(chroma >= maxValue)
            {
                return 255;
            }    

            //if its less than the minValue, return minValue
            else if(chroma <= minValue)
            {
                return 0;
            }

            //simply return whatever value it is
            else
            {
                //upscale to [0,255] range and return
                float colour = chroma * 255;
                return (int)(colour);
            }
        }


    }
}
