using UnityEngine;
using System.Collections;

public class StrictSound : MonoBehaviour
{
    [SerializeField] private AudioSource strictSound;
    [SerializeField] float delay = 5f;
    [SerializeField] private AudioSource OptionalAudio;

    IEnumerator Start()
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (strictSound != null)
        {
            yield return wait;
            strictSound.Play();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("M");
            OptionalAudio.Play();
        }
    }
}
