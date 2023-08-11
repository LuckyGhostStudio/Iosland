using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text itemNameText;

    /// <summary>
    /// 更新物品名字文本
    /// </summary>
    /// <param name="itemName">物品名字</param>
    public void UpdateItemNameText(ItemName itemName)
    {
        itemNameText.text = itemName switch
        {
            ItemName.Key => "一把钥匙",
            ItemName.Ticket => "一张船票",
            _ => ""
        };
    }
}
