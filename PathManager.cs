using UnityEngine;

public class PathManager : MonoBehaviour
{
    public static PathManager Instance;
    public Transform[] path1; 
    public Transform[] path2; 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
    }
}
