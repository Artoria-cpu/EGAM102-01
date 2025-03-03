using UnityEngine;

public class BridgeManager : MonoBehaviour
{
    public static BridgeManager Instance;
    public GameObject bridge1; 
    public GameObject bridge2; 
    public GameObject bridge3; 
    public GameObject bridge4; 

    private void Awake()
    {
        Instance = this;
    }

    public bool IsBridgeActive(int step)
    {
        if (step == 3) return bridge1.activeSelf || bridge3.activeSelf;
        if (step == 6) return bridge2.activeSelf || bridge4.activeSelf;
        return true; 
    }

    public void ActivateBridge(int bridgeIndex)
    {
        bridge1.SetActive(false);
        bridge2.SetActive(false);
        bridge3.SetActive(false);
        bridge4.SetActive(false);

        if (bridgeIndex == 1) bridge1.SetActive(true);
        else if (bridgeIndex == 2) bridge2.SetActive(true);
        else if (bridgeIndex == 3) bridge3.SetActive(true);
        else if (bridgeIndex == 4) bridge4.SetActive(true);
    }
}
