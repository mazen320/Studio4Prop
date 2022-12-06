using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    
    static public GameObject playerHUD { get; private set; }
    static PlayerController playerController;
    static Movement propController;
    static public Image textbox { get; private set; }
    static TextMeshProUGUI displayName;
    static TextMeshProUGUI displayText; // make sure these are parented to the obj with the script

    static Image portraitBox;
    
    

    public static bool dialogueActive {  get; private set; }

    static List<string> currentDialogueText = new List<string>(20);
    static List<AudioClip> currentDialogueAudio = new List<AudioClip>(20);
    static AudioSource audioSource;

    static int index = -1;


    static DialogueHandler handler;


    void Start(){

        if (handler == null)
            handler = this;
        else
            Destroy(this);

        audioSource = GetComponent<AudioSource>();

        GameObject textboxObj = transform.GetChild(0).gameObject;
        textbox = textboxObj.GetComponent<Image>();
        displayText = textboxObj.GetComponentInChildren<TextMeshProUGUI>();
        portraitBox = textboxObj.transform.GetChild(1).gameObject.GetComponent<Image>();


        playerController = GameObject.Find("Hunter").GetComponent<PlayerController>();
        playerHUD = GameObject.Find("UI Canvas");


        displayText.text = "";
        textbox.gameObject.SetActive(false);
        dialogueActive = false;

    }


    void Update(){
        
        if (dialogueActive && Input.GetKeyDown(KeyCode.C))
        {
            DisplayNextLine();
            //Debug.Log(dialogueActive);
        }
    }


    public static void StartDialogueDisplay(string[] dialogue, AudioClip[] audio){

        dialogueActive = true;
        // freeze the game, disable player movement
        playerController.enabled = false;
        playerHUD.SetActive(false);

        // make textbox appear
        textbox.gameObject.SetActive(true);


        currentDialogueText.Clear();
        currentDialogueText.AddRange(dialogue); // empty list from previous dialogue, add dialogue to be displayed

        currentDialogueAudio.Clear();
        currentDialogueAudio.AddRange(audio); // add respective audio


        index = -1;

    }

    void DisplayNextLine() {


        index++;
        //audioSource.Stop();

        if (index >= currentDialogueText.Count) // if list is empty, resume game
        {
            dialogueActive = false;
            playerController.enabled = true;
            playerHUD.SetActive(true);

            displayText.text = "";
            textbox.gameObject.SetActive(false);


            return;
        }
        else
        {

            if (currentDialogueText[index].StartsWith("[Hunter]"))
            {
                currentDialogueText[index] = currentDialogueText[index].Remove(0, 8);
               
            }
            if (currentDialogueText[index].StartsWith("[Prop]"))
            {
                currentDialogueText[index] = currentDialogueText[index].Remove(0, 6);
            }


            displayText.text = currentDialogueText[index]; // display text in the list at current index.

        }

        //audioSource.clip = currentDialogueAudio[index];
        //audioSource.Play();

    }

}
