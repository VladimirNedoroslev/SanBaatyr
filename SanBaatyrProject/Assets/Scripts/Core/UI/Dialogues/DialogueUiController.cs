using System;
using Core.Dialogues;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI.Dialogues
{
    public class DialogueUiController : MonoBehaviour
    {
        [SerializeField] private DialogueManager dialogueManager;

        public GameObject dialogueBox;
        public Image image;
        public TextMeshProUGUI Name;
        public TextMeshProUGUI text;


        private void Awake()
        {
            dialogueManager.DialogueStart += StartDialogue;
            dialogueManager.DialogueEnd += EndDialogue;
            dialogueManager.PhraseChange += DisplayPhrase;
            dialogueManager.SpeechChange += DisplayTitleAndImage;
            gameObject.SetActive(false);
        }

        public void NextSentence()
        {
            dialogueManager.NextPhrase();
        }

        public void StartDialogue()
        {
            Debug.Log("Im active!");
            dialogueBox.SetActive(true);
        }

        private void DisplayTitleAndImage(CharacterSpeech speech)
        {
            Debug.Log("Next title and image!");
            image.sprite = speech.Image;
            Name.text = speech.Name;
        }

        private void DisplayPhrase(string phrase)
        {
            Debug.Log("Next phrase!");
            text.text = phrase;
        }

        private void EndDialogue()
        {
            dialogueBox.SetActive(false);
        }
    }
}