using System;
using Core.Interfaces;
using Core.Player;
using Core.Managers;
using Interfaces;
using Pathfinding;
using Resources.ScriptableObjects;
using UnityEngine;

namespace Core.Enemies
{
    public class Enemy : MonoBehaviour, IHealth, IPooledObject
    {
        public EnemyData enemyData;

        private Animator _animator;
        private AIDestinationSetter _aiDestinationSetter;
        private float _attackCooldownTime = 1.0f;

        public void Start()
        {
            OnObjectSpawn();
        }

        public void OnObjectSpawn()
        {
            gameObject.GetComponent<Managers.Health>().maxHealth = enemyData.maxHealth;
            gameObject.GetComponent<Managers.Health>().Restore();
            _aiDestinationSetter = gameObject.GetComponent<AIDestinationSetter>();
            _aiDestinationSetter.target = PlayerController.Instance.transform;
            gameObject.GetComponent<AIPath>().maxSpeed = enemyData.speed;
            _animator = gameObject.GetComponent<Animator>();
        }

        public void Die()
        {
            gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            gameObject.GetComponent<AIPath>().canMove = false;
            _animator.SetTrigger("Die");
        }

        public void Hit()
        {
            _animator.SetTrigger("Hit");
        }


        /*public void OnCollisionStay2D(Collision2D other)
        {
            if (Time.time > lastAttackTime && other.gameObject.CompareTag("Player"))
            {
                lastAttackTime = Time.time + _attackCooldownTime;
                _animator.SetTrigger("Attack");
                Attack();
            }
        }*/


        /*private void Attack()
        {
            PlayerController.Instance.DealDamage(enemyData.damage);
        }*/

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}