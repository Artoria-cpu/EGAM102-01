using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class enemyone : MonoBehaviour
{
    public GameObject player; 
    public float movespeed = 2f;   
    public float transformedSpeed = 5f; 
    public float mo = 3f; 
    private Vector2 rt;

    public userinterface UIscript;

    public AudioSource explodesource;
    public AudioClip explodeclip;
    private void Start()
    {
        Setrandomtarget();
        UIscript = GameObject.FindFirstObjectByType<userinterface>();
    }
    void Update()
    {
        Interaction();
        Randommove();
    }

    // 检测与玩家的重叠并按下右键
    void Interaction()
    {
        if (collide() && Input.GetMouseButtonDown(0))
        {
            UIscript.AddScore(1);
            Destroy(gameObject); 
            explodesource.clip = explodeclip;
            explodesource.Play();
        }
    }

    //collide?
    bool collide()
    {
        if (player == null) return false;

        Collider2D playerCollider = player.GetComponent<Collider2D>();
        Collider2D enemyCollider = GetComponent<Collider2D>();

        return playerCollider.bounds.Intersects(enemyCollider.bounds);
    }
    void Randommove()
    {
        transform.position = Vector2.MoveTowards(transform.position, rt, movespeed * Time.deltaTime);

        //choose a new taregt
        if (Vector2.Distance(transform.position, rt) < 0.1f)
        {
            Setrandomtarget();
        }
    }

    //randomtarget
    void Setrandomtarget()
    {
        Vector2 randomOffset = Random.insideUnitCircle * mo;
        rt = (Vector2)transform.position + randomOffset;
    }
}