using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, bool> miniGameStateDic = new Dictionary<string, bool>(); //mini game ����-pass״̬

    private GameController currentGame;

    private int gameWeek;   //��Ϸ��Ŀ

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
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);     //����Menu����
        EventHandler.CallGameStateChangedEvent(GameState.GamePlay);
    }

    private void OnAfterSceneLoadedEvent()
    {
        foreach (var miniGame in FindObjectsOfType<MiniGame>())
        {
            if (miniGameStateDic.TryGetValue(miniGame.gameName, out bool pass)) //����miniGame��pass״̬
            {
                miniGame.isPass = pass;
                miniGame.UpdateMiniGameState();
            }
        }

        currentGame = FindObjectOfType<GameController>();   //���ҵ�ǰmini game controller
        currentGame?.SetGameWeekData(gameWeek);             //���õ�ǰ��Ŀ����
    }

    private void OnMiniGamePassEvent(string gameName)
    {
        miniGameStateDic[gameName] = true;  //MiniGameͨ��
    }
}
