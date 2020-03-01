using System;

namespace Core.Health
{
    [Serializable]
    public class BaseHealthBehavior
    {
        public int maxHealth;
        public int currentHealth;

        public BaseHealthBehavior(int currentHealth, int maxHealth)
        {
            this.currentHealth = currentHealth;
            this.maxHealth = maxHealth;
        }

        public BaseHealthBehavior()
        {
        }

        public virtual void GetDamage(int damage)
        {
            if (damage > currentHealth)
            {
                currentHealth = 0;
            }
            else
            {
                currentHealth -= damage;
            }
        }

        public virtual void Heal(int healPoints)
        {
            if (currentHealth + healPoints > maxHealth)
            {
                currentHealth = maxHealth;
            }
            else
            {
                currentHealth += healPoints;
            }
        }

        public virtual bool IsDead()
        {
            return currentHealth <= 0;
        }

        public virtual void Restore()
        {
            currentHealth = maxHealth;
        }

        public virtual void Kill()
        {
            currentHealth = 0;
        }
    }
}