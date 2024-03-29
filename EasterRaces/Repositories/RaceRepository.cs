﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using EasterRaces.Models.Races.Contracts;

namespace EasterRaces.Repositories
{
    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            return this.Models.FirstOrDefault(r => r.Name == name);
        }
    }
}
