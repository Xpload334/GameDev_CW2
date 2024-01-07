using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.Sounds;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Dialogue", order = 1)]
public class Dialogue : ScriptableObject
{
    [System.Serializable]
    public class DialogueEntry
    {
        public string speaker;
        // public Sprite speakerSprite;
        [TextArea(5,10)]
        public string text;
    }

    public DialogueEntry[] entries;

    public UnityEvent startDialogueAction;
    public UnityEvent afterDialogueAction;
    public Dialogue nextObject;
    [Header("Notes")]
    public string notes;


    public void StopAllLoopingAudio()
    {
        foreach (SoundPrefab soundPrefab in FindObjectsOfType<SoundPrefab>())
        {
            try
            {
                if (soundPrefab.ShouldLoop())
                {
                    soundPrefab.Stop();
                }
            }
            catch
            {
                //None
            }
        }
    }
}
