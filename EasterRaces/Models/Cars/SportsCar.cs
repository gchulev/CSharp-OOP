using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public class SportsCar : Car
    {

        private const double CUBICCENTIMETERS = 3000;
        private const int MinimumHorsePower = 250;
        private const int MaximumHorsePower = 450;
        public SportsCar(string model, int horsePower)
            : base(model, horsePower, CUBICCENTIMETERS, MinimumHorsePower, MaximumHorsePower)
        {
        }
    }
}
