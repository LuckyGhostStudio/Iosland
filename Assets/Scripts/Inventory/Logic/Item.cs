using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemName itemName;

    /// <summary>
    /// ��Ʒ�����
    /// </summary>
    public void ItemClicked()
    {
        InventoryManager.Instance.AddItem(itemName);    //������嵽����
        gameObject.SetActive(false);                    //����
    }
}
