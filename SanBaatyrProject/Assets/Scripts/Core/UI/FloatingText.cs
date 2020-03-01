using System.Collections;
using Core.Extensions;
using Core.Interfaces;
using Core.Utilities;
using TMPro;
using UnityEngine;

namespace Core.UI
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

        private void SetText(string text, Color color)
        {
            _damageText.text = text;
            _damageText.color = color;
        }

        public bool ActivateOnSpawn => true;
        public void OnObjectSpawn()
        {
        }
        
        public static void InitializePopUpText(Transform transform, string text, Color color)
        {
            var popUpTextPosition = transform.position.Randomize();
            var popUpText =
                ObjectPooler.Instance.SpawnFromPool(ObjectPoolerTags.PopUpText, popUpTextPosition, Quaternion.identity);
            popUpText.GetComponent<FloatingText>().SetText(text, color);
        }
    }
}