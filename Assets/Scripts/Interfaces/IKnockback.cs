using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Interfaces
{
    public interface IKnockback
    {
        void Knockback(Vector2 direction, float power, float duration);
    }
}