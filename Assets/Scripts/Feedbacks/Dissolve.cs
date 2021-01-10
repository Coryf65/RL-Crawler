using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Feedbacks
{
    public class Dissolve : Feedback
    {
        // fields
        [SerializeField] private SpriteRenderer spriteRenderer = null;
        [SerializeField] private float duration = 0.05f;
        
        // property
        [field: SerializeField] public UnityEvent DeathCallback { get; set; }

        public override void CompletePreviousFeedback()
        {
            spriteRenderer.DOComplete();
            spriteRenderer.material.DOComplete();
        }

        public override void CreateFeedback()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(spriteRenderer.material.DOFloat(0, "_Dissolve", duration));
            if (DeathCallback != null)
            {
                // when the shader finishes, then destroy the GameObject
                sequence.AppendCallback(() => DeathCallback.Invoke());
            }
        }
    }
}