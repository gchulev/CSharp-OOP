using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter _commandInterpreter;
        public Engine(ICommandInterpreter cmmandInterpreter)
        {
            this._commandInterpreter = cmmandInterpreter;
        }
        public void Run()
        {
            while (true)
            {
                string input = Console.ReadLine();
                string result = this._commandInterpreter.Read(input);
                Console.WriteLine(result);
            }
        }
    }
}
