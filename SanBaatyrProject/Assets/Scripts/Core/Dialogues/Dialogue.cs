using System.Collections.Generic;
using UnityEngine;

namespace Core.Dialogues
{
    [CreateAssetMenu(menuName = "New dialogue", fileName ="NewDialogue")]
    public class Dialogue : ScriptableObject
    {
        public List<CharacterSpeech> speeches;
    }
}