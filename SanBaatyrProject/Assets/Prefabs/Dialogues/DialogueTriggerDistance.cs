using System;
using UnityEngine;

namespace Prefabs.Dialogues
{
    public class DialogueTriggerDistance : MonoBehaviour
    {
        public GameObject targetOne;
        public GameObject targetTwo;
        public Dialogue dialogue;
        public float distance;

        public void StartDialogue()
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }

        private void Update()
        {
            if (getDistance() <= distance)
            {
                StartDialogue();

                gameObject.SetActive(false);
            }
        }

        private float getDistance()
        {
            float x = targetOne.transform.position.x - targetTwo.transform.position.x;
            float y = targetOne.transform.position.y - targetTwo.transform.position.y;

            float dist = (float) Math.Sqrt(x * x + y * y);

            return dist;
        }
    }
}