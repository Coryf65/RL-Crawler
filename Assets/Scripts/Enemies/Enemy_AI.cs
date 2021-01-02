using Cory.RL_Crawler.Players;
using Cory.RL_Crawler.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Enemies
{
    public class Enemy_AI : MonoBehaviour, IInputHandler
    {
        public GameObject Target { get; set; }

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
    }
}