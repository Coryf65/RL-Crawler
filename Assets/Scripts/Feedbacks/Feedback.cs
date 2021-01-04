using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Feedbacks
{
    public abstract class Feedback : MonoBehaviour
    {

        public abstract void CreateFeedback();
        
        public abstract void CompletePreviousFeedback();

        protected virtual void OnDestroy()
        {
            // preventing calling coroutine on a object the is "Destroyed"
            CompletePreviousFeedback();
        }
    }
}