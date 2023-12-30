using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class DialogueObject : ScriptableObject
{
    public string speaker;
    [TextArea(15,20)]
    public string text;

    public string notes;
    public DialogueObject nextObject;
}
