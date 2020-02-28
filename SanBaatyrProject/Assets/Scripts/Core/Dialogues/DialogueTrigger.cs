using UnityEngine;

namespace Core.Dialogues
{
    public class DialogueTrigger : MonoBehaviour
    {
        [SerializeField] private DialogueManager dialogueManager;
        [SerializeField] private Dialogue dialogue;
        private float _lastActivationTime;

        public static readonly float DialogueCooldown = 5f;

        private void Start()
        {
            _lastActivationTime = int.MinValue;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (IsPlayer(other) && CanStartDialogue())
            {
                Debug.Log("START");
                dialogueManager.StartDialogue(dialogue);
                _lastActivationTime = Time.time;
            }
        }


        private bool IsPlayer(Collider2D player) => player.CompareTag("Player");
        private bool CanStartDialogue() => Time.time > _lastActivationTime + DialogueCooldown;
    }
}