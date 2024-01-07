using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using UnityEngine;

public class SFXScript : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip slash;
    public AudioClip stab;
    public AudioClip strike;
    public AudioClip goodAttack;
    public AudioClip badAttack;
    public AudioClip combatFinished;
    public AudioClip combatStart;

    AudioClip[] SFXClips;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
        SFXClips.Append(slash);
        SFXClips.Append(stab);
        SFXClips.Append(strike);
        SFXClips.Append(goodAttack);
        SFXClips.Append(badAttack);
        SFXClips.Append(combatFinished);
        SFXClips.Append(combatStart);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(int SFXID, float volume) {
        audioSource.PlayOneShot(SFXClips[SFXID], volume);
    }

    public void PlaySFX(int SFXID) {
        audioSource.PlayOneShot(SFXClips[SFXID], 0.5F);
    }

    public void PlaySFX(AudioClip clip) {
        audioSource.PlayOneShot(clip, 0.5F);
    }
}
