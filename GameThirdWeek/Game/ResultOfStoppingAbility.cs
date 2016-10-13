using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ResultOfStoppingAbility : ResultOfAbility
    {
        public Location Location { get; }

        public ResultOfStoppingAbility(DateTime timeOfEnd) : base(timeOfEnd)
        {
        }
    }
}
