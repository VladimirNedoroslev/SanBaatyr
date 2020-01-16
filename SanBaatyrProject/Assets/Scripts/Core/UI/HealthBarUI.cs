using Core.Health;
using UnityEngine;

namespace Core.UI
{
    // ReSharper disable once InconsistentNaming
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private Transform healthBarTransform;
        private BaseHealthBehavior _health;
        private const float NormalizedHealthMultiplier = 0.01f;

        private void Start()
        {
            _health = gameObject.GetComponentInParent<BaseHealthBehavior>();
        }

        private void FixedUpdate()
        {
            if (_health.IsDead())
            {
                gameObject.SetActive(false);
            }
            else
            {
                SetSize(_health.CurrentHealth * NormalizedHealthMultiplier);
            }
        }

        private void SetSize(float sizeNormalized)
        {
            healthBarTransform.localScale = new Vector2(sizeNormalized, 1f);
        }
    }
}