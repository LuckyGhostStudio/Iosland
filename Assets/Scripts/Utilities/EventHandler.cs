using System;
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
}
