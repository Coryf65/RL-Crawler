using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Feedback
{
    public class Shake : Feedback
    {

        [Header("Object to apply Shake Effects")]
        [SerializeField] private GameObject objectToShake;

        [Header("Shake Settings")]
        [Tooltip("The duration of the tween, between 0 and 10.")]
        [SerializeField] [Range(0, 10)] private float duration = 0.01f;

        [Tooltip("The shake strength, between 0 and 1.")]
        [SerializeField] [Range(0, 1)] private float strength = 1;

        [Tooltip("Indicates how much will the shake vibrate, between 0 and 100.")]
        [SerializeField] [Range(0, 10)] private int vibrato = 10;

        [Tooltip("Indicates how much the shake will be random (0 to 180 - values higher than 90 kind of suck, so beware). Setting it to 0 will shake along a single direction.")]
        [SerializeField] [Range(0, 180)] private float randomness = 90;

        [Tooltip("If TRUE the tween will smoothly snap all values to integers")]
        [SerializeField] private bool snap = false;

        [Tooltip("If TRUE the shake will automatically fadeOut smoothly within the tween's duration, otherwise it will not")]
        [SerializeField] private bool fadeOut = true;

        /// <summary>
        /// make sure previous feedback is completed
        /// </summary>
        public override void CompletePreviousFeedback()
        {
            objectToShake.transform.DOComplete();
        }

        public override void CreateFeedback()
        {
            objectToShake.transform.DOShakePosition(duration, strength, vibrato, randomness, snap, fadeOut);
        }
    }
}