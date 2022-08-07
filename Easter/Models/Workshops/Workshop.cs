using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {

        public Workshop()
        {

        }

        public void Color(IEgg egg, IBunny bunny) // Test this logic very carefully since it is a bit complicated
        {
            while (bunny.Energy > 0 && bunny.Dyes.Count > 0 && !egg.IsDone())
            {
                IDye currentDye = bunny.Dyes.FirstOrDefault();

                egg.GetColored();
                bunny.Work();
                currentDye.Use();

                if (currentDye.IsFinished())
                {
                    bunny.Dyes.Remove(currentDye);
                }
            }
        }
    }
}
