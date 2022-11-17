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
    
    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) 
        {
        prop.GetComponent<Movement>().enabled = false;
        hunter.GetComponent<PlayerController>().enabled = true;
        cheatingScreen.SetActive(true);
        propRB.isKinematic = true;
            propCamera.GetComponent<PropCameraControll>().enabled = false;
        }
      

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            prop.GetComponent<Movement>().enabled = true;
            hunter.GetComponent<PlayerController>().enabled = false;
            cheatingScreen.SetActive(false);
            propRB.isKinematic = false;
            propCamera.GetComponent<PropCameraControll>().enabled = true;
        }
    }

}
