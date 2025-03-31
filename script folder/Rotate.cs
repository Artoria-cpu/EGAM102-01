using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // 旋转速度
    private Vector3 pivotPoint; // 旋转轴心

    void Start()
    {
        pivotPoint = transform.position; // 记录初始位置为旋转中心
    }

    void Update()
    {
        float rotation = 0f;

        if (Input.GetKey(KeyCode.Q))
        {
            rotation = -rotationSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotation = rotationSpeed * Time.deltaTime;
        }

        if (rotation != 0f)
        {
            transform.RotateAround(pivotPoint, Vector3.up, rotation);
        }
    }
}
