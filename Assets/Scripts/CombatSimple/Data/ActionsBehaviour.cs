using System.Collections.Generic;
using UnityEngine;

namespace CombatSimple
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ActionBehaviour", order = 0)]
    public class ActionsBehaviour : ScriptableObject
    {
        public ActType actType;
        [Header("First Action")] 
        public List<ActionsBehaviourEntry> behaviours;


        [System.Serializable]
        public class ActionsBehaviourEntry
        {
            public float actionPointsGain;
            public DialogueObject dialogueObject;
        }
    }
}