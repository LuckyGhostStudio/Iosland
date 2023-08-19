using System;
using UnityEditor.PackageManager;
using UnityEngine;

public static class EventHandler
{
    public static event Action<ItemDetails, int> UpdateUIEvent; //UI更新事件

    /// <summary>
    /// 调用UI更新事件
    /// </summary>
    /// <param name="itemDetails">物品信息</param>
    /// <param name="index">物品index</param>
    public static void CallUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        UpdateUIEvent?.Invoke(itemDetails, index);
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

    public static event Action<ItemDetails, bool> ItemSelectedEvent;    //物品被鼠标选中事件

    /// <summary>
    /// 调用物品被鼠标选中事件
    /// </summary>
    /// <param name="itemDetails">物品信息</param>
    /// <param name="selected">选中状态</param>
    public static void CallItemSelectedEvent(ItemDetails itemDetails, bool selected)
    {
        ItemSelectedEvent?.Invoke(itemDetails, selected);
    }

    public static event Action<ItemName> ItemUsedEvent; //物品被使用事件

    /// <summary>
    /// 调用物品被使用事件
    /// </summary>
    /// <param name="name">物品名字</param>
    public static void CallItemUsedEvent(ItemName name)
    {
        ItemUsedEvent?.Invoke(name);
    }

    public static event Action<int> ItemSwitchedEvent;  //物品切换事件

    /// <summary>
    /// 调用物品切换事件
    /// </summary>
    /// <param name="index">已切换到的物品编号</param>
    public static void CallItemSwitchedEvent(int index)
    {
        ItemSwitchedEvent?.Invoke(index);
    }

    public static event Action<string> ShowDialogueEvent;  //显示对话事件

    /// <summary>
    /// 调用显示对话事件
    /// </summary>
    /// <param name="dialogue">要显示的对话</param>
    public static void CallShowDialogueEvent(string dialogue)
    {
        ShowDialogueEvent?.Invoke(dialogue);
    }

    public static event Action<GameState> GameStateChangedEvent;    //游戏状态改变事件

    /// <summary>
    /// 调用游戏状态改变事件
    /// </summary>
    /// <param name="state">要设置的游戏状态</param>
    public static void CallGameStateChangedEvent(GameState state)
    {
        GameStateChangedEvent?.Invoke(state);
    }
}
