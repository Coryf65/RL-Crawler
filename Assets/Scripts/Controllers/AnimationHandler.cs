using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Controllers
{
    [RequireComponent(typeof(Animator))]
    public class AnimationHandler : MonoBehaviour
    {
        protected Animator animator;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        /// <summary>
        /// Set the walking animation for the Animator
        /// </summary>
        /// <param name="value"></param>
        public void SetWalkAnimation(bool value)
        {
            animator.SetBool("Walk", value);
        }

        public void AnimatePlayer(float velocity)
        {
            SetWalkAnimation(velocity > 0);
        }
    }
}