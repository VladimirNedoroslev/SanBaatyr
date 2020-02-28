using System.Collections.Generic;
using UnityEngine;

namespace Core.Dialogues
{
    [CreateAssetMenu(menuName = "New dialogue", fileName ="NewDialogue")]
    public class Dialogue : ScriptableObject
    {
        public string Name;
        public List<CharacterSpeech> speeches;

        public bool IsValid()
        {
            foreach (var speech in speeches)
            {
                if (speech.Phrases.Count == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}