using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : Singleton<GameController>
{
    public UnityEvent OnFinish; //MiniGame结束事件

    public GameH2AData_SO gameData;

    public GameObject lineParent;
    public LineRenderer linePrefab;
    public Ball ballPrefab;

    public Transform[] holderTransform; //holder数组0-7

    private void OnEnable()
    {
        EventHandler.CheckMiniGameStateEvent += OnCheckMiniGameStateEvent;
    }

    private void OnDisable()
    {
        EventHandler.CheckMiniGameStateEvent -= OnCheckMiniGameStateEvent;
    }

    private void Start()
    {
        DrawLine();
        CreateBall();
    }

    private void OnCheckMiniGameStateEvent()
    {
        //检查所有Ball是否匹配
        foreach (Ball ball in FindObjectsOfType<Ball>())
        {
            if (!ball.isMatch) return;
        }

        Debug.Log("Win!");
        //禁用Holder碰撞体
        foreach (var holder in holderTransform)
        {
            holder.GetComponent<Collider2D>().enabled = false;
        }
        EventHandler.CallMiniGamePassEvent(gameData.gameName);  //调用MiniGame通关事件
        OnFinish?.Invoke(); //调用MiniGame结束事件
    }

    public void ResetGame()
    {
        //遍历所有Holder
        foreach (var holder in holderTransform)
        {
            if (holder.childCount > 0)
            {
                Destroy(holder.GetChild(0).gameObject); //删除ball
            }
        }

        CreateBall();   //重新创新Ball
    }

    public void DrawLine()
    {
        //遍历连接列表
        foreach (var connection in gameData.lineConnections)
        {
            LineRenderer line = Instantiate(linePrefab, lineParent.transform);  //生成line

            line.SetPosition(0, holderTransform[connection.from].position); //起点
            line.SetPosition(1, holderTransform[connection.to].position);   //终点

            //添加与from相连的to的Holder到其HashSet 创建Holder之间的连接关系
            holderTransform[connection.from].GetComponent<Holder>().linkedHolders.Add(holderTransform[connection.to].GetComponent<Holder>());
            holderTransform[connection.to].GetComponent<Holder>().linkedHolders.Add(holderTransform[connection.from].GetComponent<Holder>());
        }
    }

    public void CreateBall()
    {
        //遍历初始球顺序列表
        for (int i = 0; i < gameData.startBallOrder.Count; i++)
        {
            if (gameData.startBallOrder[i] == BallName.None)    //空holder
            {
                holderTransform[i].gameObject.GetComponent<Holder>().isEmpty = true;
                continue;
            }

            Ball ball = Instantiate(ballPrefab, holderTransform[i]);    //生成Ball在每个holder下

            holderTransform[i].GetComponent<Holder>().CheckBall(ball);  //检查ball是否与Holder中的匹配
            holderTransform[i].gameObject.GetComponent<Holder>().isEmpty = false;
            ball.SetupBall(gameData.GetBallDetails(gameData.startBallOrder[i]));    //设置Ball信息
        }
    }
}
