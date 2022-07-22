using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdSplit = args.Split();
            string cmdName = cmdSplit[0];
            string[] cmdArgs = cmdSplit.Skip(1).ToArray();

            Assembly assembly = Assembly.GetEntryAssembly();

            Type cmdType = assembly.GetTypes().FirstOrDefault(t => t.Name == $"{cmdName}Command" && t.GetInterfaces().Any(i => i == typeof(ICommand)));

            if (cmdType == null)
            {
                throw new ArgumentNullException($"{cmdName}Command is null or doesn't implement ICommand interface!");
            }

            object typeInstance = Activator.CreateInstance(cmdType);
            MethodInfo methodToExecute = cmdType.GetMethod("Execute");
            string result = (string)methodToExecute.Invoke(typeInstance, new object[] { cmdArgs });

            return result;
        }
    }
}
