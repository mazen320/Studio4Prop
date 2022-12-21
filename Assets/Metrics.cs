using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Metrics : MonoBehaviour
{
    public static float secondsCount;
    public static int minuteCount;
    private static int hourCount;
    public static void CreateText()
    {
        string path = Application.dataPath + "/Log.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Player time Log \n\n");
        }
        string content = "Login date:" + System.DateTime.Now + "\n" + "Player time" + secondsCount + "secs" + minuteCount + "mins" + hourCount + "hours" + "\n";
        File.AppendAllText(path, content);
    }

    public void OnApplicationQuit()
    {
        CreateText();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        secondsCount += Time.deltaTime;
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
}
