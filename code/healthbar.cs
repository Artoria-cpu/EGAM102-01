using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public RectTransform mRt;
    //血条最大值
    public float max = 30;
    public Attack attack;
    void Start()
    {
        //设置血量为80%
        SetHp(70f);
    }
    //设置当前血量
    void SetHp(float val)
    {
        if (attack != null)
        {
            float max = attack.specialModeProgress;
        }

        //先取出当前的宽和高
        Vector2 cur = mRt.sizeDelta;
        //得到需要修改的宽度
        cur.x = val * max;
        //重新赋值
        mRt.sizeDelta = cur;
    }

    private void Update()
    {
      

        SetHp(70f);
    }
}
