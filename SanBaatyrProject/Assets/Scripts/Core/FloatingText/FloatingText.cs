using System.Collections;
using Core.Interfaces;
using TMPro;
using UnityEngine;

namespace Core.FloatingText
{
    public class FloatingText : MonoBehaviour, IPooledObject
    {
        private TextMeshPro _damageText;

        [SerializeField] private Animator animator;

        void OnEnable()
        {
            _damageText = animator.GetComponent<TextMeshPro>();
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
            StartCoroutine(DisableAfterAnimation(clipInfo.Length));
        }

        private IEnumerator DisableAfterAnimation(float animationDuration)
        {
            yield return new WaitForSeconds(animationDuration);
            gameObject.SetActive(false);
        }

        public void SetText(string text, Color color)
        {
            _damageText.text = text;
            _damageText.color = color;
        }

        public bool ActivateOnSpawn => true;
        public void OnObjectSpawn()
        {
        }
    }
}