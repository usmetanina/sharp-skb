using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class AbilityForStopping : Ability
    {
        public override ResultOfAbility CalculateResult(Personage personage)
        {
            // Pезультат этот способности, заключается в том, что
            // персонаж, на которого применена эта способность, не может передвигаться

            ResultOfStoppingAbility resultOfStoppingAbility = new ResultOfStoppingAbility(DateTime.Now);

            resultOfStoppingAbility.Location.X = personage.GetLocation().X;
            resultOfStoppingAbility.Location.Y = personage.GetLocation().Y;

            return resultOfStoppingAbility;
        }
    }
}
