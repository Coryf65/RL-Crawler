using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Controllers
{
    /// <summary>
    /// Gets Input keys for our Player
    /// </summary>
    public class InputHandler : MonoBehaviour
    {

        private Camera mainCamera;

        // Unity Events, sends out a <Vector2>
        // showing to the inspector with this attribute
        [field: SerializeField]  public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
        [field: SerializeField]  public UnityEvent<Vector2> OnPointerPosisitonChanged { get; set; }

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            GetMovementInput();
            GetPointerInput();
        }

        private void GetPointerInput()
        {
            // get our mouse position
            var mouseInWorldSpace = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            OnPointerPosisitonChanged?.Invoke(mouseInWorldSpace);
        }

        private void GetMovementInput()
        {
            // get values from the Input Manager
            OnMovementKeyPressed?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));
        }
    }
}