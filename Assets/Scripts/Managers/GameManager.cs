using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, bool> miniGameStateDic = new Dictionary<string, bool>(); //mini game 名字-pass状态

    private GameController currentGame;

    private int gameWeek;   //游戏周目

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.MiniGamePassEvent += OnMiniGamePassEvent;
        EventHandler.StartNewGameEvent += OnStartNewGameEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
        EventHandler.MiniGamePassEvent -= OnMiniGamePassEvent;
        EventHandler.StartNewGameEvent -= OnStartNewGameEvent;
    }

    private void OnStartNewGameEvent(int gameWeek)
    {
        this.gameWeek = gameWeek;
        miniGameStateDic.Clear();
    }

    void Start()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);     //加载Menu场景
        EventHandler.CallGameStateChangedEvent(GameState.GamePlay);
    }

    private void OnAfterSceneLoadedEvent()
    {
        foreach (var miniGame in FindObjectsOfType<MiniGame>())
        {
            if (miniGameStateDic.TryGetValue(miniGame.gameName, out bool pass)) //查找miniGame的pass状态
            {
                miniGame.isPass = pass;
                miniGame.UpdateMiniGameState();
            }
        }

        currentGame = FindObjectOfType<GameController>();   //查找当前mini game controller
        currentGame?.SetGameWeekData(gameWeek);             //设置当前周目数据
    }

    private void OnMiniGamePassEvent(string gameName)
    {
        miniGameStateDic[gameName] = true;  //MiniGame通关
    }
}
