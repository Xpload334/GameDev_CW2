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
            StartCombat();
            // throw new NotImplementedException();
        }

        private void Update()
        {
            // throw new NotImplementedException();
        }

        // public void NextState()
        // {
        //     previousState = currentState;
        //     switch (currentState)
        //     {
        //         case CombatStateSimple.Start:
        //             StartCombat();
        //             break;
        //         case CombatStateSimple.Dialogue: //Unused
        //             break;
        //         /////////////
        //         //Combat loop
        //         case CombatStateSimple.PlayerTurn:
        //             EndPlayerTurn();
        //             break;
        //         case CombatStateSimple.PlayerTurnEnd:
        //             StartEnemyTurn();
        //             break;
        //         case CombatStateSimple.EnemyTurn:
        //             EndEnemyTurn();
        //             break;
        //         case CombatStateSimple.EnemyTurnEnd:
        //             StartPlayerTurn();
        //             break;
        //         //////////////
        //         case CombatStateSimple.WinAttack:
        //             StartWinAttack();
        //             break;
        //         case CombatStateSimple.WinAct:
        //             StartWinAct();
        //             break;
        //         case CombatStateSimple.Lose:
        //             StartLose();
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        // }

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
                dialogueManager.StartDialogue(startingDialogue, StartCombat);
            }
            else
            {
                StartCombat();
            }
        }
        
        /*
         * Call to start the loop of characters fighting
         */
        public void StartCombat()
        {
            Debug.Log("Starting combat");
            StartPlayerTurn();
        }

        public void StartPlayerTurn()
        {
            //Enable player UI
            SetCurrentState(CombatStateSimple.PlayerTurn);
        }

        /*
         * End player turn button
         */
        public void EndPlayerTurn()
        {
            //Disable player UI
            SetCurrentState(CombatStateSimple.PlayerTurnEnd);
            //Check if enemy dead
            if (enemyCharacter.isDead)
            {
                //Move to win attack
                StartWinAttack();
            }
            //Check if enemy spared
            else if (enemyCharacter.isSpared)
            {
                //Move to win act
                StartWinAct();
            }
            //Else, start enemy turn
            else
            {
                StartEnemyTurn();
            }
        }

        public void StartEnemyTurn()
        {
            SetCurrentState(CombatStateSimple.EnemyTurn);
        }

        public void EndEnemyTurn()
        {
            SetCurrentState(CombatStateSimple.EnemyTurnEnd);
            //Check if player is alive
            if (playerCharacter.isDead)
            {
                
            }
        }

        void StartWinAttack()
        {
            if (winDialogueAttack != null)
            {
                dialogueManager.StartDialogue(winDialogueAttack, WinAttack);
            }
        }
        
        void StartWinAct()
        {
            if (winDialogueAct != null)
            {
                dialogueManager.StartDialogue(winDialogueAct, WinAct);
            }
        }

        void StartLose()
        {
            if (losingDialogue != null)
            {
                dialogueManager.StartDialogue(losingDialogue, RestartCombat);
            }
        }
        
        /*
         * Call when the player loses
         *
         * Restart scene
         */
        public void RestartCombat()
        {
            Debug.Log("Restarting combat");
        }

        void WinAttack()
        {
            //Set enemy attack to true in PlayerPrefs
            //Move to next scene
        }

        void WinAct()
        {
            //Set enemy attack to false in PlayerPrefs
            //Move to next scene
        }
        
        


        /*
         * Player performs an attack
         */
        public void AttackPlayer(Attack attack)
        {
            Debug.Log("Player attacks with "+attack+"("+attack.damageType+")");
            float damage = attack.GetDamage(enemyCharacter.currentDamageType);
            
        }

        /*
         * Player performs a given action to the enemy.
         *
         * Check 
         */
        public void ActPlayer(ActType actType)
        {
            Debug.Log("Player acts with "+actType);
            ActionsBehaviourEntry entry = enemyCharacter.GetActionEntry(actType);
            dialogueManager.StartDialogue(entry.dialogue, () =>
            {
                enemyCharacter.AddActionPoints(entry.actionPointsGain);
            });
            
        }

        /*
         * Enemy performs an attack
         */
        public void AttackEnemy(Attack attack)
        {
            Debug.Log("Enemy attacks with "+attack+"("+attack.damageType+")");
            float damage = attack.GetDamage(playerCharacter.currentDamageType);
        }

        float GetAttackDamage(Attack attack, DamageType opposingDamageType)
        {
            return attack.GetDamage(opposingDamageType);
        }
    }
}