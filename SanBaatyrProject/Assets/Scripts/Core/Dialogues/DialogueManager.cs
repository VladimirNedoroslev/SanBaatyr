using System.Collections.Generic;
using UnityEngine;

namespace Core.Dialogues
{
    public class DialogueManager : MonoBehaviour
    {

        private Queue<CharacterSpeech> _speeches;
        private Queue<string> _phrases;

        public delegate void SpeechChangeEvent(CharacterSpeech characterSpeech);
        public event SpeechChangeEvent SpeechChange;

        public delegate void PhraseChangeEvent(string nextPhrase);
        public event PhraseChangeEvent PhraseChange;

        public delegate void DialogueActivationEvent();
        public event DialogueActivationEvent DialogueEnd;
        public event DialogueActivationEvent DialogueStart;
        
        public bool isDialogueActive = false;

        public void StartDialogue(List<CharacterSpeech> dialogue)
        {
            isDialogueActive = true;
//            Time.timeScale = 0f;
            OnDialogueStart();
            _speeches = new Queue<CharacterSpeech>(dialogue);
            OnSpeechChange(_speeches.Dequeue());
        }

        public void NextPhrase()
        {
            if (_phrases.Count != 0)
            {
                OnPhraseChange(_phrases.Dequeue());
            }
            else if (_speeches.Count != 0)
            {
                OnSpeechChange(_speeches.Dequeue());
            }
            else
            {
                isDialogueActive = false;
                OnDialogueEnd();
            }
        }

        protected virtual void OnSpeechChange(CharacterSpeech characterSpeech)
        {
            _phrases = new Queue<string>(characterSpeech.Phrases);
            SpeechChange?.Invoke(characterSpeech);
            OnPhraseChange(_phrases.Dequeue());
        }

        protected virtual void OnPhraseChange(string nextPhrase)
        {
            PhraseChange?.Invoke(nextPhrase);
        }

        protected virtual void OnDialogueEnd()
        {
            Time.timeScale = 1f;
            DialogueEnd?.Invoke();
        }

        protected virtual void OnDialogueStart()
        {
            Debug.Log("Started dialogue");
            DialogueStart?.Invoke();
        }
    }
}