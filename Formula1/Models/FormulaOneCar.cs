using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string _model;
        private int _horsePower;
        private double _engineDisplacement;

        public FormulaOneCar(string model, int horsepower, double engineDisplacement)
        {
            this.Model = model;
            this.Horsepower = horsepower;
            this.EngineDisplacement = engineDisplacement;
           
        }
        public string Model
        {
            get
            {
                return this._model;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                this._model = value;
            }
        }

        public int Horsepower
        {
            get
            {
                return this._horsePower;
            }
            private set
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                this._horsePower = value;
            }
        }

        public double EngineDisplacement
        {
            get
            {
                return this._engineDisplacement;
            }
            private set
            {
                if (value < 1.6 || value > 2.00)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                this._engineDisplacement = value;
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return this.EngineDisplacement / this.Horsepower * laps;
        }
    }
}
