using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : Singleton<InventoryManager>
{
    public ItemDataList_SO itemData;    //��Ʒ����

    [SerializeField] private List<ItemName> itemList = new List<ItemName>();    //��Ʒ�б������Ʒ���ƣ��ɸ�Ϊ��ƷUID��

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
}
