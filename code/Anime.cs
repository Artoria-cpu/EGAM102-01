using UnityEngine;

public class Anime : MonoBehaviour
{
    public GameObject image1Object; // ��ʾͼƬһ�� GameObject
    public GameObject image2Object; // ��ʾͼƬ���� GameObject
    public float switchDuration = 1f; // ͼƬ����ʾ�ĳ���ʱ��

    public AudioSource airsource;

    public AudioClip airSound;

    private bool isSwitching = false; // �Ƿ������л�

    void Start()
    {
        // ��ʼ����ʾͼƬһ������ͼƬ��
        if (image1Object != null && image2Object != null)
        {
            image1Object.SetActive(true);
            image2Object.SetActive(false);
        }
        else
        {
            Debug.LogError("Image1Object or Image2Object is not set!");
        }
    }

    void Update()
    {
        // ����Ƿ��¿ո��
        if (Input.GetKeyDown(KeyCode.Space) && !isSwitching)
        {
            StartCoroutine(SwitchImage());
        }
    }

    System.Collections.IEnumerator SwitchImage()
    {
        isSwitching = true;

        // �л���ͼƬ��������ͼƬһ
        if (image1Object != null && image2Object != null)
        {
            airsource.clip = airSound;
            airsource.Play();
            image1Object.SetActive(false);
            image2Object.SetActive(true);
        }

        // �ȴ�ָ���ĳ���ʱ��
        yield return new WaitForSeconds(switchDuration);

        // �л���ͼƬһ������ͼƬ��
        if (image1Object != null && image2Object != null)
        {
            image1Object.SetActive(true);
            image2Object.SetActive(false);
        }

        isSwitching = false;
    }
}
