using UnityEngine.SceneManagement;
using UnityEngine;



public class gotut : MonoBehaviour
{
    public string tut = "tut"; // 目标场景名称

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 按下空格键
        {
            SceneManager.LoadScene(tut); // 加载指定场景
        }
    }
}
