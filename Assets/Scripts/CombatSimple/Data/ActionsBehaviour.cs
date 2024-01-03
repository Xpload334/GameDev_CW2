using System.Collections.Generic;
using UnityEngine;

namespace CombatSimple
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ActionBehaviour", order = 0)]
    public class ActionsBehaviour : ScriptableObject
    {
        public ActType actType;
        public int behaviourIndex;
        public List<ActionsBehaviourEntry> behaviours;

        public void Initialise()
        {
            behaviourIndex = 0;
        }
        
        /*
         * Return the latest actions behaviour entry
         */
        public ActionsBehaviourEntry DoAction()
        {
            var entry = behaviours[behaviourIndex];

            //If reached last entry, always return last entry
            if (behaviourIndex < (behaviours.Count - 1))
            {
                behaviourIndex++;
            }
            return entry;
        }
    }
}