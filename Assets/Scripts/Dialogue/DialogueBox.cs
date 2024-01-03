using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    private Animator _animator;
    private static readonly int BoxOpenPar = Animator.StringToHash("BoxOpen");
    public TMP_Text dialogueText; //UI text element to display dialogue
    public TMP_Text speakerText;
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void BoxOpen(bool state)
    {
        _animator.SetBool(BoxOpenPar, state);
    }
    
    public void ClearText()
    {
        dialogueText.text = "";
    }

    public void ClearSpeaker()
    {
        speakerText.text = "";
    }
}
