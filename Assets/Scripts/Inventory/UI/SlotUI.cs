using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image itemImage;             //��Ʒͼ��
    public ItemTooltip itemTooltip;     //��Ʒ��ʾ��
    private ItemDetails currentItem;    //��ǰ��Ʒ��Ϣ

    private bool isSelected;    //�Ƿ����ѡ��

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

    /// <summary>
    /// �����ʱ����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;   //�ı�ѡ��״̬
        EventHandler.CallItemSelectedEvent(currentItem, isSelected);    //������Ʒ�����ѡ���¼�
    }

    /// <summary>
    /// �������ʱ����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (gameObject.activeInHierarchy)   //SlotUI������
        {
            itemTooltip.gameObject.SetActive(true);             //����tooltip
            itemTooltip.UpdateItemNameText(currentItem.name);   //������Ʒ�����ı�
        }
    }

    /// <summary>
    /// ����Ƴ�ʱ����
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        itemTooltip.gameObject.SetActive(false);    //����tooltip
    }
}
