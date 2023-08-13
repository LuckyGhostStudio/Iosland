using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Dictionary<ItemName, bool> itemAvailableDict = new Dictionary<ItemName, bool>();    //物品名字-是否启用 字典
    private Dictionary<string, bool> interactiveStateDict = new Dictionary<string, bool>();     //互动状态-是否已完成 字典

    private void OnEnable()
    {
        //注册 事件处理函数
        EventHandler.BeforeSceneUnloadEvent += OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent += OnAfterSceneLoadedEvent;
        EventHandler.UpdateUIEvent += OnItemPickedEvent;
    }

    private void OnDisable()
    {
        EventHandler.BeforeSceneUnloadEvent -= OnBeforeSceneUnloadEvent;
        EventHandler.AfterSceneLoadedEvent -= OnAfterSceneLoadedEvent;
        EventHandler.UpdateUIEvent -= OnItemPickedEvent;
    }

    private void OnBeforeSceneUnloadEvent()
    {
        //当前场景中所有Item
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))  //item不存在
            {
                itemAvailableDict.Add(item.itemName, true); //添加item到字典
            }
        }

        //当前场景中所有互动
        foreach (var interactive in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(interactive.name))
            {
                interactiveStateDict[interactive.name] = interactive.isDone;    //保存互动状态
            }
            else
            {
                interactiveStateDict.Add(interactive.name, interactive.isDone); //添加
            }
        }
    }

    private void OnAfterSceneLoadedEvent()
    {
        //当前场景中所有Item
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))  //item不存在
            {
                itemAvailableDict.Add(item.itemName, true); //添加item到字典
            }
            else
            {
                item.gameObject.SetActive(itemAvailableDict[item.itemName]);    //设置item启用状态
            }
        }

        //当前场景中所有互动
        foreach (var interactive in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(interactive.name))
            {
                interactive.isDone = interactiveStateDict[interactive.name];    //设置互动状态
            }
            else
            {
                interactiveStateDict.Add(interactive.name, interactive.isDone); //添加
            }
        }
    }

    /// <summary>
    /// 物品被拾取时处理方法
    /// </summary>
    /// <param name="itemDetails">物品信息</param>
    /// <param name="arg2"></param>
    private void OnItemPickedEvent(ItemDetails itemDetails, int arg2)
    {
        if (itemDetails != null)
        {
            itemAvailableDict[itemDetails.name] = false;    //设置物品状态为false ：已被拾取
        }
    }
}
