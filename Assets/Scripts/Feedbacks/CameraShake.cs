using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cory.RL_Crawler.Feedbacks
{
    public class CameraShake : Feedback
    {
        [Header("Cinemachine Virtual Camera to shake")]
        [SerializeField] private CinemachineVirtualCamera vCamera = null;

        [Header("Camera Shake Settings")]
        [SerializeField] [Range(0, 5)] private float amplitude = 1f;
        [SerializeField] [Range(0, 5)] private float intensity = 1f;
        [SerializeField] [Range(0, 1)] private float duration = 0.1f;

        private CinemachineBasicMultiChannelPerlin perlinNoise;

        private void Start()
        {
            if (vCamera == null)
            {
                vCamera = FindObjectOfType<CinemachineVirtualCamera>();
                perlinNoise = vCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            }
        }

        public override void CompletePreviousFeedback()
        {
            StopAllCoroutines();
            perlinNoise.m_AmplitudeGain = 0;
        }

        public override void CreateFeedback()
        {
            perlinNoise.m_AmplitudeGain = amplitude;
            perlinNoise.m_FrequencyGain = intensity;
            StartCoroutine(ShakeCoroutine());
        }

        IEnumerator ShakeCoroutine()
        {
            // Decrease across the Time
            for (float i = duration; i > 0; i -= Time.deltaTime)
            {
                // shake at max then decrease down to 0
                perlinNoise.m_AmplitudeGain = Mathf.Lerp(0, amplitude, i / duration);
                yield return null;
            }

            perlinNoise.m_AmplitudeGain = 0;
        }
    }
}