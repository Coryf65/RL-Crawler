using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class RendererHandler : MonoBehaviour
    {
        protected SpriteRenderer spriteRenderer;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void FaceDirection(Vector2 mouseInput)
        {
            var direction = (Vector3)mouseInput - transform.position;
            // if z is - then right, else z+ = left
            var result = Vector3.Cross(Vector2.up, direction);

            if (result.z > 0)
            {
                spriteRenderer.flipX = true;
            } else if (result.z < 0) {
                spriteRenderer.flipX = false;
            }
        }
    }
}