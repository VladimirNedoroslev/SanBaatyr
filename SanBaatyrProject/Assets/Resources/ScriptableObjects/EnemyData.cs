using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "New Enemy data")]
public class EnemyData : ScriptableObject
{
    public int maxHealth;
    public int damage;
    public float speed;
    public int visionDistance;
}
