using UnityEngine;

namespace Cory.RL_Crawler.Player
{
    // using an attribute to require a RigidBody2D
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovementHandler : MonoBehaviour
    {

        protected Rigidbody2D rigidbody2D;
        [SerializeField] protected float speed;

        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void MovePlayer(Vector2 movementInput)
        {
            // a simple movement
            rigidbody2D.velocity = movementInput.normalized * speed;
        }
    }
}