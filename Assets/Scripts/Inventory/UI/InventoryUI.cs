using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Button leftButton, rightButton;

    public SlotUI slotUI;       //��ƷSlot UI

    public int currentIndex;    //��ǰ��Ʒindex

    private void OnEnable()
    {
        EventHandler.UpdateUIEvent += OnUpdateUIEvent;  //ע�� UI�����¼�������
    }

    private void OnDisable()
    {
        EventHandler.UpdateUIEvent -= OnUpdateUIEvent;
    }

    /// <summary>
    /// UI�����¼�������
    /// </summary>
    /// <param name="itemDetails">��Ʒ��Ϣ</param>
    /// <param name="index">��Ʒindex</param>
    private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        //��ƷΪ��
        if (itemDetails == null)
        {
            slotUI.SetEmpty();  //����SlotΪ��
            currentIndex = -1;
            //��������ѡ���ͷ
            leftButton.interactable = false;
            rightButton.interactable = false;
        }
        else
        {
            currentIndex = index;
            slotUI.SetItem(itemDetails);    //������Ʒ��Ϣ

            if(currentIndex > 0)    //�����ұ�
            {
                leftButton.interactable = true;
                rightButton.interactable = false;
            }
        }
    }

    /// <summary>
    /// �л���Ʒ
    /// </summary>
    /// <param name="amount">������</param>
    public void SwitchItem(int amount)
    {
        if (currentIndex + amount <= 0)  //�������
        {
            leftButton.interactable = false;
            rightButton.interactable = true;
        }
        else if (currentIndex + amount >= InventoryManager.Instance.GetItemsCount() - 1)    //�����ұ�
        {
            leftButton.interactable = true;
            rightButton.interactable = false;
        }
        else
        {
            leftButton.interactable = true;
            rightButton.interactable = true;
        }

        EventHandler.CallItemSwitchedEvent(currentIndex + amount);  //������Ʒ�л��¼�
    }
}
