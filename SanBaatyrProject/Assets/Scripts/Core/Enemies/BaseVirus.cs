using System;
using Core.Player;
using Core.Health;
using Interfaces;
using Pathfinding;
using Resources.ScriptableObjects;
using UnityEngine;

namespace Core.Enemies
{
    public class BaseVirus : MonoBehaviour, IPooledObject
    {
        public EnemyData enemyData;
        public BaseHealthBehavior health;

        private Animator _animator;
        private AIDestinationSetter _aiDestinationSetter;
        private float _attackCooldownTime = 1.0f;

        public void Start()
        {
            InitializeHealthBehavior();
            OnObjectSpawn();
        }

        private void InitializeHealthBehavior()
        {
            health = new BaseHealthBehavior(enemyData.maxHealth, enemyData.maxHealth);
        }

        public void OnObjectSpawn()
        {
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

    }
}