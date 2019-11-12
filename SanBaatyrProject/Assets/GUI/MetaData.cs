using GUI.PopupText;
using UnityEngine;

public class MetaData : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        FloatTextController.Initialize();
        Destroy(gameObject);
    }

}