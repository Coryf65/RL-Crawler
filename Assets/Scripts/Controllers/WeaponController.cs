using Cory.RL_Crawler.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Controllers
{
    public class WeaponController : MonoBehaviour
    {

        [SerializeField] protected WeaponRenderer weaponRenderer;
        protected float aimAngle;

        private void Awake()
        {
            weaponRenderer = GetComponentInChildren<WeaponRenderer>();
        }

        public virtual void AimWeapon(Vector2 mousePosition)
        {
            var aimDirection = (Vector3)mousePosition - transform.position;
            aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

            AdjustWeaponRendering();
            
            // rotating the weapon
            transform.rotation = Quaternion.AngleAxis(aimAngle, Vector3.forward);
        }

        protected void AdjustWeaponRendering()
        {
            weaponRenderer?.FlipSprite(aimAngle > 90 || aimAngle < -90);
            weaponRenderer?.SortingOrder(aimAngle < 180 && aimAngle > 0);
        }
    }
}