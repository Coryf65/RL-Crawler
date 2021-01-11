using Cory.RL_Crawler.Controllers;
using Cory.RL_Crawler.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Players
{
    public class PlayerWeapon : WeaponController
    {
        [SerializeField] private Ammo_UI ammo_UI = null;

        public bool AmmoFull { get => weapon != null && weapon.AmmoFull; }

        private void Start()
        {
            if (weapon != null)
            {
                weapon.OnAmmoChanged.AddListener(ammo_UI.UpdateAmmoText); // when we change ammo it udates the ui
                ammo_UI.UpdateAmmoText(weapon.Ammo); // set on game start
            }
        }

        public void AddAmmo(int amount)
        {
            if (weapon != null)
            {
                weapon.Ammo += amount;
            }
        }
    }
}