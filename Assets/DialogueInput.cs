using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInput : MonoBehaviour
{
    [SerializeField] string NPCName;
    [SerializeField] string[] dialogue;
    [SerializeField] AudioClip[] dialogueAudio;
    public GameObject Message;

    bool inRange;


    void Update(){

        if (inRange && !DialogueHandler.dialogueActive && Input.GetKeyDown(KeyCode.Space))
        {
            DialogueHandler.StartDialogueDisplay(dialogue, dialogueAudio);
            Message.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Hunter"))
            inRange = true;

        if (other.gameObject.tag == "Hunter")
        {
            Message.SetActive(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hunter"))
            inRange = false;

        if (other.gameObject.tag == "Hunter")
        {
            Message.SetActive(false);
        }
    }
}
