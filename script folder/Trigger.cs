using UnityEngine;

public class Trigger : MonoBehaviour
{
    public float forceAmount = 500f; 
    private Rigidbody rb; 
    private bool hasActivated = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.isKinematic = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !hasActivated)
        {
            rb.isKinematic = false; 
            Vector3 forceDirection = transform.TransformDirection(Vector3.left); 
            rb.AddForce(forceDirection * forceAmount, ForceMode.Impulse);
            hasActivated = true; 
        }
    }
}
