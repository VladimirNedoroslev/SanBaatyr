using System;
using UnityEngine;

namespace Core.Utilities
{
    [Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;

        public bool RelatedToUi;
    }
}