using System.Collections;
using System.Collections.Generic;
using Core.Interfaces;
using UnityEngine;

namespace Core.Managers
{
    public class Health : MonoBehaviour
    {
        public int maxHealth;
        public int currentHealth;

        void Start()
        {
            Restore();
        }

        public void TakeDamage(int damage)
        {
            IHealth health = (IHealth) gameObject.GetComponent(typeof(IHealth));
            
            currentHealth -= damage;
            //currentHealth = currentHealth < 0 ? 0 : currentHealth;

            if (isDead())
            {
                health.Die();
            }
            else
            {
                health.Hit();
            }
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