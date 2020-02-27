namespace Core.Health
{
    public interface IHealth
    {
        void GetDamage(int damage);

        void Heal(int healPoints);
        bool IsDead();
        void Restore();
        void Kill();
    }
}