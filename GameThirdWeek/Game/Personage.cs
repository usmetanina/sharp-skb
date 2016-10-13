﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Personage
    {
        private Location location;

        private int hitPoints;
        private int health;
        private int speedMovement;
        private int speedRegenerationOfMana;
        private int mana;

        private Dictionary<int, Ability> abilities;
        private List<ResultOfAbility> personageChanges;

        Personage()
        {
        }

        public int GetCurrentHealth()
        {
            int currentHelth = health;

            // Перебираем все действующие к персонажу результаты способностей (personageChanges)
            // Берём только differenceOfHealth из каждого ResultOfAbility
            // Рассчитываем currentHelth

            return currentHelth;
        }

        public int GetCurrentSpeed()
        {
            int currentSpeed = speedMovement;
            // Перебираем все действующие к персонажу результаты способностей (personageChanges)
            // Берём только differenceOfSpeed из каждого ResultOfAbility
            // Рассчитываем currentSpeed

            return currentSpeed;
        }

        public int GetCurrentMana()
        {
            int currentMana = mana;

            // Перебираем все действующие к персонажу результаты способностей (personageChanges)
            // Берём только differenceOfMana из каждого ResultOfAbility
            // Рассчитываем currentMana

            return currentMana;
        }

        public void UseAbility(Personage personage, int id)
        {
            // Первый аргумент - на кого применяем способность, второй - id способности, которую применяем    
            // Находим в Dictionary необходимую способность    
            // У текущего персонажа списываем стоимость применённой спобности
            // и прибавляем действующие на него последствия способности, которые рассчитываются, то есть

            // Ability ability = abilities[id];
            // AddResultOfAbility(ability.CalculateResult());
        }

        public void AddAbility(Ability ability)
        {
        }

        public void AddResultOfAbility(ResultOfAbility resultOfAbility)
        {
        }

        public List<Ability> GetAvailableAbilities()
        {
            // Перебираем все имеющиеся способности и формируем список только доступных
            return null;
        }

        public Location GetLocation()
        {
            // Проверяем среди применённых на персонажа способностей есть ли 
            // которые останавливают его на месте.
            // Если да, то учитываем этот resultOfStoppingAbility,
            // иначе возвращаем текущее местоположение

            return location;
        }

   }
}
