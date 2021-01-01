using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Audio
{
    /// <summary>
    ///  Class to play sounds for any Entity, Player/Enemy
    /// </summary>
    public class EntitySounds : AudioPlayer
    {
        //
        [SerializeField] private AudioClip hitClip = null;
        [SerializeField] private AudioClip deathClip = null;
        [SerializeField] private AudioClip voiceLineClip = null;

        public void PlayHitSound()
        {
            PlayClipWithRandomPitch(hitClip);
        }

        public void PlayDeathClip()
        {
            PlayClipWithRandomPitch(deathClip);
        }

        public void PlayVoiceClip()
        {
            PlayClipWithRandomPitch(voiceLineClip);
        }
    }
}