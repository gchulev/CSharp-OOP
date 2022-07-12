using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Engineer : SpecialisedSoldier, ISpecialisedSoldier
    {
        private List<Repair> _repairs;

        public Engineer(string firstName, string lastName, int id, double salary, string corps) : base(firstName, lastName, id, salary, corps)
        {
            this._repairs = new List<Repair>();
        }

        public IReadOnlyCollection<Repair> Repairs{ get => this._repairs; }

        public void AddRepair(Repair rep)
        {
            this._repairs.Add(rep);
        }

        public override string ToString()
        {
            if (this.Repairs.Count == 0)
            {
                return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}Corps: {this.Corps}{Environment.NewLine}Repairs:";
            }
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}Corps: {this.Corps}{Environment.NewLine}Repairs:{Environment.NewLine}{string.Join(Environment.NewLine, this.Repairs)}";

        }
    }
}
