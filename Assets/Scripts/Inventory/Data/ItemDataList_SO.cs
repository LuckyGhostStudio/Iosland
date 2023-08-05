using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemDataList", menuName = "Inventory/ItemDataList")]
public class ItemDataList_SO : ScriptableObject
{
    public List<ItemDetails> itemDataList;     //��Ʒ��Ϣ�б�

    /// <summary>
    /// ������Ʒ��Ϣ
    /// </summary>
    /// <param name="itemName">��Ʒ����</param>
    /// <returns>��Ʒ��Ϣ</returns>
    public ItemDetails GetItemData(ItemName itemName)
    {
        return itemDataList.Find(i => i.name == itemName);  //���б��в���itemName��Ʒ
    }
}

[Serializable]
/// <summary>
/// ��Ʒ������Ϣ
/// </summary>
public class ItemDetails
{
    public ItemName name;   //����
    public Sprite sprite;   //ͼ��
}
