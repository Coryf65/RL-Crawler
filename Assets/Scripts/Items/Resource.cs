using Cory.RL_Crawler.ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Items
{
    [RequireComponent(typeof(AudioSource))]
    public class Resource : MonoBehaviour
    {
        [field: SerializeField]
        public ResourceData_SO ResourceData { get; set; }

        AudioSource audioSource = null;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayPickupSound()
        {
            StartCoroutine(DestroyCoroutine());
        }

        IEnumerator DestroyCoroutine()
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length);
            Destroy(gameObject);
        }
    }
}