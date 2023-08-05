using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private bool canClick = false;  //鼠标位置的对象是否可以点击

    private void Update()
    {
        canClick = GetColliderAtMousePosition();    

        if(canClick && Input.GetMouseButtonDown(0)) //鼠标位置有可点击碰撞体 && 左键按下
        {
            ClickAction(GetColliderAtMousePosition().gameObject);
        }
    }

    /// <summary>
    /// 根据被点击对象进行不同操作
    /// </summary>
    /// <param name="clickedObject">被点击物体</param>
    private void ClickAction(GameObject clickedObject)
    {
        switch(clickedObject.tag)
        {
            case "Teleport":
                var teleportScript = clickedObject.GetComponent<Teleport>();
                teleportScript?.TeleportToScene();  //场景传送
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
