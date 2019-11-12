using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isPlayer(other))
        {
            StartDialogue();
            
            gameObject.SetActive(false);
        }
    }

    public void StartDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private bool isPlayer(Collider2D player)
    {
        if (player.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
