using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Controllers
{
    /// <summary>
    /// TimeController is a singleton
    /// </summary>
    public class TimeController : MonoBehaviour
    {
        public static TimeController instance;

        private void Awake()
        {
            if (instance == null)
            {
                // create the instance
                instance = this;
            } else if (instance != this)
            {
                // get rid of the duplicate
                Destroy(this);
            } 
        }

        public void ResetTimeScale()
        {
            StopAllCoroutines();
            Time.timeScale = 1; // reset the time
        }

        /// <summary>
        ///  Set the time scale over a period of time
        /// </summary>
        /// <param name="timeValue">amount to set the time scale to</param>
        /// <param name="timeToWait">how long will this need to be running for, duration</param>
        /// <param name="OnCompleted">Action to do when this is all done</param>
        public void SetTimeScale(float timeValue, float timeToWait, Action OnCompleted = null)
        {
            StartCoroutine(TimeScaleCoroutine(timeValue, timeToWait, OnCompleted));
        }

        IEnumerator TimeScaleCoroutine(float timeValue, float timeToWait, Action OnCompleted)
        {
            yield return new WaitForSecondsRealtime(timeToWait); // not afffected by the time scale itself
            Time.timeScale = timeValue;
            OnCompleted?.Invoke();
        }
    }
}