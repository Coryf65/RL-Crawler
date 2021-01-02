using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Weapons
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class WeaponRenderer : MonoBehaviour
    {
        [SerializeField] protected int playerSortingOrder = 0;
        protected SpriteRenderer weaponRenderer;

        private void Awake()
        {
            weaponRenderer = GetComponent<SpriteRenderer>();
        }

        public void FlipSprite(bool value)
        {
            weaponRenderer.flipY = value;
        }

        public void SortingOrder(bool value)
        {
            if (value)
            {
                weaponRenderer.sortingOrder = playerSortingOrder - 1;
            } else
            {
                weaponRenderer.sortingOrder = playerSortingOrder + 1;
            }
        }


    }
}