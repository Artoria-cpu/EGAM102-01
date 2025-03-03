using UnityEngine;

public class BridgePositionController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Vector3 position1 = new Vector3(1.92f, -3.3f, 0);
    public Vector3 position2 = new Vector3(-1.87f, -3.32f, 0);
    public Vector3 position3 = new Vector3(-1.87f, -0.45f, 0);
    public Vector3 position4 = new Vector3(1.92f, 0.53f, 0);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            transform.position = position1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            transform.position = position2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            transform.position = position3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            transform.position = position4;
        }
    }
}
