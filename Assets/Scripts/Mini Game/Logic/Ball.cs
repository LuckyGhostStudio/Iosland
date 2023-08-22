using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public BallDetails ballDetails;     //球信息

    public bool isMatch;    //当前球是否与Holder需要的正确球匹配

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// 设置Ball信息
    /// </summary>
    /// <param name="ball">ball信息</param>
    public void SetupBall(BallDetails ball)
    {
        ballDetails = ball;

        if (isMatch)    //匹配
        {
            SetRightSprite();   //设置正确Sprite
        }
        else
        {
            SetWrongSprite();   //设置错误Sprite
        }
    }

    public void SetRightSprite()
    {
        spriteRenderer.sprite = ballDetails.rightSprite;
    }

    public void SetWrongSprite()
    {
        spriteRenderer.sprite = ballDetails.wrongSprite;
    }
}
