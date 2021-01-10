using Cory.RL_Crawler.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Feedbacks
{
    public class TimeFreeze : Feedback
    {
        [SerializeField] private float freezeTimeDelay = 0.01f;
        [SerializeField] private float UnfreezeTimeDelay = 0.02f;
        [SerializeField] [Range(0, 1)] private float timeFreezeAmount = 0.02f;

        public override void CompletePreviousFeedback()
        {
            TimeController.instance.ResetTimeScale();
        }

        public override void CreateFeedback()
        {
            // set the values after the delay and then Reset the time scale after the duration of the unfreeze delay
            TimeController.instance.SetTimeScale(timeFreezeAmount, UnfreezeTimeDelay, () => TimeController.instance.SetTimeScale(1, UnfreezeTimeDelay));
        }
    }
}