using UnityEngine;

public class Anime : MonoBehaviour
{
    public GameObject image1Object; // 显示图片一的 GameObject
    public GameObject image2Object; // 显示图片二的 GameObject
    public float switchDuration = 1f; // 图片二显示的持续时间

    public AudioSource airsource;

    public AudioClip airSound;

    private bool isSwitching = false; // 是否正在切换

    void Start()
    {
        // 初始化显示图片一，隐藏图片二
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
        // 检查是否按下空格键
        if (Input.GetKeyDown(KeyCode.Space) && !isSwitching)
        {
            StartCoroutine(SwitchImage());
        }
    }

    System.Collections.IEnumerator SwitchImage()
    {
        isSwitching = true;

        // 切换到图片二，隐藏图片一
        if (image1Object != null && image2Object != null)
        {
            airsource.clip = airSound;
            airsource.Play();
            image1Object.SetActive(false);
            image2Object.SetActive(true);
        }

        // 等待指定的持续时间
        yield return new WaitForSeconds(switchDuration);

        // 切换回图片一，隐藏图片二
        if (image1Object != null && image2Object != null)
        {
            image1Object.SetActive(true);
            image2Object.SetActive(false);
        }

        isSwitching = false;
    }
}
