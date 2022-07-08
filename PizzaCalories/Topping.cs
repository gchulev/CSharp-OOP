using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        private const int BASE_GRAMS_CALORIES = 2;

        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"meat", 1.2 },
            {"veggies", 0.8 },
            {"cheese", 1.1 },
            {"sauce", 0.9 }
        };

        private string _toppingType;
        private double _grams;

        public Topping(string toppingType, double grams)
        {
            this.Toppingtype = toppingType;
            this.Grams = grams;
        }

        public string Toppingtype
        {
            get
            {
                return this._toppingType;
            }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies"
                && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this._toppingType = value;
            }
        }
        public double Grams 
        {
            get
            {
                return this._grams;
            }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.Toppingtype} weight should be in the range [1..50].");
                }
                this._grams = value;
            }
        }
        public double Calories { get { return BASE_GRAMS_CALORIES * this.Grams * modifiers[this.Toppingtype.ToLower()]; } }
    }
}
