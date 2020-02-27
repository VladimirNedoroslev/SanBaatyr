using System;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class CooldownEffect : MonoBehaviour
    {
        private Image image;

        private float startCooldownTime;
        private float endCooldownTime;

        private void Awake()
        {
            image = GetComponent<Image>();
        }

        private void Update()
        {
            if (Math.Abs(image.fillAmount) > 0.00001f && image.enabled)
            {
                image.fillAmount = 1f - GetNormalizedCooldownTime();
            }
            else
            {
                image.enabled = false;
                image.fillAmount = 1;
            }
        }

        private float GetNormalizedCooldownTime()
        {
            return (Time.time - startCooldownTime) / (endCooldownTime - startCooldownTime);
        }

        public void StartCooldownAnimation(float cooldownTime)
        {
            startCooldownTime = Time.time;
            endCooldownTime = startCooldownTime + cooldownTime;
            image.enabled = true;
        }
    }
}