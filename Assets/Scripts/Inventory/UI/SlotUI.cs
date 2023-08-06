using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour
{
    public Image itemImage;             //��Ʒͼ��
    public ItemDetails currentItem;     //��ǰ��Ʒ��Ϣ

    private bool isSelected;    //�Ƿ�ѡ��

    /// <summary>
    /// ������Ʒ
    /// </summary>
    /// <param name="itemDetails">��Ʒ��Ϣ</param>
    public void SetItem(ItemDetails itemDetails)
    {
        currentItem = itemDetails;
        gameObject.SetActive(true);     //���õ�ǰSlot����ʾ��ǰSlot UI

        itemImage.sprite = itemDetails.sprite;
        itemImage.SetNativeSize();
    }

    /// <summary>
    /// ������Ʒ��Ϊ��
    /// </summary>
    public void SetEmpty()
    {
        gameObject.SetActive(false);    //ȡ����ʾSlot UI
    }
}
