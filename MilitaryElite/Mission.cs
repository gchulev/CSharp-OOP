using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Mission
    {
        private string _state;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }
        public string CodeName { get; private set; }
        public string State 
        {
            get
            {
                return this._state;
            } 
            private set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("Invalid mission state!");
                }
                this._state = value;
            }
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
