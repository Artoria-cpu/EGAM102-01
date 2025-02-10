 using UnityEngine.SceneManagement;
using UnityEngine;



public class restart : MonoBehaviour
{
    public string start = "start";
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene(start);
    }
}

