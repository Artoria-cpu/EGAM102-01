using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public float zoomSpeed = 10f; 
    public float minFov = 20f; 
    public float maxFov = 60f; 

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel"); 
        if (scroll != 0)
        {
            Camera.main.fieldOfView -= scroll * zoomSpeed;
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, minFov, maxFov);
        }
    }
}
