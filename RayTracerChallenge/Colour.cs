using System;
using System.Collections.Generic;
using System.Text;

namespace RayTracerChallenge
{
    public class Colour
    {
        //The colour class with r => red, g => green, b => blue
        public float r;
        public float g;
        public float b;

        public Colour() { }
        public Colour(float r, float g, float b)
        {
            this.r = r;
            this.g = g;
            this.b = b;

            Console.WriteLine($"Colour created with r:{r}, g:{g}, b:{b}");
        }

        //this adds two colours to form a new one
        public Colour ColourAddition(Colour c1, Colour c2)
        {
            float r = c1.r + c2.r;
            float g = c1.g + c2.g;
            float b = c1.b + c2.b;

            return new Colour(r, g, b);
        }

        //this subtracts two colours to form a new one
        public Colour ColourSubtraction(Colour c1, Colour c2)
        {
            float r = c1.r - c2.r;
            float g = c1.g - c2.g;
            float b = c1.b - c2.b;

            return new Colour(r, g, b);
        }

        //scalar multiplication
        public Colour ColourScalarMultiplication(Colour c, float scalar)
        {
            float r = c.r * scalar;
            float g = c.g * scalar;
            float b = c.b * scalar;

            return new Colour(r, g, b);
        }

        //Colour multiplication allows us to blend two colours together
        //this gives us the resultant colour of the interaction of light when illuminating a coloured surface
        //this is computing by multiplying corresponding components of two colours together
        //it is called the Hadamard product
        public Colour ColourMultiplication(Colour c1, Colour c2)
        {
            //this is computed by multiplying a component of one colour
            //to subsequent component of another colour
            float r = c1.r * c2.r;
            float g = c1.g * c2.g;
            float b = c1.b * c2.b;

            return new Colour(r, g, b);
        }
    }
}
