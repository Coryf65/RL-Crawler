using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public abstract class AudioPlayer : MonoBehaviour
    {
        protected AudioSource audioSource;
        [SerializeField] protected float pitchRandomizer = 0.05f;
        protected float basePitch;

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

    }
}