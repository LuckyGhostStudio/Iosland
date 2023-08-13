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
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;  //注册 UI更新事件处理方法
    }

    private void OnDisable()
    {
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    /// <summary>
    /// UI更新事件处理方法
    /// </summary>
    /// <param name="itemDetails">物品信息</param>
    /// <param name="index">物品index</param>
    private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        //物品为空
        if (itemDetails == null)
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

            if(currentIndex > 0)    //在最右边
            {
                leftButton.interactable = true;
                rightButton.interactable = false;
            }
        }
    }

    /// <summary>
    /// 切换物品
    /// </summary>
    /// <param name="amount">增减量</param>
    public void SwitchItem(int amount)
    {
        if (currentIndex + amount <= 0)  //在最左边
        {
            leftButton.interactable = false;
            rightButton.interactable = true;
        }
        else if (currentIndex + amount >= InventoryManager.Instance.GetItemsCount() - 1)    //在最右边
        {
            leftButton.interactable = true;
            rightButton.interactable = false;
        }
        else
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
        }

        EventHandler.CallItemSwitchedEvent(currentIndex + amount);  //调用物品切换事件
    }
}
