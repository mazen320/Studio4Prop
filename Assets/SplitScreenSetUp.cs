using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitScreenSetUp : MonoBehaviour
{
    
    public GameObject prop;
    public GameObject hunter;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace)) 
        {
           prop.GetComponent<Movement>().enabled = false;
        hunter.GetComponent<PlayerMovement>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Equals))
        {
            prop.GetComponent<Movement>().enabled = true;
            hunter.GetComponent<PlayerMovement>().enabled = false;
        }
    }

}
