using Interfaces;
using Pathfinding;
using Prefabs.Player;
using UnityEngine;

namespace Prefabs.Enemies
{
    public class EnemyTest : MonoBehaviour, IDamageable, IPooledObject
    {
        public EnemyData enemyData;
        public int currentHealth;


        private Animator _animator;
        private AIDestinationSetter _aiDestinationSetter;

        public void OnObjectSpawn()
        {
            currentHealth = enemyData.maxHealth;
            _aiDestinationSetter = gameObject.GetComponent<AIDestinationSetter>();
            _aiDestinationSetter.target = PlayerController.Instance.transform;
            gameObject.GetComponent<AIPath>().maxSpeed = enemyData.speed;
            _animator = gameObject.GetComponent<Animator>();
        }

        /// <summary>
        /// Deals damage to the enemy.
        /// </summary>
        /// <param name="damage">Amount of damage</param>
        public void DealDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
                gameObject.GetComponent<AIPath>().canMove = false;
                _animator.SetTrigger("Death");

            }
        }


        public float lastAttackTime;

        private float _attackCooldownTime = 1.0f;

        public void OnCollisionStay2D(Collision2D other)
        {
            if (Time.time > lastAttackTime && other.gameObject.CompareTag("Player"))
            {
                lastAttackTime = Time.time + _attackCooldownTime;
                _animator.SetTrigger("Attack");
                Attack();
            }
        }


        private void Attack()
        {
            PlayerController.Instance.DealDamage(enemyData.damage);
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}