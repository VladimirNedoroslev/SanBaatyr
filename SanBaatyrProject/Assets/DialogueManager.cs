﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueBox;

    private Queue<string> sentences;
    
    
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        Time.timeScale = 0f;
        
        dialogueBox.gameObject.SetActive(true);

        dialogueBox.transform.Find("Name").GetComponent<TextMeshProUGUI>().text = dialogue.name;
        dialogueBox.transform.Find("Image").GetComponent<Image>().sprite = dialogue.image;
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueBox.transform.Find("Dialogue").GetComponent<TextMeshProUGUI>().text = sentence;
    }

    public void EndDialogue()
    {
        dialogueBox.gameObject.SetActive(false);
        
        Time.timeScale = 1f;
    }


}
