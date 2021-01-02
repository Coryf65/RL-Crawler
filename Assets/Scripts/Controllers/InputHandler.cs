using Cory.RL_Crawler.Interfaces;
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
    public class InputHandler : MonoBehaviour, IInputHandler
    {

        private Camera mainCamera;
        private bool shootButtonDown;

        // Unity Events, sends out a <Vector2>
        // showing to the inspector with this attribute
        [field: SerializeField] public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }
        [field: SerializeField] public UnityEvent<Vector2> OnPointerPosisitonChanged { get; set; }
        [field: SerializeField] public UnityEvent OnShootButtonPressed { get; set; }
        [field: SerializeField] public UnityEvent OnShootButtonReleased { get; set; }

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        private void Update()
        {
            GetMovementInput();
            GetPointerInput();
            GetShootingInput();
        }

        private void GetShootingInput()
        {
            if (Input.GetAxisRaw("Fire1") > 0)
            {
                if (shootButtonDown == false)
                {
                    shootButtonDown = true;
                    OnShootButtonPressed?.Invoke();
                }
            }
            else
            {
                if (shootButtonDown == true)
                {
                    shootButtonDown = false;
                    OnShootButtonReleased?.Invoke();
                }

            }
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