using System;
using UnityEngine;

namespace CombatSimple
{
    public class CombatManagerSimple: MonoBehaviour
    {
        public CombatStateSimple currentState;
        public CombatStateSimple previousState;
        public DialogueManager dialogueManager;
        public Character playerCharacter;
        public Character enemyCharacter;

        [Header("Dialogue")]
        public Dialogue startingDialogue;
        public Dialogue winDialogueAttack;
        public Dialogue winDialogueAct;
        public Dialogue losingDialogue;

        private void Start()
        {
            // throw new NotImplementedException();
        }

        private void Update()
        {
            // throw new NotImplementedException();
        }

        public void NextState()
        {
            previousState = currentState;
            switch (currentState)
            {
                case CombatStateSimple.Start:
                    StartCombat();
                    break;
                case CombatStateSimple.Dialogue: //Unused
                    break;
                /////////////
                //Combat loop
                case CombatStateSimple.PlayerTurn:
                    EndPlayerTurn();
                    break;
                case CombatStateSimple.PlayerTurnEnd:
                    StartEnemyTurn();
                    break;
                case CombatStateSimple.EnemyTurn:
                    EndEnemyTurn();
                    break;
                case CombatStateSimple.EnemyTurnEnd:
                    StartPlayerTurn();
                    break;
                //////////////
                case CombatStateSimple.WinAttack:
                    
                    break;
                case CombatStateSimple.WinAct:
                    break;
                case CombatStateSimple.Lose:
                    RestartCombat();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SetCurrentState(CombatStateSimple state)
        {
            currentState = state;
        }

        /*
         * First state in combat
         */
        public void StartState()
        {
            //If there is any starting dialogue, play it
            if (startingDialogue != null)
            {
                dialogueManager.StartDialogue(startingDialogue, () =>
                {
                            
                });
            }
        }
        
        /*
         * Call to start the loop of characters fighting
         */
        public void StartCombat()
        {
            StartPlayerTurn();
        }

        public void StartPlayerTurn()
        {
            //Enable player UI
            SetCurrentState(CombatStateSimple.PlayerTurn);
        }

        public void EndPlayerTurn()
        {
            //Disable player UI
            SetCurrentState(CombatStateSimple.PlayerTurnEnd);
        }

        public void StartEnemyTurn()
        {
            SetCurrentState(CombatStateSimple.EnemyTurn);
        }

        public void EndEnemyTurn()
        {
            SetCurrentState(CombatStateSimple.EnemyTurnEnd);
        }

        // public void StartDialogueState()
        // {
        //     //Interrupts a state then returns to the previous state
        //     SetCurrentState(CombatStateSimple.Dialogue);
        //     dialogueManager.StartDialogue();
        // }

        /*
         * Call when the player loses
         */
        public void RestartCombat()
        {
            
        }
        
        


        public void AttackPlayer(Attack attack)
        {
            
        }

        public void AttackEnemy(Attack attack)
        {
            
        }

        float GetAttackDamage(Attack attack, DamageType opposingDamageType)
        {
            return attack.GetDamage(opposingDamageType);
        }
    }
}