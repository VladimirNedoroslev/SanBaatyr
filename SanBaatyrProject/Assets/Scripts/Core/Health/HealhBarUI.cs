using Core.Player;
using UnityEngine;

namespace Core.Health
{
    public class HealhBarUI : MonoBehaviour
    {
        [SerializeField] private Transform barTransform;


        private void FixedUpdate()
        {
            if (PlayerController.Instance.GetComponent<BaseHealthBehavior>().CurrentHealth <= 0)
            {
                gameObject.SetActive(false);
            }

            SetSize(PlayerController.Instance.GetComponent<BaseHealthBehavior>().CurrentHealth * 0.01f);
        }

        private void SetSize(float sizeNormalized)
        {
            barTransform.localScale = new Vector2(sizeNormalized, 1f);
        }
    }
}