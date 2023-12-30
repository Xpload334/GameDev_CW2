using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public SlowPrint slowPrinter;
    public DialogueBox dialogueBox; //UI element for dialogue box
    private DialogueObject currentDialogue; // Current dialogue object being displayed
    private bool isDialogueActive = false; // Flag to check if dialogue is active
    public InputAction advanceAction; // InputAction for advancing dialogue

    private void Awake()
    {
        slowPrinter.dialogueText = dialogueBox.dialogueText;
    }

    private void OnEnable()
    {
        advanceAction.Enable();
        advanceAction.performed += AdvanceDialogue;
    }

    private void OnDisable()
    {
        advanceAction.Disable();
        advanceAction.performed -= AdvanceDialogue;
    }

    // Function to start a piece of dialogue
    public void StartDialogue(DialogueObject dialogue)
    {
        Debug.Log("Starting dialogue "+dialogue.name);
        currentDialogue = dialogue;
        isDialogueActive = true;
        // Open dialogue box or UI element here
        dialogueBox.BoxOpen(true);
        dialogueBox.ClearText(); // Clear the text
        dialogueBox.speakerText.text = currentDialogue.speaker;
        
        
        DisplayNext();
    }

    // Function to advance to the next dialogue
    public void DisplayNext()
    {
        if (!isDialogueActive) return;
        if (currentDialogue != null)
        {
            // Start printing the text slowly
            slowPrinter.StartSlowPrint(currentDialogue.text);
                
            // Check if there's a next dialogue object
            if (currentDialogue.nextObject != null)
            {
                currentDialogue = currentDialogue.nextObject;
            }
            else
            {
                // No more dialogue, close dialogue box or UI element
                CloseDialogue();
            }
        }
        else
        {
            CloseDialogue();
        }
    }

    // Function to close the dialogue box
    private void CloseDialogue()
    {
        isDialogueActive = false;
        // Close dialogue box or UI element here
        // dialogueText.text = ""; // Clear the text
        dialogueBox.BoxOpen(false);
        slowPrinter.StopPrint(); // Stop printing if it's still in progress
    }

    // Callback for advancing dialogue triggered by InputAction
    private void AdvanceDialogue(InputAction.CallbackContext context)
    {
        if (isDialogueActive)
        {
            DisplayNext();
        }
    }
}
