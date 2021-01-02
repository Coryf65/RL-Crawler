using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Interfaces
{
    public interface IEntity
    {
        int Health { get; }
        UnityEvent OnDeath { get; set; }
        UnityEvent OnGetHit { get; set; }
    }
}