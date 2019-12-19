using Core.Player;
using UnityEngine;

namespace Core.Health
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Transform barTransform;


        private void FixedUpdate()
        {
            if (PlayerController.Instance.currentHealth <= 0)
            {
                gameObject.SetActive(false);
            }

            SetSize(PlayerController.Instance.currentHealth * 0.01f);
        }

        private void SetSize(float sizeNormalized)
        {
            barTransform.localScale = new Vector2(sizeNormalized, 1f);
        }
    }
}