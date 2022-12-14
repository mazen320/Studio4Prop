using UnityEngine;

public class MophScript : MonoBehaviour
{
    public LayerMask mask;
    public float detectRange;
    public KeyCode morph;

    Camera cam;
    MeshRenderer renderer;
    MeshFilter filter;
    MeshCollider collider;
    public Transform modelTransform;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cam = Camera.main;
        renderer = GetComponentInChildren<MeshRenderer>();
        filter = GetComponentInChildren<MeshFilter>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(morph))
        {
            Debug.Log("husssein");
            RaycastHit hit;
            //checking what is hit withing certain layermask & range
            if (Physics.Raycast(transform.position, transform.forward, out hit, detectRange, mask))
            {
                //copy and replace the filter
                Debug.Log(hit.collider.gameObject.name);
                MeshFilter hitFilt = hit.collider.gameObject.GetComponent<MeshFilter>();
                filter.mesh = hitFilt.mesh;

                //copy and replace the renderer
                MeshRenderer hitRend = hit.collider.gameObject.GetComponent<MeshRenderer>();
                renderer.material = hitRend.material;

                //copy and replace the collider
                //MeshCollider hitCollider = hit.collider.gameObject.GetComponent<MeshCollider>();
                //collider.sharedMesh = hitCollider.sharedMesh;

                Transform trans = hit.transform.gameObject.GetComponent<Transform>();
                modelTransform.localScale = trans.localScale;
            }
        }
    }
}
