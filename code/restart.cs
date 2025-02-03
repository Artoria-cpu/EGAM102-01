using UnityEngine.SceneManagement;
using UnityEngine;



public class restart : MonoBehaviour
{
    public string start = "start"; // 目标场景名称

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 按下空格键
        {
            SceneManager.LoadScene(start); // 加载指定场景
        }
    }
}