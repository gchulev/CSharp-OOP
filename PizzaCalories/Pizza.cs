using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        private string _name;
        private Dough _dough;
        private List<Topping> _toppings;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        public string Name
        {
            get
            {
                return this._name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this._name = value;
            }
        }
        public int NumberOfToppings
        {
            get
            {
                return this._toppings.Count;
            }
        }

        public IReadOnlyCollection<Topping> Toppings 
        {
            get
            {
                return this._toppings;
            }
            private set
            {
                this._toppings = (List<Topping>)value;
            }
        }

        public Dough Dough 
        {
            get
            {
                return this._dough;
            }
            set
            {
                this._dough = value;
            }
        }

        public double TotalCalories { get => _dough.Calories + _toppings.Sum(x => x.Calories); }

        public void AddTopping(Topping topping)
        {
            if (this._toppings.Count < 0 || this._toppings.Count >= 9)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this._toppings.Add(topping);
        }
    }
}
