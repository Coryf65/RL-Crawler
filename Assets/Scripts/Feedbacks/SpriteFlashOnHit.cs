using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Feedbacks
{
    public class SpriteFlashOnHit : Feedback
    {

        [SerializeField] private SpriteRenderer spriteRenderer = null;
        [SerializeField] private float flashTime = 0.01f;
        [SerializeField] private Material flashMatrial = null;
        
        private Shader originalShader = null;


        private void Start()
        {
            originalShader = spriteRenderer.material.shader;
        }

        public override void CompletePreviousFeedback()
        {
            StopAllCoroutines();
            spriteRenderer.material.shader = originalShader;
        }

        public override void CreateFeedback()
        {
            if (spriteRenderer.material.HasProperty("MakeSolidColor") == false)
            {              
                spriteRenderer.material.shader = flashMatrial.shader;
            }
            spriteRenderer.material.SetInt("MakeSolidColor", 1);
            StartCoroutine(WaitBeforeReturningToOriginalShader());
        }

        IEnumerator WaitBeforeReturningToOriginalShader()
        {
            yield return new WaitForSeconds(flashTime);

            if (spriteRenderer.material.HasProperty("MakeSolidColor"))
            {
                spriteRenderer.material.SetInt("MakeSolidColor", 0);
            } else
            {
                spriteRenderer.material.shader = originalShader;
            }
        }
    }
}