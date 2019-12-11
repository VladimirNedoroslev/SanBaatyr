using System;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public Sprite image;
    
    public string name;
    
    [TextArea(3, 10)]
    public string[] sentences;
}
