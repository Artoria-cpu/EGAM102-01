using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public List<GameObject> objects; 
    public float minR = 10f;     
    public float maxR = 50f;     
    public float minW = 1f;           
    public float maxW = 3f;           
    public float isthis = 1f;

    void Start()
    {
        
        // 为每个对象启动旋转协程
        foreach (GameObject obj in objects)
        {
            if (obj != null)
            {
                StartCoroutine(RotateObject(obj));
            }
        }
    }

    IEnumerator RotateObject(GameObject obj)
    {
        if (isthis == 1f)
        {
            while (true) //not for each loop but also loop
            {
                //current angle
                float ca = obj.transform.eulerAngles.z;

                //random angle
                float ta = ca + Random.Range(-30f, 30f);

                //random speed
                float rs = Random.Range(minR, maxR);

                //start
                Quaternion startRotation = obj.transform.rotation;
                Quaternion targetRotation = Quaternion.Euler(0, 0, ta);

                float t = 0;
                while (t < 1)
                {
                    t += Time.deltaTime * rs / 100f; 
                    obj.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
                    yield return null; // 等待下一帧
                }

                // 停留随机时间
                float wt = Random.Range(minW, maxW);
                yield return new WaitForSeconds(wt);
            }
        }
    }
}
