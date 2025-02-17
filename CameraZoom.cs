using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public Camera cam; 
    public float zoom = 2f; 
    public float min= 2f;   
    public float max = 15f; 

    void Update()
    {
        float scrollinput = Input.GetAxis("Mouse ScrollWheel"); 

        if (scrollinput != 0f)
        {
            cam.orthographicSize -= scrollinput * zoom; 
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, min, max); 
        }
    }
}