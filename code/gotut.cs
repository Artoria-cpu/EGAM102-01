using UnityEngine.SceneManagement;
using UnityEngine;



public class gotut : MonoBehaviour
{
    public string tut = "tut"; // Ŀ�곡������

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // ���¿ո��
        {
            SceneManager.LoadScene(tut); // ����ָ������
        }
    }
}
