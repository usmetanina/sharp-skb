using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
   public class Personage
    {
        private int hitPoints;
        public int Health { get; set; }
        public int SpeedMovement { get; set; }
        private int speedRegenerationOfMana;
        public int Mana { get; set; }

        private Dictionary<int, Ability> abilities;

        Personage()
        {
        }

        public void UseAbility(Personage personage, int id)
        {
            // Первый аргумент - на кого применяем способность, второй - id способности, которую применяем    
            // Находим в Dictionary необходимую способность  
             
            Ability ability = abilities[id];
            
            // У текущего персонажа списываем стоимость применённой спобности
            // Отдаём персонажа, на которого применяем, в руки эффекта

            ability.Execute(personage);

        }

        public void AddAbility(Ability ability)
        {
        }


        public List<Ability> GetAvailableAbilities()
        {
            // Перебираем все имеющиеся способности и формируем список только доступных
            return null;
        }
   }
}
