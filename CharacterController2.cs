using UnityEngine;
using System.Collections;

public class CharacterController2 : MonoBehaviour
{
    private bool isOnFirstPath;
    private int currentStep = 0;
    private Vector3[] path1, path2;
    public Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isFalling = false; 

    public float moveSpeed = 0.6f; 

    public AudioSource bibisource;
    public AudioClip bibiclip;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (animator == null)
        {
            animator = GetComponentInChildren<Animator>(); 
        }

        StartMoving();
    }



    public void StartMoving()
    {
        isOnFirstPath = false; 
        currentStep = 0;

        Transform[] rawPath2 = PathManager.Instance.path2;

        path2 = new Vector3[rawPath2.Length];

        for (int i = 0; i < rawPath2.Length; i++)
        {
            path2[i] = rawPath2[i].position;
        }

        if (spriteRenderer != null
)
        {
            spriteRenderer.flipX =true; 
        }

        transform.position = path2[0]; 
        StopAllCoroutines();
        StartCoroutine(MoveCharacter());
    }



    IEnumerator MoveCharacter()
    {
        while (true)
        {
            if (this == null || gameObject == null)
            {
                yield break;
            }

            

            if (CheckFall()) yield break;

            UpdateAnimation();

            yield return new WaitForSeconds(moveSpeed);

            if (currentStep == path2.Length - 1)
            {
                Destroy(gameObject);
                yield break;
            }

            currentStep++;
            transform.position = path2[currentStep];

            UpdateAnimation();
        }
    }




    void UpdateAnimation()
    {
        if (isFalling) return;

        if (animator == null)
        {
            animator = GetComponent<Animator>(); 
        }

        animator.ResetTrigger("toc1");
        animator.ResetTrigger("toc2");
        animator.ResetTrigger("toc3");
        animator.ResetTrigger("toc4");

        if (currentStep == 3 || currentStep == 6)
        {
            animator.SetTrigger("toc3");
            bibisource.clip = bibiclip;
            bibisource.Play();
        }
        else if (currentStep % 2 == 0)
        {
            animator.SetTrigger("toc1");
        }
        else
        {
            animator.SetTrigger("toc2");
        }
    }





    bool CheckFall()
    {

        if ((currentStep == 3 || currentStep == 6) && !BridgeManager.Instance.IsBridgeActive(currentStep))
        {

            isFalling = true;
            animator.SetTrigger("toc4"); 

            StartCoroutine(FallRoutine()); 
            return true; 
        }


        if (currentStep == 4 || currentStep == 7)
        {
            GameManager.Instance.AddScore();
        }

        return false; 

    }




    IEnumerator FallRoutine()
    {
        if (this != null && gameObject != null)
        {
            yield return new WaitForSeconds(1f); 
            transform.position += new Vector3(0, -8f, 0); 
            yield return new WaitForSeconds(1f); 

            GameManager.Instance.LoseLife();
            Destroy(gameObject);
        }
    }
}