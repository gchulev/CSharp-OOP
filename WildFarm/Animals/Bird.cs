﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Animals
{
    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }

        public double WingSize { get; protected set; }

        public override string ToString()
        {
            return $"{base.ToString()}, {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
