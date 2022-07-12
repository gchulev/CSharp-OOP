using System;
using System.Collections.Generic;
using System.Text;
using MilitaryElite.Interfaces;

namespace MilitaryElite
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        private List<Private> _privates;

        public LieutenantGeneral(string firstName, string lastName, int id, double salary) : base(firstName, lastName, id, salary)
        {
            this._privates = new List<Private>();
        }
        public IReadOnlyCollection<Private> Privates
        {
            get => this._privates;
        }

        public void AddPrivate(Private prv)
        {
            this._privates.Add(prv);
        }
        public override string ToString()
        {
            if (Privates.Count == 0)
            {
                return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}Privates:";
            }
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}Privates:{Environment.NewLine}  {string.Join($"{Environment.NewLine}  ", this.Privates)}";
        }
    }
}
