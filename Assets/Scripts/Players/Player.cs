using Cory.RL_Crawler.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Players
{
    public class Player : MonoBehaviour, IEntity
    {
        public int Health { get; set; }
        public UnityEvent OnDeath { get; set; }
        public UnityEvent OnGetHit { get; set; }
    }
}