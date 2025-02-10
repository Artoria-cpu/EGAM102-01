using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using System.Collections.Generic;

public class collide : MonoBehaviour
{
    public GameObject player; 
    public List<GameObject> enemies = new List<GameObject>(); 
    public float alert;
    public float increaseRate = 100f; 
    public float decreaseRate = 5f; 
    public RectTransform mRt;
    public chase ch;
    public float speed = 2f; 
    public List<GameObject> attack = new List<GameObject>(); 
    public bool yes;
    public GameObject red;
    public AudioSource bgm;
    public AudioClip bgms;
    public AudioClip jbs;
    public AudioSource jb;
    private void Start()
    {
        ch = GameObject.FindFirstObjectByType<chase>();
        red.gameObject.SetActive(false);
        yes = false;
        bgm.Play();
        

    }
    void Update()
    {
        foreach (GameObject enemy in enemies)//alert system
        {
            if (enemy != null && IsColliding(enemy, player))
            {
                alert += increaseRate * Time.deltaTime;
            }
            else
            {
                alert -= decreaseRate * Time.deltaTime;
            }
            alert = Mathf.Clamp(alert, 0f, 1.5f);
        }

        SetHp(70f);//hp bar

        if (alert >= 1.4)// enemyawake
        {
            yes = true;
            jb.Play();
        }

        if (yes == true)
        {
            bgm.Stop();
            
            red.gameObject.SetActive(true);

            
            
            foreach (GameObject enemy in attack)
            {
                
                if (enemy != null && player != null)
                {
                    Vector3 direction = (player.transform.position - enemy.transform.position).normalized;
                    enemy.transform.position += direction * speed * Time.deltaTime;
                }
            }
        }


    }

    bool IsColliding(GameObject obj1, GameObject obj2)//findplayer
    {
        if (obj1 == null || obj2 == null) return false;

        Collider2D col1 = obj1.GetComponent<Collider2D>();
        Collider2D col2 = obj2.GetComponent<Collider2D>();

        return col1 != null && col2 != null && col1.bounds.Intersects(col2.bounds);
    }
    void SetHp(float val)//bar
    {



        Vector2 cur = mRt.sizeDelta;

        cur.x = val * alert;

        mRt.sizeDelta = cur;
    }
}