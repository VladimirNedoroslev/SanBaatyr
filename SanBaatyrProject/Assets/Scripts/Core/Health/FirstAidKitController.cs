using System;
using Core.Player;
using Core.Utilities;
using UnityEngine;

namespace Core.Health
{
    public class FirstAidKitController : MonoBehaviour
    {
        [SerializeField] private int healPoints = 10;

        public static event Action<int> PlayerHealed;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.IsPlayer())
            {
                other.GetComponent<PlayerController>().health.Heal(healPoints);
                OnPlayerHealed(healPoints);
                Destroy(gameObject);
            }
        }

        protected virtual void OnPlayerHealed(int damage)
        {
            PlayerHealed?.Invoke(damage);
        }
    }
}