using UnityEngine.SceneManagement;
using UnityEngine;



public class start : MonoBehaviour
{
    public string game = "game"; // Ŀ�곡������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ���¿ո��
        {
            SceneManager.LoadScene(game); // ����ָ������
        }
    }
}
