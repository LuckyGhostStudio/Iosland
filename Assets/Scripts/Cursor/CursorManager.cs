using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public RectTransform hand;  //手Transform

    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private ItemName currentItem;   //当前物品

    private bool canClick;  //鼠标位置的对象是否可以点击
    private bool holdItem;  //鼠标是否拿着物品

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

        if (hand.gameObject.activeInHierarchy) hand.position = Input.mousePosition; //手在鼠标位置

        if(canClick && Input.GetMouseButtonDown(0)) //鼠标位置有可点击碰撞体 && 左键按下
        {
            ClickAction(GetColliderAtMousePosition().gameObject);
        }
    }

    private void OnItemUsedEvent(ItemName name)
    {
        currentItem = ItemName.None;
        holdItem = false;
        hand.gameObject.SetActive(false);   //隐藏手
    }

    /// <summary>
    /// 物品被鼠标选中事件处理方法
    /// </summary>
    /// <param name="itemDetails">物品信息</param>
    /// <param name="selected">选中状态</param>
    private void OnItemSelectedEvent(ItemDetails itemDetails, bool selected)
    {
        holdItem = selected;
        if (selected)
        {
            currentItem = itemDetails.name;
        }
        hand.gameObject.SetActive(holdItem);    //设置手的启用状态
    }

    /// <summary>
    /// 根据被点击对象进行不同操作
    /// </summary>
    /// <param name="clickedObject">被点击物体</param>
    private void ClickAction(GameObject clickedObject)
    {
        switch(clickedObject.tag)
        {
            case "Teleport":    //传送
                var teleportScript = clickedObject.GetComponent<Teleport>();
                teleportScript?.TeleportToScene();  //场景传送
                break;
            case "Item":        //物品
                var itemScript = clickedObject.GetComponent<Item>();
                itemScript?.ItemClicked();          //物品被点击
                break;
            case "Interactive": //互动
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
    /// 返回在鼠标位置的物体Collider
    /// </summary>
    /// <returns>物体Collider</returns>
    private Collider2D GetColliderAtMousePosition()
    {
        return Physics2D.OverlapPoint(mouseWorldPos);   //覆盖鼠标坐标的Collider
    }
}
