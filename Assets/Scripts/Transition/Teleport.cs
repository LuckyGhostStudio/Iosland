using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SceneName] public string sceneFrom;
    [SceneName] public string sceneTo;

    /// <summary>
    /// 传送到目的场景
    /// </summary>
    public void TeleportToScene()
    {
        TransitionManager.Instance.Transition(sceneFrom, sceneTo);  //from场景传送到to场景
    }
}
