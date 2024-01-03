using UnityEngine;

namespace CombatSimple
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/CombatSimple", order = 0)]
    public class ActionsBehaviour : ScriptableObject
    {
        public ActType actType;
        [Header("First Action")]
        public float actionPoints;

        public DialogueObject dialogueObject;
    }
}