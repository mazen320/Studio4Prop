using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphScript : MonoBehaviour
{
    public LayerMask mask;
    public float detectRange;
    public KeyCode morphKey;
    public float morphSpeed;

    Camera cam;
    MeshRenderer renderer;
    MeshFilter filter;
    BoxCollider collider;
    Transform modelTransform;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        renderer = GetComponentInChildren<MeshRenderer>();
        filter = GetComponentInChildren<MeshFilter>();
        collider = GetComponent<BoxCollider>();
        modelTransform = GetComponentInChildren<Transform>();
    }

    void Update()
    {
        if (Input.GetKeyDown(morphKey))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, detectRange, mask))
            {
                StartCoroutine(Morph(hit.collider.gameObject));
            }
        }
    }

    IEnumerator Morph(GameObject target)
    {
        // Calculate the initial and final scales for the player and target objects
        Vector3 initialScale = transform.localScale;
        Vector3 finalScale = Vector3.one * 3;

        // Calculate the lerp values for the morph
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime * morphSpeed;

            // Lerp the player's scale towards the target's scale
            transform.localScale = Vector3.Lerp(initialScale, finalScale, t);

            yield return null;
        }

        // Set the player's scale and the model transform's scale to the final scale
        transform.localScale = finalScale;
        modelTransform.localScale = finalScale;

        // Copy and replace the filter
        MeshFilter hitFilt = target.GetComponent<MeshFilter>();
        filter.mesh = hitFilt.mesh;

        // Copy and replace the renderer
        MeshRenderer hitRend = target.GetComponent<MeshRenderer>();
        renderer.material = hitRend.material;

        // Copy and replace the collider
        BoxCollider hitCollider = target.GetComponent<BoxCollider>();
        collider.size = hitCollider.size;

        // Copy and replace the transform
        Transform trans = target.GetComponent<Transform>();
    }
}