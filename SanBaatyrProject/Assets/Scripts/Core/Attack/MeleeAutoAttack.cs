using Core.Health;
using UnityEngine;

namespace Core.Attack
{
    public class MeleeAutoAttack : MonoBehaviour
    {
        private Animator _animator;

        public Transform attackPoint;
        public LayerMask enemyLayers;

        public float detectRange;
        public float attackRange;

        public int attackDamage;
        public float attackRate;

        private float nextAttackTime = 0f;
        private Collider2D[] hitEnemys;

        // Update is called once per frame
        void Update()
        {
            if (Time.time >= nextAttackTime)
            {
                if (EnemyDetected())
                {
                    Attack();
                    nextAttackTime = Time.time + 1f / attackRate;
                }
            }
        }

        bool EnemyDetected()
        {
            hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            if (hitEnemys.Length == 0)
                return false;
            else
                return true;
        }

        void Attack()
        {
            _animator.SetTrigger("Attack");

            foreach (Collider2D enemy in hitEnemys)
            {
                enemy.GetComponent<BaseHealthBehavior>().GetDamage(attackDamage);
            }
        }

        private void OnDrawGizmos()
        {
            if (attackPoint == null)
                return;

            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
            Gizmos.DrawWireSphere(attackPoint.position, detectRange);
        }
    }
}