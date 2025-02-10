using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Horizontal") * Time.deltaTime * 5f;
        float Y = Input.GetAxis("Vertical") * Time.deltaTime * 5f;
        transform.Translate(X, Y, 0);
    }
}
