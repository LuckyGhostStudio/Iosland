using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemData;    //物品数据

    [SerializeField] private List<ItemName> itemList = new List<ItemName>();    //物品列表：存放物品名称（可改为物品UID）

    private void OnEnable()
    {
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
        EventHandler.ItemSwitchedEvent += OnItemSwitchedEvent;
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
        EventHandler.ItemSwitchedEvent -= OnItemSwitchedEvent;
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnAfterSceneLoadedEvent()
    {
        if (itemList.Count == 0)
        {
            EventHandler.CallUpdateUIEvent(null, -1);
        }
        else
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                EventHandler.CallUpdateUIEvent(itemData.GetItemData(itemList[i]), i);   //调用更新UI事件
            }
        }
    }

    /// <summary>
    /// 物品切换事件处理方法
    /// </summary>
    /// <param name="index">已切换到的物品编号</param>
    private void OnItemSwitchedEvent(int index)
    {
        if (index >= 0 && index < itemList.Count)
        {
            EventHandler.CallUpdateUIEvent(itemData.GetItemData(itemList[index]), index);   //调用更新UI事件
        }
    }

    /// <summary>
    /// 物品被使用事件处理方法
    /// </summary>
    /// <param name="name">物品名字</param>
    private void OnItemUsedEvent(ItemName name)
    {
        int index = itemList.IndexOf(name);
        itemList.RemoveAt(index);   //从背包移除

        if (itemList.Count == 0)
        {
            EventHandler.CallUpdateUIEvent(null, -1); //调用物品被拾取事件 更新SlotUI
        }
    }

    /// <summary>
    /// 添加物品到背包列表
    /// </summary>
    /// <param name="itemName">物品名称</param>
    public void AddItem(ItemName itemName)
    {
        //物品不存在
        if (!itemList.Contains(itemName))
        {
            itemList.Add(itemName);     //添加物品到列表

            EventHandler.CallUpdateUIEvent(itemData.GetItemData(itemName), itemList.Count - 1); //调用UI更新事件
        }
    }

    public int GetItemsCount()
    {
        return itemList.Count;
    }
}
