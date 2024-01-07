using System.Collections.Generic;
using UnityEngine;

namespace CombatSimple
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character Stats", order = 1)]
    public class CharacterStats : ScriptableObject
    {
        // public string name;
        public string characterName = "Unknown";
        public Sprite portrait;
        
        [Header("Health")]
        public int maxHealth = 50; //Maximum health
        public int currentHealth = 50; //Current health, when depleted to 0, character is defeated

        [Header("Attacks")] 
        public List<Attack> attacks;
        
        [Header("Actions")] 
        public int maxActionPoints = 100;
        public int currentActionPoints = 0;
        public List<ActionsBehaviour> actionBehaviours;
        public ActionsBehaviour defaultBehaviour; //Behaviour for when an action doesn't do anything
        
        [Header("Dialogue")]
        public Dialogue startingDialogue;
        public Dialogue winDialogueAttack;
        public Dialogue winDialogueAct;
        public Dialogue losingDialogue;

        [TextArea(15,20)]
        public string description;

        public void Initialise()
        {
            currentHealth = maxHealth;
            currentActionPoints = 0;
            foreach (var behaviour in actionBehaviours)
            {
                behaviour.Initialise();
            }
        }


    }
}