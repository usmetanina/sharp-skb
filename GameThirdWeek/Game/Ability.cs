﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Ability
    {
        protected int id;
        protected string description;
        protected int cost;

        protected int durationOfRecharge;
        protected int durationOfAction;

        protected DateTime timeOfEndOfReload;

        public bool IsAvailable() 
        {
            // Если время конца перезарядки больше чем текущее, то способность дотупна
            return true;
        }

        public virtual ResultOfAbility CalculateResult()
        {
            return null;
        }

        public virtual ResultOfAbility CalculateResult(Personage personage)
        {
            return null;
        }
    }
}
