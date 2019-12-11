using Prefabs.Enemies;
using UnityEngine;
using UnityEngine.UI;

namespace Prefabs.Items.AntiVirus
{
    public class AntiVirusWave : MonoBehaviour
    {
        public Image cooldownEffect;
        
        public int damage;
        public float cooldownTime;

        private Animator _animator;
        private CircleCollider2D _circleCollider2D;

        private void Start()
        {
            _animator = gameObject.GetComponent<Animator>();
            _circleCollider2D = gameObject.GetComponent<CircleCollider2D>();
        }

        private float _lastActivationTime;
        private void Update()
        {
            if (Time.time < _lastActivationTime + cooldownTime)
            {
                cooldownEffect.fillAmount = (_lastActivationTime + cooldownTime) / Time.time;
            }
            else
            {
                enabled = false;
                cooldownEffect.gameObject.SetActive(false);
                cooldownEffect.fillAmount = 1;
            }
            
        }

        public void InitializeWave()
        {
            _animator.SetTrigger("StartWave");
            _circleCollider2D.enabled = true;
            _lastActivationTime = Time.time;
            cooldownEffect.gameObject.SetActive(true);
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
