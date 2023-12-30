using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueOnStart : MonoBehaviour
{
    public DialogueObject dialogueObject;

    private DialogueManager _dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        
        _dialogueManager.StartDialogue(dialogueObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
