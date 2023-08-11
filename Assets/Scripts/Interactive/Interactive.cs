using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public ItemName requireItem;    //互动需求的物品

    public bool isDone;             //互动是否已完成

    /// <summary>
    /// 检查当前选择的物品是否为互动需求的物品
    /// </summary>
    /// <param name="itemName">当前选择的物品</param>
    public void CheckItem(ItemName itemName)
    {
        if(itemName == requireItem && !isDone)  //是需求物品 互动未结束
        {
            isDone = true;
            //使用物品 从背包移除
            OnClickedAction();
        }
    }

    /// <summary>
    /// 互动对象被点击时的行为：正确时执行
    /// </summary>
    protected virtual void OnClickedAction()
    {

    }

    public virtual void EmptyClicked()
    {
        Debug.Log("空点");
    }
}
