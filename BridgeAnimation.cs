using UnityEngine;

public class BridgeAnimation : MonoBehaviour
{
    private Animator animator;


    void Start()
    {

        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            animator.SetTrigger("tob1");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.SetTrigger("tob2");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            animator.SetTrigger("tob3");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.SetTrigger("tob4");
        }
    }
}

