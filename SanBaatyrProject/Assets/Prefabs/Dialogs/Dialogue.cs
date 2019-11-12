using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{
    public Sprite image;
    
    public string name;
    
    [TextArea(3, 10)]
    public string[] sentences;
}
