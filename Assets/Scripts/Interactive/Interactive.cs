using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public ItemName requireItem;    //�����������Ʒ

    public bool isDone;             //�����Ƿ������

    /// <summary>
    /// ��鵱ǰѡ�����Ʒ�Ƿ�Ϊ�����������Ʒ
    /// </summary>
    /// <param name="itemName">��ǰѡ�����Ʒ</param>
    public void CheckItem(ItemName itemName)
    {
        if(itemName == requireItem && !isDone)  //��������Ʒ ����δ����
        {
            isDone = true;
            //ʹ����Ʒ �ӱ����Ƴ�
            OnClickedAction();
        }
    }

    /// <summary>
    /// �������󱻵��ʱ����Ϊ����ȷʱִ��
    /// </summary>
    protected virtual void OnClickedAction()
    {

    }

    public virtual void EmptyClicked()
    {
        Debug.Log("�յ�");
    }
}
