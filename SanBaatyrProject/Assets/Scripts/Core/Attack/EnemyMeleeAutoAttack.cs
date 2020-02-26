using Core.Enemies;
using Core.Health;
using Core.Player;
using Core.Utilities;
using Pathfinding;
using UnityEngine;

namespace Core.Attack
{
    public class EnemyMeleeAutoAttack : MonoBehaviour
    {
        public int damage;
        public float attackSpeed;

        private Animator _animator;
        private Transform _transform;
        private float _lastAttackTime;

        private PlayerController _player;
        private Transform _playerTransform;
        private BaseHealthBehavior _playerHealth;
        private AIPath _aiPath;

        private static readonly float AttackRange = 1.5f;

        private void Start()
        {
            _lastAttackTime = int.MinValue;
            _transform = gameObject.transform;
            _animator = GetComponent<Animator>();

            _player = GetComponent<BaseVirusController>().player;
            _playerTransform = _player.GetComponent<Transform>();
            _playerHealth = _player.health;
            _aiPath = gameObject.GetComponent<AIPath>();
        }

        private void Update()
        {
            if (CanAttack() && IsPlayerInAttackRange())
            {
                StartAttackAnimation();
            }
        }

        private bool CanAttack()
        {
            return Time.time >= _lastAttackTime + attackSpeed;
        }

        private bool IsPlayerInAttackRange()
        {
            return Vector2.Distance(_playerTransform.position, _transform.position) < AttackRange;
        }

        void StartAttackAnimation()
        {
            _animator.SetTrigger(Animations.Attack);
            _aiPath.canMove = false;
            _lastAttackTime = Time.time;
        }

        void EndAttack()
        {
            if (IsPlayerInAttackRange())
            {
                _playerHealth.GetDamage(damage);
            }
            _aiPath.canMove = true;
        }
    }
}