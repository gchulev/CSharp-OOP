using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Spy : Soldier
    {
        public Spy(int id, string firstName, string lastName, int codeNumber) : base(firstName, lastName, id)
        {
            this.CodeNumber = codeNumber;
        }
        public int CodeNumber { get; private set; }

        public override string ToString()
        {
            return $"Name: {this.FirstName} {this.LastName} Id: {this.Id}{Environment.NewLine}Code Number: {this.CodeNumber}";
        }
    }
}
