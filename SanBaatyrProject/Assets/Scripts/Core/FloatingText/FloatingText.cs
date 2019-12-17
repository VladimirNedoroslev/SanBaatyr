using TMPro;
using UnityEngine;

namespace Resources.PopupText
{
    public class FloatingText : MonoBehaviour
    {
        private TextMeshPro _damageText;

        [SerializeField] private Animator animator;

        void OnEnable()
        {
            AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
            Destroy(gameObject, clipInfo[0].clip.length);
            _damageText = animator.GetComponent<TextMeshPro>();
        }

        public void SetText(string text, Color color)
        {
            _damageText.text = text;
            _damageText.color = color;
        }
    }
}