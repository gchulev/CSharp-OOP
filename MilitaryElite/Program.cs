using MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite
{
    public class Program
    {
        static void Main()
        {
            var soldiers = new List<ISoldier>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("End"))
                {
                    break;
                }

                string[] input = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string soldierType = input[0];
                int id = int.Parse(input[1]);
                string firstName = input[2];
                string lastName = input[3];

                if (soldierType.Equals("Private"))
                {
                    double salary = double.Parse(input[4]);
                    var privateSoldier = new Private(firstName, lastName, id, salary);
                    soldiers.Add(privateSoldier);
                }
                else if (soldierType.Equals("LieutenantGeneral"))
                {
                    double salary = double.Parse(input[4]);
                    var lieutenantGeneral = new LieutenantGeneral(firstName, lastName, id, salary);

                    for (int i = 5; i < input.Length; i++)
                    {
                        Private privateSoldier = (Private)soldiers.FirstOrDefault(x => x.Id.Equals(int.Parse(input[i])));
                        lieutenantGeneral.AddPrivate(privateSoldier);
                    }
                    soldiers.Add(lieutenantGeneral);
                }
                else if (soldierType.Equals("Engineer"))
                {
                    try
                    {
                        double salary = double.Parse(input[4]);
                        string corps = input[5];

                        var engineer = new Engineer(firstName, lastName, id, salary, corps);

                        for (int i = 6; i < input.Length; i += 2)
                        {
                            string partName = string.Empty;
                            int workedHours = 0;

                            partName = input[i];
                            workedHours = int.Parse(input[i + 1]);

                            var repair = new Repair(partName, workedHours);
                            engineer.AddRepair(repair);
                        }
                        soldiers.Add(engineer);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Equals("Invalid corps!"))
                            continue;
                    }

                }
                else if (soldierType.Equals("Commando"))
                {
                    try
                    {
                        double salary = double.Parse(input[4]);
                        string corps = input[5];
                        var commando = new Commando(firstName, lastName, id, salary, corps);

                        for (int i = 6; i < input.Length; i += 2)
                        {
                            string missionName = string.Empty;
                            string missionState = string.Empty;

                            missionName = input[i];
                            missionState = input[i + 1];

                            try
                            {
                                var mission = new Mission(missionName, missionState);
                                commando.AddMission(mission);

                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                        soldiers.Add(commando);
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Equals("Invalid corps!"))
                            continue;
                    }

                }
                else if (soldierType.Equals("Spy"))
                {
                    int codeNumber = int.Parse(input[4]);
                    var spy = new Spy(id, firstName, lastName, codeNumber);
                    soldiers.Add(spy);
                }
            }
           
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier.ToString());
            }
        }
    }
}
