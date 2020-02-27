using Core.Health;
using Core.Interfaces;
using Core.Player;
using Core.ScriptableObjects;
using Pathfinding;
using UnityEngine;

namespace Core.Enemies
{
    public class BaseVirusController : MonoBehaviour, IPooledObject
    {
        [SerializeField] public EnemyData enemyData;
        [SerializeField] public PlayerController player;
        public BaseHealthBehavior health;

        private void Start()
        {
            health = new BaseHealthBehavior(enemyData.maxHealth, enemyData.maxHealth);
            gameObject.GetComponent<AIPath>().maxSpeed = enemyData.speed;
            gameObject.GetComponent<AIDestinationSetter>().target = player.transform;
        }

        private void Update()
        {
            if (health.IsDead())
            {
                gameObject.SetActive(false);
            }
        }

        public bool ActivateOnSpawn => true;

        public void OnObjectSpawn()
        {
            player = PlayerController.Instance;
        }
    }
}