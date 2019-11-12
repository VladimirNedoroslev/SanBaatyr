using System;
using Prefabs.Enemies;
using UnityEngine;

namespace GUI.AntiVirus
{
    public class AntiVirusWave : MonoBehaviour
    {
        public int damage;

        public void Start()
        {
            Destroy(gameObject, gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().DealDamage(damage);
            }
        }
    }
}
