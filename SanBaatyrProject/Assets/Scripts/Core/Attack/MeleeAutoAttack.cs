using System;
using Core.Health;
using UnityEngine;

namespace Core.Attack
{
    public class MeleeAutoAttack : MonoBehaviour
    {
        private Animator _animator;
        private Transform _transform;
        
        public float detectRange;
        public float attackRange;

        public int Damage;
        public float AttackSpeed;
        
        private float _lastAttackTime;
        private Collider2D[] _targets;
        
        private static readonly int AttackAnimation = Animator.StringToHash("Attack");

        private void Start()
        {
            _lastAttackTime = int.MinValue;
            _transform = gameObject.transform;
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
            return Time.time >= _lastAttackTime + AttackSpeed;
        }

        bool HaveTargetsToAttack()
        {
            _targets = Physics2D.OverlapCircleAll(_transform.position, attackRange);
            return _targets.Length > 0;
        }

        void Attack()
        {
            _animator.SetTrigger(AttackAnimation);
            foreach (var target in _targets)
            {
                var targetHealth = target.GetComponent<BaseHealthBehavior>();
                targetHealth.GetDamage(Damage);
            }
            _lastAttackTime = Time.time;
        }

    }
}