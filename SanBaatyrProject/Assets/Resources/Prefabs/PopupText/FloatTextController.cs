using UnityEngine;

namespace GUI.PopupText
{
    public class FloatTextController : MonoBehaviour
    {
        private static FloatingText _popupText;
        private static GameObject _canvas;

        public static void Initialize()
        {
//            _canvas = GameObject.FindWithTag("Canvas");
            if (!_popupText)
                _popupText = Resources.Load<FloatingText>("Prefabs/PopupText/PopupText");
        }

        public static void CreateFloatText(string text, Color color, Vector2 location)
        {
            FloatingText instance = Instantiate(_popupText);
            Vector2 newPosition =   new Vector2(location.x + Random.Range(-1f, 1f), location.y + Random.Range(-1f, 1f)); 
            instance.transform.position = newPosition;
            instance.SetText(text, color);
        }
    }
}
