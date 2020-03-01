using UnityEngine;

namespace Core.Dialogues
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private DialogueManager dialogueManager;
        [SerializeField] private Dialogue dialogue;
        [SerializeField] private SpriteRenderer spriteRenderer;
        private float _lastActivationTime;
        private bool _hasBeenActivated;

        public float DialogueCooldown = 5f;

        private void Start()
        {
            dialogueManager.DialogueEnd += GreyOutTriggerSprite;
            _lastActivationTime = Time.time - DialogueCooldown;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (IsPlayer(other) && CanStartDialogue())
            {
                Debug.Log("START");
                dialogueManager.StartDialogue(dialogue);
                _lastActivationTime = Time.time;
                if (!_hasBeenActivated)
                {
                    _hasBeenActivated = true;
                    GreyOutTriggerSprite();
                }
            }
        }

        private void GreyOutTriggerSprite()
        {
            spriteRenderer.color = Color.gray;
        }


        private bool IsPlayer(Collider2D player) => player.CompareTag("Player");
        private bool CanStartDialogue() => Time.time > _lastActivationTime + DialogueCooldown;
    }
}