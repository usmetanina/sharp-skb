using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Ability
    {
        protected int id;
        protected string description;
        protected int cost;

        protected int durationOfRecharge;
        protected int durationOfAction;

        protected DateTime timeOfEndOfReload;

        protected Effect effect;

        public Ability()
        {
            // При создании способности, нужно создать эффект для этой способоности определённого типа

            //int value;
            //effect = new EffectAbilityForHealth(value); //например для здоровья
        }

        public bool IsAvailable() 
        {
            // Если время конца перезарядки больше чем текущее, то способность дотупна
            return true;
        }

        public virtual void Execute(Personage personage)
        {
            effect.Personage = personage;
            effect.Begin(new DateTime().AddMilliseconds(durationOfAction));
        }
    }
}
