using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EffectAbilityForSpeed : Effect
    {
        public EffectAbilityForSpeed(int value) : base(value)
        {

        }

        public override void Begin(DateTime timeOfEndOfAction)
        {
            this.timeOfEndOfAction = timeOfEndOfAction; // Ставим время окончания
            Personage.SpeedMovement += value;
        }

        public override void Finish()
        {
            Personage.SpeedMovement -= value;
        }
    }
}