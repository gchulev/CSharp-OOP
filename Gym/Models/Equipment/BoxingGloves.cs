using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public class BoxingGloves : Equipment
    {
        private const double  BOXING_GLOVES_WEIGHT = 227;
        private const decimal BOXING_BLOVES_PRICE = 120;
        public BoxingGloves() : base(BOXING_GLOVES_WEIGHT, BOXING_BLOVES_PRICE)
        {
          
        }
    }
}
