using System;
using System.Linq;
using Core.Enemies;
using Core.Utilities;
using UnityEngine;

namespace Core.Attack
{
    public class PlayerMeleeAutoAttackBehavior : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        public float attackRange;
        public int damage;
        public float attackSpeed;

        private float _lastAttackTime;
        private Collider2D[] _targets;

        public event Action<int> EnemyAttack;

        private void Start()
        {
            _lastAttackTime = int.MinValue;

            _animator = gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            if (CanAttack() && HaveTargetsToAttack())
            {
                Attack();
            }
        }

        private bool CanAttack()
        {
            return Time.time >= _lastAttackTime + attackSpeed;
        }

        private bool HaveTargetsToAttack()
        {
            _targets = Physics2D.OverlapCircleAll(transform.position, attackRange);
            return _targets.Any(target => target.CompareTag("Enemy"));
        }

        void Attack()
        {
            _animator.SetTrigger(Animations.Attack);
            _lastAttackTime = Time.time;
        }

        void DealDamageToEnemies()
        {
            _targets = Physics2D.OverlapCircleAll(transform.position, attackRange);
            foreach (var target in _targets)
            {
                if (target.CompareTag("Enemy"))
                {
                    var enemy = target.GetComponent<BaseVirusController>();
                    enemy.GetComponent<Animator>().SetTrigger(Animations.GetHit);
                    enemy.health.GetDamage(damage);
                    OnEnemyAttack(damage);
                }
            }
        }

        protected virtual void OnEnemyAttack(int damage)
        {
            EnemyAttack?.Invoke(damage);
        }
    }
}