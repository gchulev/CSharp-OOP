using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private const int BASE_GRAMS_CALORIES = 2;

        private readonly Dictionary<string, double> modifiers = new Dictionary<string, double>()
        {
            {"white", 1.5 },
            {"wholegrain", 1 },
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1 }
        };

        private string _bakingTechnique;
        private string _flourType;
        private double _grams;

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
          
        }

        public string FlourType
        {
            get
            {
                return this._flourType;
            }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this._flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this._bakingTechnique;
            }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this._bakingTechnique = value;
            }
        }

        public double Grams
        {
            get
            {
                return this._grams;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this._grams = value;
            }
        }

        public double Calories
        {
            get
            {
                return this.CalculateCalories();
            }
        }

        private double CalculateCalories()
        {
            return BASE_GRAMS_CALORIES * this.Grams * modifiers[this.FlourType.ToLower()] * modifiers[this.BakingTechnique.ToLower()];
        }
    }
}
