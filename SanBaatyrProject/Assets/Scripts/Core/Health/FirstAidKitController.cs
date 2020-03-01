using Core.Delegates;
using Core.Player;
using UnityEngine;

namespace Core.Health
{
    public class FirstAidKitController : MonoBehaviour
    {
        [SerializeField] private int healPoints = 10;

        public static event IntParameterDelegate PlayerHealed;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (IsPlayer(other))
            {
                other.GetComponent<PlayerController>().health.Heal(healPoints);
                OnPlayerHealed(healPoints);
                Destroy(gameObject);
            }
        }

        private bool IsPlayer(Collider2D player) => player.CompareTag("Player");

        protected virtual void OnPlayerHealed(int damage)
        {
            PlayerHealed?.Invoke(damage);
        }
    }
}