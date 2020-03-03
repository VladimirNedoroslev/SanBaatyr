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
        private BaseHealthBehavior _playerHealth;
        private float _normalizedHealthMultiplier;

        private void Start()
        {
            _playerHealth = player.GetComponent<PlayerController>().health;
        }

        private void FixedUpdate()
        {
            if (_playerHealth.IsDead())
            {
                gameObject.SetActive(false);
            }
            else
            {
                SetSize((float)_playerHealth.currentHealth / _playerHealth.maxHealth);
            }
        }

        private void SetSize(float sizeNormalized)
        {
            healthBarTransform.localScale = new Vector2(sizeNormalized, 1f);
        }
    }
}