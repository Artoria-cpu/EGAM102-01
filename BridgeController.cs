using UnityEngine;


public class BridgeController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            BridgeManager.Instance.ActivateBridge(1); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            BridgeManager.Instance.ActivateBridge(2); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            BridgeManager.Instance.ActivateBridge(3); 
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            BridgeManager.Instance.ActivateBridge(4); 
        }
    }
}
