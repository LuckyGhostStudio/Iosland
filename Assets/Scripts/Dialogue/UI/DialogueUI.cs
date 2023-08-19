using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public GameObject panel;    //�Ի���Panel
    public Text dialogueText;   //�Ի�Text

    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += ShowDialogue;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= ShowDialogue;
    }

    /// <summary>
    /// ��ʾ�Ի�
    /// </summary>
    /// <param name="dialogue">Ҫ��ʾ�ĶԻ�</param>
    private void ShowDialogue(string dialogue)
    {
        panel.SetActive(dialogue != string.Empty);  //���öԻ�panel����״̬
        dialogueText.text = dialogue;               //��ʾ�Ի�
    }
}
