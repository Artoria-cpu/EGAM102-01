using UnityEngine;

public class playermove : MonoBehaviour
{
    public enum State { Idle, Moving } 
    private State currentState = State.Idle;

    public float Force = 10f;   
    public float max = 5f;     
    public float drag = 2f;  
    public float idleshakeintensity = 0.1f;  
    public float idleshakespeed = 2f;       

    private Rigidbody2D rb;
    private Vector2 targetposition;
    private Vector2 startposition;
    private float idle;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearDamping = drag;
        startposition = transform.position; //record
    }

    void FixedUpdate()
    {
        switch (currentState)
        {
            case State.Idle:
                Shake();
                Checkmouse(); //ismoving
                break;
            case State.Moving:
                Applyforce();
                Checkstop(); // isstop
                break;
        }
    }

    //shake
    void Shake()
    {
        idle += Time.deltaTime * idleshakespeed;
        float offsetX = Mathf.Sin(idle) * idleshakeintensity;
        float offsetY = Mathf.Cos(idle * 1.5f) * idleshakeintensity;
        transform.position = startposition + new Vector2(offsetX, offsetY);
    }

    //move
    void Checkmouse()
    {
        if (Input.GetMouseButton(1)) //right
        {
            currentState = State.Moving;
        }
    }

    //
    void Applyforce()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetposition = new Vector2(mouseWorldPos.x, mouseWorldPos.y);

        Vector2 direction = (targetposition - rb.position).normalized;
        float distance = Vector2.Distance(rb.position, targetposition);

        if (distance > 0.1f)
        {
            rb.AddForce(direction * Force);
        }

        //maxspeed
        if (rb.linearVelocity.magnitude > max)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * max;
        }
    }

    //back
    void Checkstop()
    {
        if (!Input.GetMouseButton(0) && rb.linearVelocity.magnitude < 0.1f)
        {
            rb.linearVelocity = Vector2.zero;
            startposition = transform.position; //renew
            idle = 0; 
            currentState = State.Idle;
        }
    }
}