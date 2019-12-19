using System.Linq;
using Core.Enemies;
using Core.FloatingText;
using Interfaces;
using Prefabs.MetaObjects.GUIManager;
using UnityEngine;

namespace Core.Player
{
    public class PlayerController : Singleton<PlayerController>, IDamageable
    {
        public int maxHealth = 100;
        public float speed = 20;
        public int currentHealth = 100;
        public float attackRadius;
        public int baseDamageMin = 3;
        public int baseDamageMax = 10;

        public SpriteRenderer[] spriteGroup;

        private Animator _playerAnimator;
        public CircleCollider2D attackTriggerCircleCollider2D;

        public float attack1Time;
        public float attack2Time;

        private float attackCooldownTime = 1f;

        public void Start()
        {
            _playerAnimator = Instance.transform.GetComponentInChildren<Animator>();
            spriteGroup = gameObject.transform.GetComponentsInChildren<SpriteRenderer>(true);
            attackTriggerCircleCollider2D.radius = attackRadius;
            lastAttackTime = Time.time;
            InitializeAnimClipTimes();
        }

        private void InitializeAnimClipTimes()
        {
            var clips = _playerAnimator.runtimeAnimatorController.animationClips;
            foreach (var clip in clips)
            {
                switch (clip.name)
                {
                    case "Attack1":
                        attack1Time = clip.length;
                        break;
                    case "Attack2":
                        attack2Time = clip.length;
                        break;
                }
            }
        }

        public void Update()
        {
            _playerAnimator.SetFloat("MoveSpeed", speed * 0.1f);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, attackRadius / 2);
        }


        public int sortingOrder;
        public int sortingOrderOrigin;

        private float _updateTic;

        private void spriteOrder_Controller()
        {
            _updateTic += Time.deltaTime;

            if (_updateTic > 0.1f)
            {
                sortingOrder = Mathf.RoundToInt(gameObject.transform.position.y * 100);
                for (int i = 0; i < spriteGroup.Length; i++)
                {
                    spriteGroup[i].sortingOrder = sortingOrderOrigin - sortingOrder;
                }

                _updateTic = 0;
            }
        }

        private void Attack()
        {
            var enemiesColliders = Physics2D.OverlapCircleAll(gameObject.transform.position, attackRadius)
                .Where(enemyCollider => enemyCollider.CompareTag("Enemy")
                                        && enemyCollider.GetComponent<Enemy>().currentHealth >= 0);

            foreach (var enemyCollider in enemiesColliders)
            {
                var enemy = enemyCollider.GetComponent<Enemy>();
                Debug.Log(enemy.name);
                if (enemy != null)
                {
                    var damage = GetAttackDamage();

                    FloatTextController.CreateFloatText($"-{damage.ToString()}", Color.red,
                        enemyCollider.transform.position);
                    enemy.DealDamage(damage);
                }
            }
        }

        private int GetAttackDamage()
        {
            return Random.Range(baseDamageMin, baseDamageMax);
        }


        public float lastAttackTime;

        private void OnTriggerStay2D(Collider2D other)
        {
            if (Time.time > lastAttackTime && other.CompareTag("Enemy"))
            {
                lastAttackTime = Time.time + attackCooldownTime;
                _playerAnimator.SetTrigger("Attack");
                Attack();
            }
        }

        public void DealDamage(int damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                Time.timeScale = 0f;
                GUIManager.Instance.ShowGameOverScreen();
                _playerAnimator.SetTrigger("Death");
            }
        }
    }
}