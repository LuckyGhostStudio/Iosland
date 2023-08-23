using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Dictionary<string, bool> miniGameStateDic = new Dictionary<string, bool>(); //mini game 名字-pass状态

    private void OnEnable()
    {
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.MiniGamePassEvent += OnMiniGamePassEvent;
    }

    private void OnDisable()
    {
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
        EventHandler.MiniGamePassEvent -= OnMiniGamePassEvent;
    }

    void Start()
    {
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
    }

    private void OnMiniGamePassEvent(string gameName)
    {
        miniGameStateDic[gameName] = true;  //MiniGame通关
    }
}
