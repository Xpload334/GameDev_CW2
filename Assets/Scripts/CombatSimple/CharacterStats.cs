using System.Collections.Generic;
using UnityEngine;

namespace CombatSimple
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Character Stats", order = 1)]
    public class CharacterStats : ScriptableObject
    {
        public string name;
        
        [Header("Health")]
        public float maxHealth; //Maximum health
        public float currentHealth; //Current health, when depleted to 0, character is defeated

        [Header("Attacks")] 
        public List<Attack> attacks;
        
        [Header("Actions")] 
        public float maxActionPoints = 100;
        public float currentActionPoints = 0;
        public List<ActionsBehaviour> actionBehaviours;
        public ActionsBehaviour defaultBehaviour; //Behaviour for when an action doesn't do anything
        
        [TextArea(15,20)]
        public string description;

        public void Initialise()
        {
            currentHealth = maxHealth;
            foreach (var behaviour in actionBehaviours)
            {
                behaviour.Initialise();
            }
        }
        
        
    }
}