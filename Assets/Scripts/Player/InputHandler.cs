using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Player
{
    /// <summary>
    /// Gets Input keys for our Player
    /// </summary>
    public class InputHandler : MonoBehaviour
    {
        // Unity Events, sends out a <Vector2>
        // showing to the inspector with this attribute
        [field: SerializeField]
        public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

        private void Update()
        {
            GetMovementInput();
        }

        private void GetMovementInput()
        {
            // get values from the Input Manager
            OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}