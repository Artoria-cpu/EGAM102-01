using UnityEngine.SceneManagement;
using UnityEngine;



public class restart : MonoBehaviour
{
    public string start = "start"; // Ŀ�곡������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ���¿ո��
        {
            SceneManager.LoadScene(start); // ����ָ������
        }
    }
}