using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : Singleton<GameController>
{
    public UnityEvent OnFinish; //MiniGame�����¼�

    public GameH2AData_SO gameData;

    public GameObject lineParent;
    public LineRenderer linePrefab;
    public Ball ballPrefab;

    public Transform[] holderTransform; //holder����0-7

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
        //�������Ball�Ƿ�ƥ��
        foreach (Ball ball in FindObjectsOfType<Ball>())
        {
            if (!ball.isMatch) return;
        }

        Debug.Log("Win!");
        //����Holder��ײ��
        foreach (var holder in holderTransform)
        {
            holder.GetComponent<Collider2D>().enabled = false;
        }
        EventHandler.CallMiniGamePassEvent(gameData.gameName);  //����MiniGameͨ���¼�
        OnFinish?.Invoke(); //����MiniGame�����¼�
    }

    public void ResetGame()
    {
        //��������Holder
        foreach (var holder in holderTransform)
        {
            if (holder.childCount > 0)
            {
                Destroy(holder.GetChild(0).gameObject); //ɾ��ball
            }
        }

        CreateBall();   //���´���Ball
    }

    public void DrawLine()
    {
        //���������б�
        foreach (var connection in gameData.lineConnections)
        {
            LineRenderer line = Instantiate(linePrefab, lineParent.transform);  //����line

            line.SetPosition(0, holderTransform[connection.from].position); //���
            line.SetPosition(1, holderTransform[connection.to].position);   //�յ�

            //�����from������to��Holder����HashSet ����Holder֮������ӹ�ϵ
            holderTransform[connection.from].GetComponent<Holder>().linkedHolders.Add(holderTransform[connection.to].GetComponent<Holder>());
            holderTransform[connection.to].GetComponent<Holder>().linkedHolders.Add(holderTransform[connection.from].GetComponent<Holder>());
        }
    }

    public void CreateBall()
    {
        //������ʼ��˳���б�
        for (int i = 0; i < gameData.startBallOrder.Count; i++)
        {
            if (gameData.startBallOrder[i] == BallName.None)    //��holder
            {
                holderTransform[i].gameObject.GetComponent<Holder>().isEmpty = true;
                continue;
            }

            Ball ball = Instantiate(ballPrefab, holderTransform[i]);    //����Ball��ÿ��holder��

            holderTransform[i].GetComponent<Holder>().CheckBall(ball);  //���ball�Ƿ���Holder�е�ƥ��
            holderTransform[i].gameObject.GetComponent<Holder>().isEmpty = false;
            ball.SetupBall(gameData.GetBallDetails(gameData.startBallOrder[i]));    //����Ball��Ϣ
        }
    }
}
