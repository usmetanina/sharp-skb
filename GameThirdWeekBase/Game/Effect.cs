using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Effect
    {
        public Personage Personage { get; set; }
        protected DateTime timeOfEndOfAction;

        public int value { get; protected set;}

        public Effect(int value)
        {
            this.value = value;
        }

        public bool IsActive()
        {
            if (timeOfEndOfAction.CompareTo(new DateTime()) < 0)
                    return false;

            return true;
        }

        public virtual void Finish()
        {
            // Вызывается когда эффект закончился, для того, чтобы вернуть 
            // в прежнее состояние характеристику персонажа
        }

        public virtual void Begin(DateTime timeOfEndOfAction)
        {
        }
    }
}