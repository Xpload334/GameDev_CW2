using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public SlowPrint slowPrinter;
    public DialogueBox dialogueBox; //UI element for dialogue box
    private Dialogue currentDialogue; // Current dialogue object being displayed
    private int dialogueIndex;
    private bool isDialogueActive = false; // Flag to check if dialogue is active
    public InputAction advanceAction; // InputAction for advancing dialogue

    public UnityAction dialogueFinishedAction;

    private void Awake()
    {
        slowPrinter.dialogueText = dialogueBox.dialogueText;
    }

    private void OnEnable()
    {
        advanceAction.Enable();
        advanceAction.started += AdvanceDialogue;
    }

    private void OnDisable()
    {
        advanceAction.Disable();
        advanceAction.canceled -= AdvanceDialogue;
    }

    // Function to start a piece of dialogue
    // public void StartDialogue(DialogueObject dialogue)
    // {
    //     Debug.Log("Starting dialogue "+dialogue.name);
    //     currentDialogue = dialogue;
    //     isDialogueActive = true;
    //     // Open dialogue box or UI element here
    //     dialogueBox.BoxOpen(true);
    //     dialogueBox.ClearText(); // Clear the text
    //     dialogueBox.speakerText.text = currentDialogue.speaker;
    //     
    //     
    //     DisplayNext();
    // }
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting dialogue "+dialogue.name);
        currentDialogue = dialogue;
        isDialogueActive = true;
        dialogueIndex = 0;
        // Open dialogue box or UI element here
        dialogueBox.BoxOpen(true);
        dialogueBox.ClearText(); // Clear the text

        dialogue.startDialogueAction?.Invoke(); //Start dialogue action, if any
        DisplayNext();
    }

    public void StartDialogue(Dialogue dialogue, UnityAction onFinishedAction)
    {
        dialogueFinishedAction = onFinishedAction;
        StartDialogue(dialogue);
    }

    // Function to advance to the next dialogue
    public void DisplayNext()
    {
        //If not active, return
        if (!isDialogueActive) return;
        //If dialogue is null, close
        if (currentDialogue == null)
        {
            CloseDialogue();
            return;
        }
        //If pressed, skip to the full text
        if (slowPrinter.isRunning)
        {
            slowPrinter.StopPrint();
            return;
        }
        //If end of list, close dialogue
        if (dialogueIndex >= currentDialogue.entries.Length)
        {
            CloseDialogue();
            return;
        }
        
        // Start printing the text slowly
        dialogueBox.speakerText.text = currentDialogue.entries[dialogueIndex].speaker; //Set speaker
        slowPrinter.StartSlowPrint(currentDialogue.entries[dialogueIndex].text); //Start slow print of text

        dialogueIndex++;
    }

    // Function to close the dialogue box
    private void CloseDialogue()
    {
        isDialogueActive = false;
        // Close dialogue box or UI element here
        // dialogueText.text = ""; // Clear the text
        dialogueBox.BoxOpen(false);
        slowPrinter.StopPrint(); // Stop printing if it's still in progress

        //Call any after-dialogue actions
        if (currentDialogue == null) return;
        currentDialogue.afterDialogueAction?.Invoke();
        dialogueFinishedAction?.Invoke();
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
