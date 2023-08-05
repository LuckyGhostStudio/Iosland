using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SceneName] public string sceneFrom;
    [SceneName] public string sceneTo;

    /// <summary>
    /// ���͵�Ŀ�ĳ���
    /// </summary>
    public void TeleportToScene()
    {
        TransitionManager.Instance.Transition(sceneFrom, sceneTo);  //from�������͵�to����
    }
}
