using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    private Dictionary<ItemName, bool> itemAvailableDict = new Dictionary<ItemName, bool>();    //��Ʒ����-�Ƿ����� �ֵ�
    private Dictionary<string, bool> interactiveStateDict = new Dictionary<string, bool>();     //����״̬-�Ƿ������ �ֵ�

    private void OnEnable()
    {
        //ע�� �¼�������
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
        //��ǰ����������Item
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))  //item������
            {
                itemAvailableDict.Add(item.itemName, true); //���item���ֵ�
            }
        }

        //��ǰ���������л���
        foreach (var interactive in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(interactive.name))
            {
                interactiveStateDict[interactive.name] = interactive.isDone;    //���滥��״̬
            }
            else
            {
                interactiveStateDict.Add(interactive.name, interactive.isDone); //���
            }
        }
    }

    private void OnAfterSceneLoadedEvent()
    {
        //��ǰ����������Item
        foreach (var item in FindObjectsOfType<Item>())
        {
            if (!itemAvailableDict.ContainsKey(item.itemName))  //item������
            {
                itemAvailableDict.Add(item.itemName, true); //���item���ֵ�
            }
            else
            {
                item.gameObject.SetActive(itemAvailableDict[item.itemName]);    //����item����״̬
            }
        }

        //��ǰ���������л���
        foreach (var interactive in FindObjectsOfType<Interactive>())
        {
            if (interactiveStateDict.ContainsKey(interactive.name))
            {
                interactive.isDone = interactiveStateDict[interactive.name];    //���û���״̬
            }
            else
            {
                interactiveStateDict.Add(interactive.name, interactive.isDone); //���
            }
        }
    }

    /// <summary>
    /// ��Ʒ��ʰȡʱ������
    /// </summary>
    /// <param name="itemDetails">��Ʒ��Ϣ</param>
    /// <param name="arg2"></param>
    private void OnItemPickedEvent(ItemDetails itemDetails, int arg2)
    {
        if (itemDetails != null)
        {
            itemAvailableDict[itemDetails.name] = false;    //������Ʒ״̬Ϊfalse ���ѱ�ʰȡ
        }
    }
}
