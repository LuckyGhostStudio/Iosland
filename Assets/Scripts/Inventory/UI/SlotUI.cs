using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image itemImage;             //物品图标
    public ItemDetails currentItem;     //当前物品信息

    private bool isSelected;    //是否被选中

    /// <summary>
    /// 设置物品
    /// </summary>
    /// <param name="itemDetails">物品信息</param>
    public void SetItem(ItemDetails itemDetails)
    {
        currentItem = itemDetails;
        gameObject.SetActive(true);     //启用当前Slot：显示当前Slot UI

        itemImage.sprite = itemDetails.sprite;
        itemImage.SetNativeSize();
    }

    /// <summary>
    /// 设置物品栏为空
    /// </summary>
    public void SetEmpty()
    {
        gameObject.SetActive(false);    //取消显示Slot UI
    }
}
