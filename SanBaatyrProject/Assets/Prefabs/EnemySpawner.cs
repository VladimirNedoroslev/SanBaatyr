using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    ObjectPooler objectPooler;
    
    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Enemy", transform.position, Quaternion.identity);
    }
}
