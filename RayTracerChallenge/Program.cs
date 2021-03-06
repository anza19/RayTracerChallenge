using System;

namespace RayTracerChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Colour c1 = new Colour(1, 0.2f, 0.4f);
            Colour c2 = new Colour(0.9f, 1, 0.1f);

            Colour hadamardProd = c1.ColourMultiplication(c1, c2);
        }
    }
}
