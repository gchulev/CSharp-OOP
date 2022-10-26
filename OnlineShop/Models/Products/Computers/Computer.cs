using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherials;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherials = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return base.OverallPerformance;
                }

                return base.OverallPerformance + this.Components.Average(c => c.OverallPerformance);
            }
        }

        public override decimal Price => base.Price + this.Components.Sum(c => c.Price) + this.Peripherals.Sum(p => p.Price);

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherials;

        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType() == component.GetType()))
            {
                throw new ArgumentException($"Component {component.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (this.Peripherals.Any(p => p.GetType() == peripheral.GetType()))
            {
                throw new ArgumentException($"Peripheral {peripheral.GetType().Name} already exists in {this.GetType().Name} with Id {this.Id}.");
            }

            this.peripherials.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (!this.Components.Any(c => c.GetType().Name == componentType) || this.Components.Count == 0)
            {
                throw new ArgumentException($"Component {componentType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IComponent component = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);
            this.components.Remove(component);

            return component;

        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (this.Peripherals.Any(p => p.GetType().Name != peripheralType) || this.Peripherals.Count == 0)
            {
                throw new ArgumentException($"Peripheral {peripheralType} does not exist in {this.GetType().Name} with Id {this.Id}.");
            }

            IPeripheral periPherial = this.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);
            this.peripherials.Remove(periPherial);

            return periPherial;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            if (this.Components.Count == 0)
            {
                sb.AppendLine(" Components (0):");
            }
            else
            {
                sb.AppendLine($" Components ({(this.Components.Count == 0 ? 0 : this.components.Count)}):");
                sb.AppendLine($"  {string.Join(Environment.NewLine, this.Components)}");
            }

            if (this.Peripherals.Count == 0)
            {
                sb.AppendLine($" Peripherals (0); Average Overall Performance (0.00):");
            }
            else
            {
                sb.AppendLine($" Peripherals ({(this.Peripherals.Count == 0 ? 0 : this.Peripherals.Count)}); Average Overall Performance ({this.Peripherals.Average(p => p.OverallPerformance):f2}):");
                sb.AppendLine($"  {string.Join(Environment.NewLine, this.Peripherals)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
