using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenSetUp : MonoBehaviour
{

    public GameObject prop;
    public GameObject hunter;
    public GameObject cheatingScreen;
    public GameObject propCamera;

    public Rigidbody propRB;

    bool playingProp = false;
    bool playingHunter = false;

    void Start()
    {
        playingProp = true;
    }
    void Update()
    {
        if (playingProp)
        {

            prop.GetComponent<Movement>().enabled = true;
            hunter.GetComponent<PlayerController>().enabled = false;
            cheatingScreen.SetActive(false);
            propRB.isKinematic = false;
            propCamera.GetComponent<PropCameraControll>().enabled = true;
            playingHunter = false;

        }
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                playingProp = false;
                prop.GetComponent<Movement>().enabled = false;
                hunter.GetComponent<PlayerController>().enabled = true;
                cheatingScreen.SetActive(true);
                propRB.isKinematic = true;
                propCamera.GetComponent<PropCameraControll>().enabled = false;
                playingHunter = true;
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.Equals))
                {
                    playingProp = true;
                }
            }
        }
    }

}
