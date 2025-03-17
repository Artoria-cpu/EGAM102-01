using UnityEngine;

public class HingeObject : MonoBehaviour
{
    public HingeJoint2D hinge;

    public float motorSpeed = -100;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            JointMotor2D tempMotor = hinge.motor;

            tempMotor.motorSpeed = motorSpeed; 

            hinge.motor = tempMotor;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            JointMotor2D tempMotor = hinge.motor;
            tempMotor.motorSpeed = -motorSpeed;
            hinge.motor = tempMotor;
        }
    }
}
