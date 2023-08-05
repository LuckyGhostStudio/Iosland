using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataList", menuName = "Inventory/ItemDataList")]
public class ItemDataList_SO : ScriptableObject
{
    public List<ItemDetails> itemDataList;     //物品信息列表

    /// <summary>
    /// 返回物品信息
    /// </summary>
    /// <param name="itemName">物品名称</param>
    /// <returns>物品信息</returns>
    public ItemDetails GetItemData(ItemName itemName)
    {
        return itemDataList.Find(i => i.name == itemName);  //在列表中查找itemName物品
    }
}

[Serializable]
/// <summary>
/// 物品详情信息
/// </summary>
public class ItemDetails
{
    public ItemName name;   //名字
    public Sprite sprite;   //图标
}
