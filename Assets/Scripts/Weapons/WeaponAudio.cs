using Cory.RL_Crawler.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Weapons
{
    public class WeaponAudio : AudioPlayer
    {
        [SerializeField]
        private AudioClip shootBulletClip = null;

        [SerializeField]
        private AudioClip outOfBulletsClip = null;

        public void ShootSound()
        {
            PlayClipWithRandomPitch(shootBulletClip);
        }

        public void NoBulletSound()
        {
            PlayClipWithRandomPitch(outOfBulletsClip);
        }
    }
}