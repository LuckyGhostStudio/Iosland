using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;             //物品图标
    public ItemTooltip itemTooltip;     //物品提示名
    private ItemDetails currentItem;    //当前物品信息

    private bool isSelected;    //是否被鼠标选中

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

    /// <summary>
    /// 鼠标点击时调用
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;   //改变选中状态
        EventHandler.CallItemSelectedEvent(currentItem, isSelected);    //调用物品被鼠标选中事件
    }

    /// <summary>
    /// 鼠标移入时调用
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.activeInHierarchy)   //SlotUI已启用
        {
            itemTooltip.gameObject.SetActive(true);             //启用tooltip
            itemTooltip.UpdateItemNameText(currentItem.name);   //更新物品名字文本
        }
    }

    /// <summary>
    /// 鼠标移出时调用
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        itemTooltip.gameObject.SetActive(false);    //启用tooltip
    }
}
