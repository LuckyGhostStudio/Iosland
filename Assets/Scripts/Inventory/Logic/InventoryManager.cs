using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemData;    //��Ʒ����

    [SerializeField] private List<ItemName> itemList = new List<ItemName>();    //��Ʒ�б������Ʒ���ƣ��ɸ�Ϊ��ƷUID��

    private void OnEnable()
    {
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
        EventHandler.ItemSwitchedEvent += OnItemSwitchedEvent;
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
        EventHandler.ItemSwitchedEvent -= OnItemSwitchedEvent;
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
    }

    private void OnAfterSceneLoadedEvent()
    {
        if (itemList.Count == 0)
        {
            EventHandler.CallUpdateUIEvent(null, -1);
        }
        else
        {
            for(int i = 0; i < itemList.Count; i++)
            {
                EventHandler.CallUpdateUIEvent(itemData.GetItemData(itemList[i]), i);   //���ø���UI�¼�
            }
        }
    }

    /// <summary>
    /// ��Ʒ�л��¼�������
    /// </summary>
    /// <param name="index">���л�������Ʒ���</param>
    private void OnItemSwitchedEvent(int index)
    {
        if (index >= 0 && index < itemList.Count)
        {
            EventHandler.CallUpdateUIEvent(itemData.GetItemData(itemList[index]), index);   //���ø���UI�¼�
        }
    }

    /// <summary>
    /// ��Ʒ��ʹ���¼�������
    /// </summary>
    /// <param name="name">��Ʒ����</param>
    private void OnItemUsedEvent(ItemName name)
    {
        int index = itemList.IndexOf(name);
        itemList.RemoveAt(index);   //�ӱ����Ƴ�

        if (itemList.Count == 0)
        {
            EventHandler.CallUpdateUIEvent(null, -1); //������Ʒ��ʰȡ�¼� ����SlotUI
        }
    }

    /// <summary>
    /// �����Ʒ�������б�
    /// </summary>
    /// <param name="itemName">��Ʒ����</param>
    public void AddItem(ItemName itemName)
    {
        //��Ʒ������
        if (!itemList.Contains(itemName))
        {
            itemList.Add(itemName);     //�����Ʒ���б�

            EventHandler.CallUpdateUIEvent(itemData.GetItemData(itemName), itemList.Count - 1); //����UI�����¼�
        }
    }

    public int GetItemsCount()
    {
        return itemList.Count;
    }
}
