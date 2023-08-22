using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameH2AData", menuName = "Mini Game Data/GameH2AData")]
public class GameH2AData_SO : ScriptableObject
{
    public List<BallDetails> ballDataList;      //����Ϣ�б�

    [Header("��ʼ��Ϣ����")]
    public List<Connection> lineConnections;    //line���ӹ����б�
    public List<BallName> startBallOrder;       //��ʼʱ���˳���б�

    /// <summary>
    /// ��������Ϣ
    /// </summary>
    /// <param name="name">������</param>
    /// <returns>����Ϣ</returns>
    public BallDetails GetBallDetails(BallName name)
    {
        return ballDataList.Find(b => b.name == name);
    }
}

/// <summary>
/// ����Ϣ
/// </summary>
[System.Serializable]
public class BallDetails
{
    public BallName name;
    public Sprite wrongSprite;  //λ�ô���ʱͼƬ
    public Sprite rightSprite;  //λ����ȷʱͼƬ
}

/// <summary>
/// ���ӣ�holder֮������ӹ�ϵ
/// </summary>
[System.Serializable]
public class Connection
{
    public int from;    //���
    public int to;      //�յ�
}