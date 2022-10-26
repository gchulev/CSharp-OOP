using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OnlineShop.Common.Enums;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Computers;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IComputer> computers;
        private readonly ICollection<IComponent> components;
        private readonly ICollection<IPeripheral> peripherials;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherials = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            IComponent component;

            if (componentType == "RandomAccessMemory")
            {
                component = new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "VideoCard")
            {
                component = new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                component = new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                component = new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                component = new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "CentralProcessingUnit")
            {
                component = new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                throw new ArgumentException("Component type is invalid.");
            }

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            computer.AddComponent(component);
            this.components.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            IComputer computer;

            if (computerType == "DesktopComputer")
            {
                computer = new DesktopComputer(id, manufacturer, model, price);
            }
            else if (computerType == "Laptop")
            {
                computer = new Laptop(id, manufacturer, model, price);
            }
            else
            {
                throw new ArgumentException($"Computer type is invalid.");
            }

            if (this.computers.Any(c => c.Id == computer.Id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            this.computers.Add(computer);

            return $"Computer with id {id} added successfully.";
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);

            if (this.peripherials.Any(p => p.Id == id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            IPeripheral peripherial;

            if (peripheralType == "Headset")
            {
                peripherial = new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                peripherial = new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                peripherial = new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Mouse")
            {
                peripherial = new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }
            computer.AddPeripheral(peripherial);
            this.peripherials.Add(peripherial);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            if (this.computers.Count == 0 || this.computers.All(c => c.Price > budget))
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            IComputer bestPCForMoney = this.computers.OrderByDescending(pc => pc.OverallPerformance).Where(pc => pc.Price <= budget).FirstOrDefault();

            this.computers.Remove(bestPCForMoney);

            return bestPCForMoney.ToString();
        }

        public string BuyComputer(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComputer removedPC = this.computers.FirstOrDefault(c => c.Id == id);
            this.computers.Remove(removedPC);

            return removedPC.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComputer computer = this.computers.FirstOrDefault(pc => pc.Id == id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            IComponent component = computer.RemoveComponent(componentType);

            this.components.Remove(component);

            return $"Successfully removed {componentType} with id {component.Id}";

        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            if (!this.computers.Any(c => c.Id == computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            IComputer computer = this.computers.FirstOrDefault(c => c.Id == computerId);
            IPeripheral peripherial = computer.RemovePeripheral(peripheralType);
            this.peripherials.Remove(peripherial);

            return $"Successfully removed {peripheralType} with id {peripherial.Id}.";
        }
    }
}
