using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : Interactive
{
    public BallName matchBall;  //��ǰHolder��Ҫƥ���Ball
    private Ball currentBall;   //��ǰHolder�ڵ�Ball

    public HashSet<Holder> linkedHolders = new HashSet<Holder>();   //�뵱ǰHolder������Holder����

    public bool isEmpty;        //��ǰHolder�Ƿ�Ϊ��

    /// <summary>
    /// ��鵱ǰBall�Ƿ�ΪHolder�����Ball
    /// </summary>
    /// <param name="ball"></param>
    public void CheckBall(Ball ball)
    {
        currentBall = ball;

        if(ball.ballDetails.name == matchBall)  //ƥ��
        {
            currentBall.isMatch = true;
            currentBall.SetRightSprite();   //������ȷ��ͼƬ
        }
        else
        {
            currentBall.isMatch = false;
            currentBall.SetWrongSprite();   //���ô����ͼƬ
        }
    }

    public override void EmptyClicked()
    {
        //���������뵱ǰHolder���ӵ�Holder
        foreach (Holder holder in linkedHolders)
        {
            if (holder.isEmpty) //��Holder
            {
                currentBall.transform.position = holder.transform.position; //�ƶ���ǰHolder����holder
                currentBall.transform.SetParent(holder.transform);          //���ø���

                holder.CheckBall(currentBall);  //��鵱ǰHolder�ƶ���ȥ�����Ƿ���holderƥ��
                currentBall = null;             //��ǰHolder�����ÿ�

                isEmpty = true;                 //��ǰHolderΪ��
                holder.isEmpty = false;         //holder��Ϊ��

                EventHandler.CallCheckMiniGameStateEvent(); //���ü��MiniGame״̬�¼�
            }
        }
    }
}
