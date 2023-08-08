using System;
using UnityEngine;

public static class EventHandler
{
    public static event Action<ItemDetails, int> ItemPickedEvent; //物品被拾取事件

    /// <summary>
    /// 调用物品被拾取事件
    /// </summary>
    /// <param name="itemDetails">物品信息</param>
    /// <param name="index">物品index</param>
    public static void CallItemPickedEvent(ItemDetails itemDetails, int index)
    {
        ItemPickedEvent?.Invoke(itemDetails, index);
    }

    public static event Action BeforeSceneUnloadEvent;  //场景卸载前事件：场景卸载前需要调用的事件

    /// <summary>
    /// 调用场景卸载前事件
    /// </summary>
    public static void CallBeforeSceneUnloadEvent()
    {
        BeforeSceneUnloadEvent?.Invoke();
    }

    public static event Action AfterSceneLoadedEvent;   //场景加载后事件：场景加载后需要调用的事件

    /// <summary>
    /// 调用场景加载后事件
    /// </summary>
    public static void CallAfterSceneLoadedEvent()
    {
        AfterSceneLoadedEvent?.Invoke();
    }
}
