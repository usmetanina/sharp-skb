using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EffectAbilityForHealth : Effect
    {
        public EffectAbilityForHealth(int value) : base(value)
        {

        }

        public override void Begin(DateTime timeOfEndOfAction)
        {
            this.timeOfEndOfAction = timeOfEndOfAction; // Ставим время окончания
            Personage.Health += value; // Применяем
        }

        public override void Finish()
        {
            Personage.Health -= value;
        }
    }
}