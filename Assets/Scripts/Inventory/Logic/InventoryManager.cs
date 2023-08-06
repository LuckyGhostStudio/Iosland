using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemData;    //物品数据

    [SerializeField] private List<ItemName> itemList = new List<ItemName>();    //物品列表：存放物品名称（可改为物品UID）

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
}
