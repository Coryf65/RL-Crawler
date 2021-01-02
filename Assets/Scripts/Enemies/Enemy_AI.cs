using Cory.RL_Crawler.Players;
using Cory.RL_Crawler.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cory.RL_Crawler.AI;
using System;

namespace Cory.RL_Crawler.Enemies
{
    public class Enemy_AI : MonoBehaviour, IInputHandler
    {
        [field: SerializeField]
        public GameObject Target { get; set; }

        [field: SerializeField]
        public AI_State CurrentState { get; set; }

        [field: SerializeField]
        public UnityEvent<Vector2> OnMovementKeyPressed { get; set; }

        [field: SerializeField]
        public UnityEvent<Vector2> OnPointerPosisitonChanged { get; set; }

        [field: SerializeField]
        public UnityEvent OnShootButtonPressed { get; set; }

        [field: SerializeField]
        public UnityEvent OnShootButtonReleased { get; set; }

        private void Awake()
        {
            Target = FindObjectOfType<Player>().gameObject;
        }

        private void Update()
        {
            if (Target == null)
            {
                OnMovementKeyPressed?.Invoke(Vector2.zero);
            }
            CurrentState.UpdateState();
        }

        public void Attack()
        {
            OnShootButtonPressed?.Invoke();
        }

        public void Move(Vector2 movementDirection, Vector2 targetPosition)
        {
            OnMovementKeyPressed?.Invoke(movementDirection);
            OnPointerPosisitonChanged?.Invoke(targetPosition);
        }

        public void ChangeToState(AI_State state)
        {
            CurrentState = state;
        }
    }
}