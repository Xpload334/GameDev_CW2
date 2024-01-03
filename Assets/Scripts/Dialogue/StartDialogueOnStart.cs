using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueOnStart : MonoBehaviour
{
    public Dialogue dialogue;

    private DialogueManager _dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        _dialogueManager = FindObjectOfType<DialogueManager>();
        
        _dialogueManager.StartDialogue(dialogue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
