using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Metrics : MonoBehaviour
{
    void CreateText()
    {
        string path = Application.dataPath + "/Log.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Player time Log \n\n");
        }
        string content = "Login date:" + System.DateTime.Now + "\n";
        File.AppendAllText(path, content);
    }

    
    // Start is called before the first frame update
    void Start()
    {
        CreateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
