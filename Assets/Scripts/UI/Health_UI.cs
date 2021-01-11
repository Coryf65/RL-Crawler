using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Cory.RL_Crawler.UI
{
    public class Health_UI : MonoBehaviour
    {
        [SerializeField] private GameObject heartPrefab = null;
        [SerializeField] private GameObject healthPanel = null;
        [SerializeField] private Sprite heartFull = null;
        [SerializeField] private Sprite heartEmpty = null;

        private int heartCount = 0;
        private List<Image> hearts = new List<Image>();

        public void Initialize(int livesCount)
        {
            heartCount = livesCount; // max number of lives

            foreach (Transform child in healthPanel.transform)
            {
                // remove all that are visible
                Destroy(child.gameObject);
            }

            for (int i = 0; i < livesCount; i++)
            {
                hearts.Add(Instantiate(heartPrefab, healthPanel.transform).GetComponent<Image>());
            }
        }

        public void UpdateUI(int health)
        {
            int currentIndex = 0;

            for (int i = 0; i < heartCount; i++)
            {
                if (currentIndex >= health)
                {
                    // more hearts than max
                    hearts[i].sprite = heartEmpty;
                } else
                {
                    hearts[i].sprite = heartFull;
                }
                currentIndex++;
            }
        }

    }
}