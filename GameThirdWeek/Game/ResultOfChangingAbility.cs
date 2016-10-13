using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ResultOfChangingAbility : ResultOfAbility
    {
        // Пример последствий замедляющей и отнимающей ману способности:
        // differenceOfHealth = 0;
        // differenceOfHitPoints = 0;
        // differenceOfSpeed = -20;
        // differenceOfMana = -40;
        // differenceOfManaRegeneration = 0;

        public ResultOfChangingAbility(DateTime timeOfEnd) : base(timeOfEnd)
        {
        }

        private int differenceOfHealth;
        private int differenceOfHitPoints;
        private int differenceOfSpeed;
        private int differenceOfMana;
        private int differenceOfManaRegeneration;
    }
}
