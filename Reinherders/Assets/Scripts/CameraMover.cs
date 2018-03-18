using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    public InputController InputController;
    public float cameraSpeed = 1f;
    public float cameraHeightScale = 10f;
    public float smoothing = 5f;
    public float orthoScale = 5f;
    Vector3 movement;
    Vector3 zoomOffset;
    Vector3 camPosition;
    private void Start()
    {
        camPosition = transform.position - transform.forward * (InputController.zoomLevel * cameraHeightScale);
    }

    private void Update()
    {
        movement.Set(InputController.moveCameraHorizontal, 0f, InputController.moveCameraVertical);
        camPosition += Quaternion.AngleAxis(transform.rotation.eulerAngles[1], Vector3.up) * movement * cameraSpeed;
        Camera cam = this.GetComponent<Camera>();
        zoomOffset = transform.forward * (InputController.zoomLevel * cameraHeightScale);
        transform.position = Vector3.Lerp(transform.position, camPosition - zoomOffset, smoothing * Time.deltaTime);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, InputController.zoomLevel * orthoScale, smoothing * Time.deltaTime);
    }
}
