using System;
using CombatSimple.UI;
using DefaultNamespace;
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

        [Header("Dialogue Attacks")] 
        public Dialogue dialogueAttackedEnemyWithActPoints;

        [Header("UI")] 
        public CharacterUI playerUI;
        public CharacterUI enemyUI;
        public PlayerMenuUI playerMenuUI;

        [Header("Paths")] 
        public int thisBattleNum = 1;
        public PlayerPathManager pathManager;

        public bool shouldSkipToEnd = false;

        private void Start()
        {
            StartState();
            // throw new NotImplementedException();
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
            SetCurrentState(CombatStateSimple.Start);
            ApplyPathCheck();

            InitialisePlayer();
            InitialiseEnemy();

            UpdatePlayerUI();
            UpdateEnemyUI();

            //If there is any starting dialogue, play it
            if (enemyCharacter.characterStats.startingDialogue != null)
            {
                playerMenuUI.DisableUI();
                dialogueManager.StartDialogue(enemyCharacter.characterStats.startingDialogue, StartCombat);
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
            pathManager = FindObjectOfType<PlayerPathManager>();

            //First battle
            switch (thisBattleNum)
            {
                //No battles
                case 0:
                {
                    //None
                    pathManager.battleNum = 1;
                    break;
                }
                //Wolf battle
                case 1:
                {
                    //No effects
                    break;
                }
                //Goblin battle
                case 2:
                {
                    if (pathManager.wolfBefriended)
                    {
                        //Wolf befriended
                        enemyCharacter.characterStats = pathManager.GoblinStats_WolfAct;
                    }
                    else
                    {
                        //Wolf defeated
                        enemyCharacter.characterStats = pathManager.GoblinStats_WolfAttack;
                    }
                    break;
                }
                case 3:
                {
                    break;
                }
            }
        }
        
        /*
         * Call to start the loop of characters fighting
         */
        public void StartCombat()
        {
            Debug.Log("Starting combat");
            if (shouldSkipToEnd)
            {
                StartWinAct();
            }
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
            
            //Dialogue and after action
            if (attack.dialogue != null)
            {
                dialogueManager.StartDialogue(attack.dialogue, () =>
                {
                    playerCharacter.TakeDamage(damage);
                    UpdatePlayerUI();
                    
                    EndEnemyTurn();
                });
            }
            else
            {
                playerCharacter.TakeDamage(damage);
                UpdatePlayerUI();
                    
                EndEnemyTurn();
            }
            
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
            if (enemyCharacter.characterStats.winDialogueAttack != null)
            {
                dialogueManager.StartDialogue(enemyCharacter.characterStats.winDialogueAttack, WinAttack);
            }
        }
        
        void StartWinAct()
        {
            Debug.Log("Enemy defeated with acts");
            if (enemyCharacter.characterStats.winDialogueAct != null)
            {
                dialogueManager.StartDialogue(enemyCharacter.characterStats.winDialogueAct, WinAct);
            }
        }

        void StartLose()
        {
            Debug.Log("Player defeated");
            if (enemyCharacter.characterStats.losingDialogue != null)
            {
                dialogueManager.StartDialogue(enemyCharacter.characterStats.losingDialogue, RestartCombat);
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
            
            //Which battle
            switch (pathManager.battleNum)
            {
                case 1:
                {
                    pathManager.SetWolfBefriended(false);
                    pathManager.battleNum = 2;
                    FindObjectOfType<MySceneManager>().GoblinBattle();
                    break;
                }
                case 2:
                {
                    pathManager.SetGoblinBefriended(false);
                    pathManager.battleNum = 3;
                    FindObjectOfType<MySceneManager>().WizardBattle();
                    break;   
                }
                case 3:
                {
                    Debug.Log("Game beaten! (Attacked)");
                    //Go back to title
                    FindObjectOfType<MySceneManager>().TitleScreen();
                    break;
                }
            }
        }

        void WinAct()
        {
            //Which battle
            switch (pathManager.battleNum)
            {
                case 1:
                {
                    pathManager.SetWolfBefriended(true);
                    pathManager.battleNum = 2;
                    FindObjectOfType<MySceneManager>().GoblinBattle();
                    break;
                }
                case 2:
                {
                    pathManager.SetGoblinBefriended(true);
                    pathManager.battleNum = 3;
                    FindObjectOfType<MySceneManager>().WizardBattle();
                    break;   
                }
                case 3:
                {
                    Debug.Log("Game beaten! (Acted)");
                    //Go back to title
                    FindObjectOfType<MySceneManager>().TitleScreen();
                    break;
                }
            }
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
            if (dialogueAttackedEnemyWithActPoints != null && enemyCharacter.GetActionPoints() > 0)
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
                if (attack.dialogue != null)
                {
                    dialogueManager.StartDialogue(attack.dialogue, () =>
                    {
                        enemyCharacter.TakeDamage(damage);
                        UpdateEnemyUI();
                    
                        EndPlayerTurn(enemyAttack);
                    });
                }
                else
                {
                    enemyCharacter.TakeDamage(damage);
                    UpdateEnemyUI();
                    
                    EndPlayerTurn(enemyAttack);
                }
                
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

            if (entry.dialogue != null)
            {
                dialogueManager.StartDialogue(entry.dialogue, () =>
                {
                    enemyCharacter.AddActionPoints(entry.actionPointsGain);
                    UpdateEnemyUI();
                
                    EndPlayerTurn(enemyAttack);
                });
            }
            else
            {
                enemyCharacter.AddActionPoints(entry.actionPointsGain);
                UpdateEnemyUI();
                
                EndPlayerTurn(enemyAttack);
            }
            
            
        }

        /*
         * Enemy performs an attack
         */
        public void EnemyAttacksPlayer(Attack attack)
        {
            Debug.Log("Enemy attacks with "+attack+"("+attack.damageType+")");
            var damage = attack.GetDamage(playerCharacter.currentDamageType);

            if (attack.dialogue != null)
            {
                dialogueManager.StartDialogue(attack.dialogue, () =>
                {
                    playerCharacter.TakeDamage(damage);
                    UpdatePlayerUI();
                    EndEnemyTurn();
                });
            }
            else
            {
                playerCharacter.TakeDamage(damage);
                UpdatePlayerUI();
                EndEnemyTurn();
            }
            
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

        void InitialisePlayer()
        {
            playerCharacter.InitialiseStats();
            playerUI.SetPortrait(playerCharacter.characterStats.portrait);
        }

        void InitialiseEnemy()
        {
            enemyCharacter.InitialiseStats();
            enemyUI.SetPortrait(enemyCharacter.characterStats.portrait);
        }
    }
}