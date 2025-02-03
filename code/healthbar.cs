using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RectTransform mRt;
    //Ѫ�����ֵ
    public float max = 30;
    public Attack attack;
    void Start()
    {
        //����Ѫ��Ϊ80%
        SetHp(70f);
    }
    //���õ�ǰѪ��
    void SetHp(float val)
    {
        if (attack != null)
        {
            float max = attack.specialModeProgress;
        }

        //��ȡ����ǰ�Ŀ�͸�
        Vector2 cur = mRt.sizeDelta;
        //�õ���Ҫ�޸ĵĿ��
        cur.x = val * max;
        //���¸�ֵ
        mRt.sizeDelta = cur;
    }

    private void Update()
    {
      

        SetHp(70f);
    }
}
