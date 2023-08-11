using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    public Text itemNameText;

    /// <summary>
    /// ������Ʒ�����ı�
    /// </summary>
    /// <param name="itemName">��Ʒ����</param>
    public void UpdateItemNameText(ItemName itemName)
    {
        itemNameText.text = itemName switch
        {
            ItemName.Key => "һ��Կ��",
            ItemName.Ticket => "һ�Ŵ�Ʊ",
            _ => ""
        };
    }
}
