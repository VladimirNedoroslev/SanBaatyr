using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Prefabs.Dialogues
{
    public class DialogueManager : MonoBehaviour
    {
        public GameObject dialogueBox;

        private Queue<string> _sentences;
    
    
        void Start()
        {
            _sentences = new Queue<string>();
        }

        public void StartDialogue(Dialogue dialogue)
        {
            Time.timeScale = 0f;
        
            dialogueBox.gameObject.SetActive(true);

            dialogueBox.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = dialogue.name;
            dialogueBox.transform.Find("Image").GetComponent<Image>().sprite = dialogue.image;
            _sentences.Clear();
        
            foreach (string sentence in dialogue.sentences)
            {
                _sentences.Enqueue(sentence);
            }
        
            DisplayNextSentence();
        }

        public void DisplayNextSentence()
        {
            if (_sentences.Count == 0)
            {
                EndDialogue();
                return;
            }

            string sentence = _sentences.Dequeue();
            dialogueBox.transform.Find("Dialogue").GetComponent<TextMeshProUGUI>().text = sentence;
        }

        public void EndDialogue()
        {
            dialogueBox.gameObject.SetActive(false);
        
            Time.timeScale = 1f;
        }


    }
}
