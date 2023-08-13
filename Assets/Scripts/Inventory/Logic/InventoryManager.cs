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
    }

    private void OnDisable()
    {
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
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
            EventHandler.CallItemPickedEvent(null, -1); //������Ʒ��ʰȡ�¼� ����SlotUI
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
            
            EventHandler.CallItemPickedEvent(itemData.GetItemData(itemName), itemList.Count - 1); //������Ʒ��ʰȡ�¼�
        }
    }
}
