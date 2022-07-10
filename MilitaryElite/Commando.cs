using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Commando : SpecialisedSoldier, ISpecialisedSoldier
    {
        private List<Mission> _missions;
        public Commando(string firstName, string lastName, int id, double salary, string corps) : base(firstName, lastName, id, salary, corps)
        {
            this._missions = new List<Mission>();
        }

        public IReadOnlyCollection<Mission> Missions { get => this._missions; }

        public void AddMission(Mission mission)
        {
            this._missions.Add(mission);
        }
        public override string ToString()
        {
            if (this.Missions.Count == 0)
            {
                return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}Corps: {this.Corps}{Environment.NewLine}Missions:";
            }
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}{Environment.NewLine}Corps: {this.Corps}{Environment.NewLine}Missions:{Environment.NewLine}{string.Join(Environment.NewLine, this.Missions)}";
        }
    }
}
