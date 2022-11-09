using UnityEngine;
using System.Collections;

public class StrictSound : MonoBehaviour
{
    [SerializeField] private AudioSource myAudio;
    [SerializeField] float delay = 5f;

    IEnumerator Start()
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (myAudio != null)
        {
            yield return wait;
            myAudio.Play();
        }
    }
}
