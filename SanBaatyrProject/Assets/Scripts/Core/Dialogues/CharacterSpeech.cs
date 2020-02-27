using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Dialogues
{
    [Serializable]
    public class CharacterSpeech
    {
        public Sprite Image;
        public string Name;
        [TextArea(3, 10)]
        public List<string> Phrases;
    }
}