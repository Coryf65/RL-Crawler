using Cory.RL_Crawler.ScriptableObjects;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Controllers
{
    // using an attribute to require a RigidBody2D
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementHandler : MonoBehaviour
    {

        protected Rigidbody2D rigidbody2D;

        // prop, keeps as prop but access through inspector
        [field: SerializeField] public MovementData_SO MovementData { get; set; }

        [SerializeField] protected float currentVelocity = 3f;
        protected Vector2 movementDirection;
        protected bool isKnockedback = false;

        // events
        [field: SerializeField] public UnityEvent<float> OnVelocityChanged { get; set; }

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void MovePlayer(Vector2 movementInput)
        {
            movementDirection = movementInput;

            currentVelocity = CalculateSpeed(movementInput);
        }

        /// <summary>
        ///  How fast the player will move
        /// </summary>
        /// <param name="movementInput">Input Horizontal and Vertical as a Vector2</param>
        /// <returns></returns>
        private float CalculateSpeed(Vector2 movementInput)
        {
            // if we are > 0 the we accelerate up to max velocity, otherwise deaccelerate
            if (movementInput.magnitude > 0)
            {
                // we are moving, speed up to max 
                currentVelocity += MovementData.acceleration * Time.deltaTime;
            } else
            {
                // slow down to stopped
                currentVelocity -= MovementData.deacceleration * Time.deltaTime;
            }

            return Mathf.Clamp(currentVelocity, 0, MovementData.maxSpeed);
        }

        private void FixedUpdate()
        {
            OnVelocityChanged?.Invoke(currentVelocity);

            if (!isKnockedback)
            {
                rigidbody2D.velocity = currentVelocity * movementDirection.normalized;
            }

        }

        public void StopMovement()
        {
            currentVelocity = 0;
            rigidbody2D.velocity = Vector2.zero;
        }

        public void Knockback(Vector2 direction, float power, float duration)
        {
            if (!isKnockedback)
            {
                isKnockedback = true;
                StartCoroutine(KnockbackCoroutine(direction, power, duration));
            }
        }

        public void ResetKnockback()
        {         
            StopCoroutine("KnockbackCoroutine");
            currentVelocity = 0;
            rigidbody2D.velocity = Vector2.zero;
            isKnockedback = false;
        }


        IEnumerator KnockbackCoroutine(Vector2 direction, float power, float duration) 
        {
            rigidbody2D.AddForce(direction.normalized * power, ForceMode2D.Impulse);
            
            yield return new WaitForSeconds(duration);
            
            currentVelocity = 0;
            rigidbody2D.velocity = Vector2.zero;
            isKnockedback = false;
        }
    }
}