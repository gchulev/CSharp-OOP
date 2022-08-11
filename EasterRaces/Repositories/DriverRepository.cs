using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories
{
    public class DriverRepository : Repository<IDriver>
    {
        public override IDriver GetByName(string name)
        {
            return this.Models.FirstOrDefault(d => d.Name == name);
        }
    }
}
