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
    }

    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
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
            EventHandler.CallItemPickedEvent(null, -1); //调用物品被拾取事件 更新SlotUI
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
            
            EventHandler.CallItemPickedEvent(itemData.GetItemData(itemName), itemList.Count - 1); //调用物品被拾取事件
        }
    }
}
