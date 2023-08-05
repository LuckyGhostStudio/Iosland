using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private Vector3 mouseWorldPos => Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));

    private bool canClick = false;  //���λ�õĶ����Ƿ���Ե��

    private void Update()
    {
        canClick = GetColliderAtMousePosition();    

        if(canClick && Input.GetMouseButtonDown(0)) //���λ���пɵ����ײ�� && �������
        {
            ClickAction(GetColliderAtMousePosition().gameObject);
        }
    }

    /// <summary>
    /// ���ݱ����������в�ͬ����
    /// </summary>
    /// <param name="clickedObject">���������</param>
    private void ClickAction(GameObject clickedObject)
    {
        switch(clickedObject.tag)
        {
            case "Teleport":
                var teleportScript = clickedObject.GetComponent<Teleport>();
                teleportScript?.TeleportToScene();  //��������
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
