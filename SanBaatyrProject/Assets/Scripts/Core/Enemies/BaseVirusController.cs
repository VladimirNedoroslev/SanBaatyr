using System;
using Core.Player;
using Core.Health;
using Core.ScriptableObjects;
using Interfaces;
using Pathfinding;
using UnityEngine;

namespace Core.Enemies
{
    public class BaseVirusController : MonoBehaviour, IPooledObject
    {
        public EnemyData enemyData;
        public BaseHealthBehavior health;
        public PlayerController player;

        private Animator _animator;
        private float _attackCooldownTime = 1.0f;

        public void Start()
        {
            health = new BaseHealthBehavior(enemyData.maxHealth, enemyData.maxHealth);
            OnObjectSpawn();
        }

        public void OnObjectSpawn()
        {
//            gameObject.GetComponent<AIPath>().maxSpeed = enemyData.speed;
            _animator = gameObject.GetComponent<Animator>();
        }

    }
}