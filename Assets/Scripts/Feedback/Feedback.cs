using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Feedback
{
    public abstract class Feedback : MonoBehaviour
    {

        public abstract void CreateFeedback();
        
        public abstract void CompletePreviousFeedback();
    }
}