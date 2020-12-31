using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Audio
{
    public class AudioHandler : AudioPlayer
    {
        [SerializeField] AudioClip walkingClip;

        public void PlayStepSound()
        {
            PlayClipWithRandomPitch(walkingClip);
        }
    }
}