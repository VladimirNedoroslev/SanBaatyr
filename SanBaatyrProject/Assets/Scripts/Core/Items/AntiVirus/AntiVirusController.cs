using System.Collections;
using Core.Enemies;
using Core.Interfaces;
using Core.Utilities;
using UnityEngine;

namespace Core.Items.AntiVirus
{
    public class AntiVirusController : MonoBehaviour, IPooledObject
    {
        public int damage;
        public float cooldownTime;

        private Animator _animator;

        private float _lastActivationTime = int.MinValue;


        private void Awake()
        {
            _animator = gameObject.GetComponent<Animator>();
            _lastActivationTime = int.MinValue;
        }

        public bool ActivateOnSpawn => false;

        public void OnObjectSpawn()
        {
            if (CanBeUsed())
            {
                gameObject.SetActive(true);
                _animator.SetTrigger(Animations.StartWave);
                _lastActivationTime = Time.time;
                StartCoroutine(DisableAfterAnimation());
            }
        }

        private IEnumerator DisableAfterAnimation()
        {
            var animatorClipInfo = _animator.GetCurrentAnimatorStateInfo(0);
            yield return new WaitForSeconds(animatorClipInfo.length);
            gameObject.SetActive(false);
        }

        private bool CanBeUsed()
        {
            return Time.time > _lastActivationTime + cooldownTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<BaseVirusController>().health.GetDamage(damage);
            }
        }
    }
}