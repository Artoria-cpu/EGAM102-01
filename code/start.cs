using UnityEngine.SceneManagement;
using UnityEngine;



public class start : MonoBehaviour
{
    public string game = "game"; // 目标场景名称

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 按下空格键
        {
            SceneManager.LoadScene(game); // 加载指定场景
        }
    }
}
