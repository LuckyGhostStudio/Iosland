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
        EventHandler.ItemPickedEvent += OnUpdateUIEvent;  //ע�� UI�����¼�������
    }

    private void OnDisable()
    {
        EventHandler.ItemPickedEvent -= OnUpdateUIEvent;
    }

    /// <summary>
    /// UI�����¼�������
    /// </summary>
    /// <param name="itemDetails">��Ʒ��Ϣ</param>
    /// <param name="index">��Ʒindex</param>
    private void OnUpdateUIEvent(ItemDetails itemDetails, int index)
    {
        //��ƷΪ��
        if(itemDetails == null)
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
        }
    }
}
