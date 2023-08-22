using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameH2AData", menuName = "Mini Game Data/GameH2AData")]
public class GameH2AData_SO : ScriptableObject
{
    public List<BallDetails> ballDataList;      //球信息列表

    [Header("初始信息数据")]
    public List<Connection> lineConnections;    //line连接规则列表
    public List<BallName> startBallOrder;       //开始时球的顺序列表

    /// <summary>
    /// 返回球信息
    /// </summary>
    /// <param name="name">球名字</param>
    /// <returns>球信息</returns>
    public BallDetails GetBallDetails(BallName name)
    {
        return ballDataList.Find(b => b.name == name);
    }
}

/// <summary>
/// 球信息
/// </summary>
[System.Serializable]
public class BallDetails
{
    public BallName name;
    public Sprite wrongSprite;  //位置错误时图片
    public Sprite rightSprite;  //位置正确时图片
}

/// <summary>
/// 连接：holder之间的连接关系
/// </summary>
[System.Serializable]
public class Connection
{
    public int from;    //起点
    public int to;      //终点
}