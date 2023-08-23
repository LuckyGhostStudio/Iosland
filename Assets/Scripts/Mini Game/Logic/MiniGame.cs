using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class MiniGame : MonoBehaviour
{
    public UnityEvent OnGameFinish; //游戏完成事件

    [SceneName] public string gameName; //mini game 名字
    public bool isPass; //游戏通关
    
    public void UpdateMiniGameState()
    {
        if (isPass) //通关
        {
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

            OnGameFinish?.Invoke();
        }
    }
}
