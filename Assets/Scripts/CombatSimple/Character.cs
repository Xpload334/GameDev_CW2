using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace CombatSimple
{
    public class Character : MonoBehaviour
    {
        public CombatManagerSimple combatManager;
        public DamageType currentDamageType;
        public CharacterStats characterStats;
        public bool isDead;

        private void Start()
        {
            
        }

        void InitialiseStats()
        {
            characterStats.currentHealth = GetMaxHealth();
        }

        public void ChooseAttackRandom()
        {
            
        }
        

        void TakeDamage(int damage)
        {
            characterStats.currentHealth -= damage;
            Debug.Log("Character "+name+" took "+damage+" damage ["+GetHealth()+" HP]");
            if (GetHealth() <= 0)
            {
                characterStats.currentHealth = 0;
                isDead = true;
            }
        }




        public float GetHealth()
        {
            return characterStats.currentHealth;
        }

        public float GetMaxHealth()
        {
            return characterStats.maxHealth;
        }

        public List<Attack> GetAttacks()
        {
            return characterStats.attacks;
        }

        public virtual void CharacterDie()
        {
            // throw new NotImplementedException();
            Debug.Log("Character "+characterStats.name+" has died");
        }
    }
}