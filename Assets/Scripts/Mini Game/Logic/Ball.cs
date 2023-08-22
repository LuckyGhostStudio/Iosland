using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public BallDetails ballDetails;     //����Ϣ

    public bool isMatch;    //��ǰ���Ƿ���Holder��Ҫ����ȷ��ƥ��

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// ����Ball��Ϣ
    /// </summary>
    /// <param name="ball">ball��Ϣ</param>
    public void SetupBall(BallDetails ball)
    {
        ballDetails = ball;

        if (isMatch)    //ƥ��
        {
            SetRightSprite();   //������ȷSprite
        }
        else
        {
            SetWrongSprite();   //���ô���Sprite
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
