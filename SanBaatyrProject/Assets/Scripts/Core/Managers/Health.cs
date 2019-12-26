using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Managers
{
    public class Health
    {
        public int maxHealth;
        private int currentHealth;

        void Start()
        {
            Restore();
        }

        public void TakeDamage(int damage)
        {
            currentHealth -= damage;
            currentHealth = currentHealth < 0 ? 0 : currentHealth;
        }

        public void Heal(int healthPoint)
        {
            currentHealth += healthPoint;
            currentHealth = currentHealth > maxHealth ? maxHealth : currentHealth;
        }

        public void Restore()
        {
            currentHealth = maxHealth;
        }

        public bool isDead()
        {
            return currentHealth <= 0 ? true : false;
        }
    }

}