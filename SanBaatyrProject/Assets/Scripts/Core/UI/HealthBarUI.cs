using Core.Health;
using Core.Player;
using UnityEngine;

namespace Core.UI
{
    // ReSharper disable once InconsistentNaming
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private Transform healthBarTransform;
        [SerializeField] private GameObject player;
        private BaseHealthBehavior _health;
        private float _normalizedHealthMultiplier;

        private void Start()
        {
            _health = player.GetComponent<PlayerController>().health;
        }

        private void FixedUpdate()
        {
            if (_health.IsDead())
            {
                gameObject.SetActive(false);
            }
            else
            {
                SetSize((float)_health.currentHealth / _health.maxHealth);
            }
        }

        private void SetSize(float sizeNormalized)
        {
            healthBarTransform.localScale = new Vector2(sizeNormalized, 1f);
        }
    }
}