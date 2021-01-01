using UnityEngine;
using UnityEngine.Events;

namespace Cory.RL_Crawler.Interfaces
{
    public interface IHittable
    {
        // a contract
        UnityEvent OnGetHit { get; set; }
        void GetHit(int damage, GameObject damageDealer);
    }
}