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
        public bool isSpared;

        private void Start()
        {
            
        }

        void InitialiseStats()
        {
            characterStats.Initialise();
        }

        public Attack AttackRandom()
        {
            return characterStats.attacks[Random.Range(0, characterStats.attacks.Count - 1)];
        }
        

        public void TakeDamage(float damage)
        {
            characterStats.currentHealth -= damage;
            Debug.Log("Character "+name+" took "+damage+" damage ["+GetHealth()+" HP]");
            if (GetHealth() <= 0)
            {
                characterStats.currentHealth = 0;
                isDead = true;
            }
        }

        public void AddActionPoints(float actionPoints)
        {
            characterStats.currentActionPoints += actionPoints;
            Debug.Log("Character "+name+" added "+actionPoints+" action points ["+GetActionPoints()+" AP]");
            if (GetActionPoints() >= GetMaxActionPoints())
            {
                characterStats.currentActionPoints = GetMaxActionPoints();
                isSpared = true;
            }
        }
        
        public ActionsBehaviourEntry GetActionEntry(ActType actType)
        {
            //Default
            if (characterStats.actionBehaviours.Count <= 0) return characterStats.defaultBehaviour.DoAction();
            
            //Check act types
            foreach (var actionBehaviour in characterStats.actionBehaviours)
            {
                if (actionBehaviour.actType == actType)
                {
                    return actionBehaviour.DoAction();
                }
            }
            //Default
            return characterStats.defaultBehaviour.DoAction();

        }
        
        public float GetHealth()
        {
            return characterStats.currentHealth;
        }

        public float GetMaxHealth()
        {
            return characterStats.maxHealth;
        }

        public float GetActionPoints()
        {
            return characterStats.currentActionPoints;
        }

        public float GetMaxActionPoints()
        {
            return characterStats.maxActionPoints;
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