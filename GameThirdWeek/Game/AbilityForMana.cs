using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class AbilityForMana : Ability // разновидность способности
    {
        public override ResultOfAbility CalculateResult()
        {
            // У данного вида способности другие последствия
            // меняющие количество маны

            // resultOfAbility.differenceOfMana = -150;
            return null;
        }
    }
}
