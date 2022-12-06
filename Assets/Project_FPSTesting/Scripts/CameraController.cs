using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform target;

    float startFOV, targetFOV;

    public float zoomSpeed;

    public Camera thecam;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        startFOV = thecam.fieldOfView;
        targetFOV = startFOV;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.position; 
        transform.rotation = target.rotation;

        thecam.fieldOfView = Mathf.Lerp(thecam.fieldOfView, targetFOV, zoomSpeed * Time.deltaTime);
    }

    public void ZoomIn(float newZoom)
    {
        targetFOV = newZoom;
    }

    public void ZoomOut()
    {
        targetFOV = startFOV;
    }
}
