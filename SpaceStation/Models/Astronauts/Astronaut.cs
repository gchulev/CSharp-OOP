﻿using System;
using System.Collections.Generic;
using System.Text;

using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        private IBag bag;

        public Astronaut(string name, double oxygen)
        {
            this.Name = name;
            this.Oxygen = oxygen;
            this.bag = new Backpack();
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Astronaut name cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Cannot create Astronaut with negative oxygen!");
                }

                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0;

        public IBag Bag
        {
            get => this.bag;
            private set //check later!!! should be public otherwise we can't provide backpack to astronaut
            {
                this.bag = value;
            }
        }

        public virtual void Breath()
        {
            this.Oxygen -= 10;

            if (this.Oxygen <= 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
