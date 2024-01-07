using System;
using UnityEngine;

namespace DefaultNamespace.Sounds
{
    public class SoundPrefab : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void Play()
        {
            _audioSource.Play();
        }

        public bool ShouldLoop()
        {
            return _audioSource.loop;
        }

        public void Stop()
        {
            _audioSource.Stop();
            Destroy(gameObject);
        }
    }
}