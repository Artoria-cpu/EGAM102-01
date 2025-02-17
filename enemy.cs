using UnityEngine;

public class enemy : MonoBehaviour
{
    public enum Enemy { Moving, Transformed }
    private Enemy currentState = Enemy.Moving;

    public float movespeed = 2f; 
    public float transformedspeed = 5f; 
    public float moveradius = 3f; 

    public GameObject ob1; //start
    public GameObject ob2;//phase2
    public GameObject ob3;//particle
    public GameObject player; 

    private Vector2 randomtarget;
    private bool istransformed = false;

    public userinterface UIscript;
    public int score = 1;

    public AudioSource basssource;
    public AudioClip bassclip;
    public AudioSource explodesource;
    public AudioClip explodeclip;
    void Start()
    {
        Setrandomtarget(); 
        ob1.SetActive(true); 
        ob2.SetActive(false);
        ob3.SetActive(false);
        UIscript = GameObject.FindFirstObjectByType<userinterface>();
    }

    void Update()
    {
        switch (currentState)
        {
            case Enemy.Moving:
                Randommove();
                break;
            case Enemy.Transformed:
                Randommove();
                break;
        }

        Interaction();
    }

    
    void Randommove()
    {
        transform.position = Vector2.MoveTowards(transform.position, randomtarget, movespeed * Time.deltaTime);

       
        if (Vector2.Distance(transform.position, randomtarget) < 0.1f)
        {
            Setrandomtarget();
        }
    }

 //new
    void Setrandomtarget()
    {
        Vector2 randomoffset = Random.insideUnitCircle * moveradius;
        randomtarget = (Vector2)transform.position + randomoffset;
    }

    
    void Interaction()
    {
        if (IsPlayerOverlapping() && Input.GetMouseButtonDown(0)) 
        {
            if (!istransformed)
            {
                TransformEnemy();
                basssource.clip = bassclip;
                basssource.Play();
            }
            else
            {
                Die(); 
                explodesource.clip = explodeclip;
                explodesource.Play();
            }
        }
    }


    bool IsPlayerOverlapping()
    {
        if (player == null) return false;

        Collider2D playerCollider = player.GetComponent<Collider2D>();
        Collider2D enemyCollider = GetComponent<Collider2D>();

        return playerCollider.bounds.Intersects(enemyCollider.bounds);
    }

 
    void TransformEnemy()
    {
        istransformed = true;
        currentState = Enemy.Transformed;
        movespeed = transformedspeed; 
        ob1.SetActive(false); 
        ob2.SetActive(true);  
    }

    void Die()
    {
      
        ob1.SetActive(false);
        ob2.SetActive(false);

        UIscript.AddScore(score);

      
        movespeed = 0f;

        
        ob3.SetActive(true);
        Destroy(gameObject, 3f); 
    }
}