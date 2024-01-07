using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioClip peacefulTravelMusic;
    public AudioClip combatMusic;
    public AudioClip genocideAmbienceMusic;
    public AudioSource SFXSource;

    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitCombatAudio() {
        SFXSource.GetComponent<SFXScript>().PlaySFX(5);
        audioSource.Stop();
        audioSource.clip = peacefulTravelMusic;
        audioSource.volume = 0.1F;
        audioSource.Play();
    }

    public void ExitKillAudio() {
        SFXSource.GetComponent<SFXScript>().PlaySFX(5);
        audioSource.Stop();
        audioSource.clip = genocideAmbienceMusic;
        audioSource.volume = 0.2F;
        audioSource.Play();
    }

    public void EnterCombatAudio() {
        SFXSource.GetComponent<SFXScript>().PlaySFX(6);
        audioSource.Stop();
        audioSource.clip = combatMusic;
        audioSource.volume = 0.2F;
        audioSource.Play();
    }
}
