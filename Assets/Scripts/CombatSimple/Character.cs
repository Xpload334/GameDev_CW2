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

        public bool isEnemy;
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
            //Get list of attacks that can be played
            var availableAttacks = new List<Attack>();
            foreach (var attack in characterStats.attacks)
            {
                if (characterStats.currentActionPoints >= attack.minActionPoints && characterStats.currentActionPoints < attack.maxActionPoints)
                {
                    availableAttacks.Add(attack);
                }
            }
            
            return availableAttacks[Random.Range(0, availableAttacks.Count - 1)];
        }

        public void PlayAttack(Attack attack)
        {
            if (isEnemy)
            {
                combatManager.PlayerAttacksEnemy(attack);
            }
            else
            {
                combatManager.EnemyAttacksPlayer(attack);
            }
        }
        

        public void TakeDamage(int damage)
        {
            characterStats.currentHealth -= damage;
            Debug.Log("Character "+name+" took "+damage+" damage ["+GetHealth()+" HP]");
            if (GetHealth() <= 0)
            {
                characterStats.currentHealth = 0;
                isDead = true;
            }
        }

        public void AddActionPoints(int actionPoints)
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

        public void SetActionPoints(int points)
        {
            characterStats.currentActionPoints = points;
        }

        public int GetMaxActionPoints()
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

        public void ChangeDamageType(DamageType type)
        {
            Debug.Log("Character "+characterStats.name+" changed to type "+type);
            currentDamageType = type;
        }
    }
}