using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Button leftButton, rightButton;

    public SlotUI slotUI;       //物品Slot UI

    public int currentIndex;    //当前物品index

    private void OnEnable()
    {
        EventHandler.ItemPickedEvent += OnUpdateUIEvent;  //注册 UI更新事件处理方法
    }

    private void OnDisable()
    {
        EventHandler.ItemPickedEvent -= OnUpdateUIEvent;
    }

    /// <summary>
    /// UI更新事件处理方法
    /// </summary>
    /// <param name="itemDetails">物品信息</param>
    /// <param name="index">物品index</param>
    private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        //物品为空
        if(itemDetails == null)
        {
            slotUI.SetEmpty();  //设置Slot为空
            currentIndex = -1;
            //禁用左右选择箭头
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
        else
        {
            currentIndex = index;
            slotUI.SetItem(itemDetails);    //设置物品信息
        }
    }
}
