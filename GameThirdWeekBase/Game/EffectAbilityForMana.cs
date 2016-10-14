using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EffectAbilityForMana : Effect
    {
        public EffectAbilityForMana(int value) : base(value)
        {

        }

        public override void Begin(DateTime timeOfEndOfAction)
        {
            this.timeOfEndOfAction = timeOfEndOfAction; // Ставим время окончания
            Personage.Mana += value;
        }

        public override void Finish()
        {
            Personage.Mana -= value;
        }
    }
}