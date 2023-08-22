using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : Interactive
{
    public BallName matchBall;  //当前Holder需要匹配的Ball
    private Ball currentBall;   //当前Holder内的Ball

    public HashSet<Holder> linkedHolders = new HashSet<Holder>();   //与当前Holder相连的Holder集合

    public bool isEmpty;        //当前Holder是否为空

    /// <summary>
    /// 检查当前Ball是否为Holder所需的Ball
    /// </summary>
    /// <param name="ball"></param>
    public void CheckBall(Ball ball)
    {
        currentBall = ball;

        if(ball.ballDetails.name == matchBall)  //匹配
        {
            currentBall.isMatch = true;
            currentBall.SetRightSprite();   //设置正确的图片
        }
        else
        {
            currentBall.isMatch = false;
            currentBall.SetWrongSprite();   //设置错误的图片
        }
    }

    public override void EmptyClicked()
    {
        //遍历所有与当前Holder连接的Holder
        foreach (Holder holder in linkedHolders)
        {
            if (holder.isEmpty) //空Holder
            {
                currentBall.transform.position = holder.transform.position; //移动当前Holder的球到holder
                currentBall.transform.SetParent(holder.transform);          //设置父级

                holder.CheckBall(currentBall);  //检查当前Holder移动过去的球是否与holder匹配
                currentBall = null;             //当前Holder的球置空

                isEmpty = true;                 //当前Holder为空
                holder.isEmpty = false;         //holder不为空

                EventHandler.CallCheckMiniGameStateEvent(); //调用检查MiniGame状态事件
            }
        }
    }
}
