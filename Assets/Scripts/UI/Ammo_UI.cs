using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Cory.RL_Crawler.UI
{
    public class Ammo_UI : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI ammoCountText = null;

        public void UpdateAmmoText(int ammoCount)
        {
            if (ammoCount == 0)
            {
                ammoCountText.color = Color.red;
            } else
            {
                ammoCountText.color = Color.white;
            }

            ammoCountText.SetText(ammoCount.ToString());
        }
    }
}