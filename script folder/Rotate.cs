using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 100f; // ��ת�ٶ�
    private Vector3 pivotPoint; // ��ת����

    void Start()
    {
        pivotPoint = transform.position; // ��¼��ʼλ��Ϊ��ת����
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
