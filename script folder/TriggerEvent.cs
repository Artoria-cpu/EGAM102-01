using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TriggerEvent : MonoBehaviour
{
    public GameObject panel; 
    public GameObject targetObject; 
    public string nextSceneName = "NextScene"; 
    private bool isTargetInside = false; 

    void Start()
    {
        if (panel != null)
        {
            panel.SetActive(false); 
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject) 
        {
            isTargetInside = true;
            if (panel != null)
            {
                panel.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == targetObject)
        {
            isTargetInside = false;
            if (panel != null)
            {
                panel.SetActive(false); 
            }
        }
    }

    public void LoadNextScene()
    {
        if (isTargetInside)
        {
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
