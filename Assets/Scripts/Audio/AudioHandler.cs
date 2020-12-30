using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioHandler : MonoBehaviour
    {
        protected AudioSource audioSource;
        [SerializeField] protected float pitchRandomizer = 0.05f;
        protected float basePitch;
        [SerializeField] AudioClip walkingClip;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            basePitch = audioSource.pitch;
        }

        protected void PlayClipWithRandomPitch(AudioClip audioClip)
        {
            var randomPitch = Random.Range(-pitchRandomizer, +pitchRandomizer);
            audioSource.pitch = basePitch + randomPitch;
            PlayClip(audioClip);
        }

        private void PlayClip(AudioClip audioClip)
        {
            audioSource.Stop();
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        public void PlayStepSound()
        {
            PlayClipWithRandomPitch(walkingClip);
        }
    }
}