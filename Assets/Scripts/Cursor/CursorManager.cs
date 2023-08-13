using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public RectTransform hand;  //��Transform

    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private ItemName currentItem;   //��ǰ��Ʒ

    private bool canClick;  //���λ�õĶ����Ƿ���Ե��
    private bool holdItem;  //����Ƿ�������Ʒ

    private void OnEnable()
    {
        EventHandler.ItemSelectedEvent += OnItemSelectedEvent;
        EventHandler.ItemUsedEvent += OnItemUsedEvent;
    }

    private void OnDisable()
    {
        EventHandler.ItemSelectedEvent -= OnItemSelectedEvent;
        EventHandler.ItemUsedEvent -= OnItemUsedEvent;
    }

    private void Update()
    {
        canClick = GetColliderAtMousePosition();

        if (hand.gameObject.activeInHierarchy) hand.position = Input.mousePosition; //�������λ��

        if(canClick && Input.GetMouseButtonDown(0)) //���λ���пɵ����ײ�� && �������
        {
            ClickAction(GetColliderAtMousePosition().gameObject);
        }
    }

    private void OnItemUsedEvent(ItemName name)
    {
        currentItem = ItemName.None;
        holdItem = false;
        hand.gameObject.SetActive(false);   //������
    }

    /// <summary>
    /// ��Ʒ�����ѡ���¼�������
    /// </summary>
    /// <param name="itemDetails">��Ʒ��Ϣ</param>
    /// <param name="selected">ѡ��״̬</param>
    private void OnItemSelectedEvent(ItemDetails itemDetails, bool selected)
    {
        holdItem = selected;
        if (selected)
        {
            currentItem = itemDetails.name;
        }
        hand.gameObject.SetActive(holdItem);    //�����ֵ�����״̬
    }

    /// <summary>
    /// ���ݱ����������в�ͬ����
    /// </summary>
    /// <param name="clickedObject">���������</param>
    private void ClickAction(GameObject clickedObject)
    {
        switch(clickedObject.tag)
        {
            case "Teleport":    //����
                var teleportScript = clickedObject.GetComponent<Teleport>();
                teleportScript?.TeleportToScene();  //��������
                break;
            case "Item":        //��Ʒ
                var itemScript = clickedObject.GetComponent<Item>();
                itemScript?.ItemClicked();          //��Ʒ�����
                break;
            case "Interactive": //����
                var interactiveScript = clickedObject.GetComponent<Interactive>();
                if (holdItem)
                {
                    interactiveScript?.CheckItem(currentItem);
                }
                else
                {
                    interactiveScript?.EmptyClicked();
                }
                break;
        }
    }

    /// <summary>
    /// ���������λ�õ�����Collider
    /// </summary>
    /// <returns>����Collider</returns>
    private Collider2D GetColliderAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);   //������������Collider
    }
}
