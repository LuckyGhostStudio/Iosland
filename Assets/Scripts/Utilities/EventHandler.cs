using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action<ItemDetails, int> ItemPickedEvent; //��Ʒ��ʰȡ�¼�

    /// <summary>
    /// ������Ʒ��ʰȡ�¼�
    /// </summary>
    /// <param name="itemDetails">��Ʒ��Ϣ</param>
    /// <param name="index">��Ʒindex</param>
    public static void CallItemPickedEvent(ItemDetails itemDetails, int index)
    {
        ItemPickedEvent?.Invoke(itemDetails, index);
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
}
