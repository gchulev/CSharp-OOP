using System;
using System.Collections.Generic;
using System.Text;

namespace EasterRaces.Models.Cars
{
    public class MuscleCar : Car
    {
        private const double CUBICCENTIMETERS = 5000;
        private const int MinimumHorsePower = 400;
        private const int MaximumHorsePower = 600;
        public MuscleCar(string model, int horsePower) 
            : base(model, horsePower, CUBICCENTIMETERS, MinimumHorsePower, MaximumHorsePower)
        {
        }
    }
}
