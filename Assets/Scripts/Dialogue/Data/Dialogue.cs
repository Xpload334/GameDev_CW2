using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [System.Serializable]
    public class DialogueEntry
    {
        public string speaker;
        [TextArea(5,10)]
        public string text;
    }

    public DialogueEntry[] entries;

    public UnityAction afterDialogueAction;
    public Dialogue nextObject;
    [Header("Notes")]
    public string notes;
    
}
