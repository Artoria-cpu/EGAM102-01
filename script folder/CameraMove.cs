using UnityEngine;

public class CameraMove : MonoBehaviour
{

    public float moveSpeed = 5f; 
    public float rotationSpeed = 30f; 

    void Update()
    {
        
        Vector3 currentRotation = transform.eulerAngles;

        if(Input.GetKey(KeyCode.W))
        {
            
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
            
            transform.position += transform.up * moveSpeed * Time.deltaTime;
            

            currentRotation.x -= rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            
            transform.position -= transform.forward * moveSpeed * Time.deltaTime;
            
            transform.position -= transform.up * moveSpeed * Time.deltaTime;
            
            currentRotation.x += rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * moveSpeed * Time.deltaTime; 
            currentRotation.y -= rotationSpeed * Time.deltaTime; 
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * moveSpeed * Time.deltaTime; 
            currentRotation.y += rotationSpeed * Time.deltaTime; 
        }

        
        currentRotation.x = Mathf.Clamp(currentRotation.x, -90f, 90f );

        transform.eulerAngles = currentRotation;
    }
}
