﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public interface IBuyer
    {
        public int Food { get; }
        public string Name { get; }

        void BuyFood();
    }
}
