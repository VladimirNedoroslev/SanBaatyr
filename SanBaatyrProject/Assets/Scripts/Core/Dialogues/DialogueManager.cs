using System;
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
        

        public void StartDialogue(Dialogue dialogue)
        {
            if (!dialogue.IsValid())
            {
                throw new ArgumentException($"Dialogue is not valid, please check {dialogue.Name} dialogue object!");
            }
            OnDialogueStart();
            _speeches = new Queue<CharacterSpeech>(dialogue.speeches);
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
            DialogueEnd?.Invoke();
        }

        protected virtual void OnDialogueStart()
        {
            DialogueStart?.Invoke();
        }
    }
}