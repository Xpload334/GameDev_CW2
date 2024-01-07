using System;
using CombatSimple.UI;
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

        [Header("Dialogue Attacks")] 
        public Dialogue dialogueAttackedEnemyWithActPoints;

        [Header("UI")] 
        public CharacterUI playerUI;
        public CharacterUI enemyUI;
        public PlayerMenuUI playerMenuUI;

        [Header("Paths")] 
        public bool isWolfBattle;
        public bool isGoblinBattle;
        public bool isWizardBattle;

        private void Start()
        {
            StartState();
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
            SetCurrentState(CombatStateSimple.Start);
            playerCharacter.InitialiseStats();
            enemyCharacter.InitialiseStats();
            
            UpdatePlayerUI();
            UpdateEnemyUI();
            
            ApplyPathCheck();
            
            //If there is any starting dialogue, play it
            if (startingDialogue != null)
            {
                playerMenuUI.DisableUI();
                dialogueManager.StartDialogue(startingDialogue, StartCombat);
            }
            else
            {
                StartCombat();
            }
        }

        /*
         * 
         */
        public void ApplyPathCheck()
        {
            Debug.Log("Checking which path");
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
            playerMenuUI.EnableUI();
        }

        /*
         * End player turn button
         */
        public void EndPlayerTurn(Attack enemyAttack)
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
                StartEnemyTurn(enemyAttack);
            }
        }

        /*
         * Allow enemy to attack the player
         */
        public void StartEnemyTurn(Attack attack)
        {
            SetCurrentState(CombatStateSimple.EnemyTurn);
            var damage = attack.GetDamage(playerCharacter.currentDamageType);
            
            dialogueManager.StartDialogue(attack.dialogue, () =>
            {
                playerCharacter.TakeDamage(damage);
                UpdatePlayerUI();
                    
                EndEnemyTurn();
            });
        }

        public void EndEnemyTurn()
        {
            SetCurrentState(CombatStateSimple.EnemyTurnEnd);
            //Check if player is alive
            if (playerCharacter.isDead)
            {
                StartLose();
            }
            else
            {
                //Set turn to player turn
                StartPlayerTurn();
            }
        }

        void StartWinAttack()
        {
            Debug.Log("Enemy defeated with attacks");
            if (winDialogueAttack != null)
            {
                dialogueManager.StartDialogue(winDialogueAttack, WinAttack);
            }
        }
        
        void StartWinAct()
        {
            Debug.Log("Enemy defeated with acts");
            if (winDialogueAct != null)
            {
                dialogueManager.StartDialogue(winDialogueAct, WinAct);
            }
        }

        void StartLose()
        {
            Debug.Log("Player defeated");
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
            //Reload scene
            FindObjectOfType<MySceneManager>().RestartCurrentScene();
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
        public void PlayerAttacksEnemy(Attack attack)
        {
            playerMenuUI.DisableUI();
            
            Debug.Log("Player attacks with "+attack+"("+attack.damageType+")");
            playerCharacter.ChangeDamageType(attack.damageType);
            playerUI.ChangeDamageType(attack.damageType);
            // playerCharacter.currentDamageType = attack.damageType;
            
            //Choose enemy attack type
            var enemyAttack = enemyCharacter.AttackRandom();
            var enemyDamageType = enemyAttack.damageType;
            Debug.Log("Enemy has damage type "+enemyDamageType);
            enemyCharacter.ChangeDamageType(enemyDamageType);
            enemyUI.ChangeDamageType(enemyDamageType);
            
            var damage = attack.GetDamage(enemyCharacter.currentDamageType);

            //If enemy attacked when they have action points (betrayed)
            if (enemyCharacter.GetActionPoints() > 0)
            {
                dialogueManager.StartDialogue(dialogueAttackedEnemyWithActPoints, () =>
                {
                    enemyCharacter.TakeDamage(damage);
                    enemyCharacter.SetActionPoints(0);
                    UpdateEnemyUI();
                    
                    EndPlayerTurn(enemyAttack);
                });
            }
            else
            {
                dialogueManager.StartDialogue(attack.dialogue, () =>
                {
                    enemyCharacter.TakeDamage(damage);
                    UpdateEnemyUI();
                    
                    EndPlayerTurn(enemyAttack);
                });
            }
            
        }

        /*
         * Player performs a given action to the enemy.
         *
         * Check 
         */
        public void ActPlayer(ActType actType)
        {
            playerMenuUI.DisableUI();
            
            Debug.Log("Player acts with "+actType);
            ActionsBehaviourEntry entry = enemyCharacter.GetActionEntry(actType);
            playerCharacter.ChangeDamageType(DamageType.None);
            playerUI.ChangeDamageType(DamageType.None);
            
            //Choose enemy attack type
            var enemyAttack = enemyCharacter.AttackRandom();
            var enemyDamageType = enemyAttack.damageType;
            enemyCharacter.ChangeDamageType(enemyDamageType);
            enemyCharacter.ChangeDamageType(enemyDamageType);
            
            dialogueManager.StartDialogue(entry.dialogue, () =>
            {
                enemyCharacter.AddActionPoints(entry.actionPointsGain);
                UpdateEnemyUI();
                
                EndPlayerTurn(enemyAttack);
            });
            
        }

        /*
         * Enemy performs an attack
         */
        public void EnemyAttacksPlayer(Attack attack)
        {
            Debug.Log("Enemy attacks with "+attack+"("+attack.damageType+")");
            var damage = attack.GetDamage(playerCharacter.currentDamageType);
            dialogueManager.StartDialogue(attack.dialogue, () =>
            {
                playerCharacter.TakeDamage(damage);
                UpdatePlayerUI();
                EndEnemyTurn();
            });
        }

        int GetAttackDamage(Attack attack, DamageType opposingDamageType)
        {
            return attack.GetDamage(opposingDamageType);
        }

        void UpdateEnemyUI()
        {
            enemyUI.UpdateHealth(enemyCharacter.GetHealth());
            enemyUI.maxHealth = enemyCharacter.GetMaxHealth();
            enemyUI.UpdateActionPoints(enemyCharacter.GetActionPoints());
            enemyUI.maxActionPoints = enemyCharacter.GetMaxActionPoints();
        }

        void UpdatePlayerUI()
        {
            playerUI.UpdateHealth(playerCharacter.GetHealth());
            playerUI.maxHealth = playerCharacter.GetHealth();
            playerUI.UpdateActionPoints(playerCharacter.GetActionPoints());
            playerUI.maxHealth = playerCharacter.GetMaxActionPoints();
        }
    }
}