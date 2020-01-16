namespace Core.Health
{
    public class BaseHealthBehavior
    {
        public int MaxHealth;
        public int CurrentHealth;

        public BaseHealthBehavior(int currentHealth, int maxHealth)
        {
            CurrentHealth = currentHealth;
            MaxHealth = maxHealth;
        }

        public virtual void GetDamage(int damage)
        {
            if (damage > CurrentHealth)
            {
                CurrentHealth = 0;
            }
            else
            {
                CurrentHealth -= damage;
            }
        }

        public virtual void Heal(int healPoints)
        {
            if (CurrentHealth + healPoints > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
            else
            {
                CurrentHealth += healPoints;
            }
        }

        public virtual bool IsDead()
        {
            return CurrentHealth <= 0;
        }

        public virtual void Restore()
        {
            CurrentHealth = MaxHealth;
        }

        public virtual void Kill()
        {
            CurrentHealth = 0;
        }
    }
}