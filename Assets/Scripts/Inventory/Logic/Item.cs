using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName itemName;

    /// <summary>
    /// 物品被点击
    /// </summary>
    public void ItemClicked()
    {
        InventoryManager.Instance.AddItem(itemName);    //添加物体到背包
        gameObject.SetActive(false);                    //隐藏
    }
}
