using System;
using System.Collections;
using System.Collections.Generic;
using Core.Enemies;
using UnityEngine;

namespace Core.Managers
{
    public class MeleeAutoAttack : MonoBehaviour
    {
        public Animator animator;

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
            animator.SetTrigger("Attack");

            //Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider2D enemy in hitEnemys)
            {
                enemy.GetComponent<Enemy>().DealDamage(attackDamage);
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