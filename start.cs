using UnityEngine.SceneManagement;
using UnityEngine;



public class start : MonoBehaviour
{
    public string level1 = "level1";
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            SceneManager.LoadScene(level1);
    }
}