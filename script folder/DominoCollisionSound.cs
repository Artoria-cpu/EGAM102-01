using UnityEngine;

public class DominoCollisionSound : MonoBehaviour
{
    public AudioClip collisionSound;
    private AudioSource audioSource;
    public AudioClip dingclip;
    public AudioSource dingSource;

    void Start()
    {
        // 添加 AudioSource，如果没有的话
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;

        // 检查是否有 DominoCollisionReporter 或 DominoCollisionSound
        bool hitDomino = other.GetComponent<ChildCollisionReporter>() != null;
        bool hitSame = other.GetComponent<DominoCollisionSound>() != null;

        if (hitDomino || hitSame)
        {
           
            
                dingSource.clip = dingclip;
                dingSource.Play();
                Debug.Log("🔊 播放碰撞音效：" + gameObject.name + " 碰到了 " + other.name);
            
        }
    }
}

