using System;
using UnityEditor.PackageManager;
using UnityEngine;

public static class EventHandler
{
    public static event Action<ItemDetails, int> UpdateUIEvent; //UI�����¼�

    /// <summary>
    /// ����UI�����¼�
    /// </summary>
    /// <param name="itemDetails">��Ʒ��Ϣ</param>
    /// <param name="index">��Ʒindex</param>
    public static void CallUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        UpdateUIEvent?.Invoke(itemDetails, index);
    }

    public static event Action BeforeSceneUnloadEvent;  //����ж��ǰ�¼�������ж��ǰ��Ҫ���õ��¼�

    /// <summary>
    /// ���ó���ж��ǰ�¼�
    /// </summary>
    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }

    public static event Action AfterSceneLoadedEvent;   //�������غ��¼����������غ���Ҫ���õ��¼�

    /// <summary>
    /// ���ó������غ��¼�
    /// </summary>
    public static void CallAfterSceneLoadedEvent()
    {
        AfterSceneLoadedEvent?.Invoke();
    }

    public static event Action<ItemDetails, bool> ItemSelectedEvent;    //��Ʒ�����ѡ���¼�

    /// <summary>
    /// ������Ʒ�����ѡ���¼�
    /// </summary>
    /// <param name="itemDetails">��Ʒ��Ϣ</param>
    /// <param name="selected">ѡ��״̬</param>
    public static void CallItemSelectedEvent(ItemDetails itemDetails, bool selected)
    {
        ItemSelectedEvent?.Invoke(itemDetails, selected);
    }

    public static event Action<ItemName> ItemUsedEvent; //��Ʒ��ʹ���¼�

    /// <summary>
    /// ������Ʒ��ʹ���¼�
    /// </summary>
    /// <param name="name">��Ʒ����</param>
    public static void CallItemUsedEvent(ItemName name)
    {
        ItemUsedEvent?.Invoke(name);
    }

    public static event Action<int> ItemSwitchedEvent;  //��Ʒ�л��¼�

    /// <summary>
    /// ������Ʒ�л��¼�
    /// </summary>
    /// <param name="index">���л�������Ʒ���</param>
    public static void CallItemSwitchedEvent(int index)
    {
        ItemSwitchedEvent?.Invoke(index);
    }

    public static event Action<string> ShowDialogueEvent;  //��ʾ�Ի��¼�

    /// <summary>
    /// ������ʾ�Ի��¼�
    /// </summary>
    /// <param name="dialogue">Ҫ��ʾ�ĶԻ�</param>
    public static void CallShowDialogueEvent(string dialogue)
    {
        ShowDialogueEvent?.Invoke(dialogue);
    }

    public static event Action<GameState> GameStateChangedEvent;    //��Ϸ״̬�ı��¼�

    /// <summary>
    /// ������Ϸ״̬�ı��¼�
    /// </summary>
    /// <param name="state">Ҫ���õ���Ϸ״̬</param>
    public static void CallGameStateChangedEvent(GameState state)
    {
        GameStateChangedEvent?.Invoke(state);
    }
}
