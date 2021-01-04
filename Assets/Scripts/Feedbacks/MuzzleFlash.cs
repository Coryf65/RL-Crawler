using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Cory.RL_Crawler.Feedbacks
{
    public class MuzzleFlash : Feedback
    {

        [SerializeField] private Light2D lightTarget = null;
        [SerializeField] private float lightOnDelay = 0.01f;
        [SerializeField] private float lightOffDelay = 0.01f;
        [SerializeField] private bool defaultState = false;

        public override void CompletePreviousFeedback()
        {
            StopAllCoroutines();
            lightTarget.enabled = false;
        }

        public override void CreateFeedback()
        {
            // wait call coroutine turn on light, wait turn off light
            StartCoroutine(ToggleLight(lightOnDelay, true, () => StartCoroutine(ToggleLight(lightOffDelay, false))));
        }
        
        IEnumerator ToggleLight(float time, bool result, Action finishCallback = null)
        {
            yield return new WaitForSeconds(time);
            lightTarget.enabled = result;
            finishCallback?.Invoke();
        }
    }
}