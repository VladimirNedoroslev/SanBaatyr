using UnityEngine;

namespace Core.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewEnemyData", menuName = "New Enemy data")]
    public class EnemyData : ScriptableObject
    {
        public int maxHealth;
        public int damage;
        public float speed;
        public float attackSpeed;
        public int visionDistance;
    }
}