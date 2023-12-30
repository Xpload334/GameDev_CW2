using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlowPrint : MonoBehaviour
{
    // public TMP_Text textUI;
    public TMP_Text dialogueText; // Reference to the UI text element to display dialogue
    public float printSpeed = 0.1f; // Speed at which text is printed
    public float punctuationPause = 0.3f; // Pause duration after printing punctuation

    private Coroutine currentPrintCoroutine; // Reference to the current print coroutine

    // Coroutine to print text letter-by-letter
    private IEnumerator PrintText(string text)
    {
        dialogueText.text = ""; // Clear the text initially
        foreach (char letter in text)
        {
            dialogueText.text += letter; // Append one letter

            // Check for punctuation and introduce a longer pause
            if (IsPunctuation(letter))
            {
                yield return new WaitForSeconds(punctuationPause);
            }
            else
            {
                yield return new WaitForSeconds(printSpeed); // Wait for the next letter
            }
        }
    }

    // Method to check if a character is punctuation
    private bool IsPunctuation(char character)
    {
        return char.IsPunctuation(character);
    }

    // Method to start printing text slowly
    public void StartSlowPrint(string text)
    {
        if (currentPrintCoroutine != null)
        {
            StopCoroutine(currentPrintCoroutine); // Stop any ongoing coroutine
        }
        currentPrintCoroutine = StartCoroutine(PrintText(text)); // Start new coroutine
    }

    // Method to stop printing immediately
    public void StopPrint()
    {
        if (currentPrintCoroutine != null)
        {
            StopCoroutine(currentPrintCoroutine);
        }
    }
}