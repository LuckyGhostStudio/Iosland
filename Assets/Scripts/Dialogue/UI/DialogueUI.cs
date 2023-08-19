using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    public GameObject panel;    //对话框Panel
    public Text dialogueText;   //对话Text

    private void OnEnable()
    {
        EventHandler.ShowDialogueEvent += ShowDialogue;
    }

    private void OnDisable()
    {
        EventHandler.ShowDialogueEvent -= ShowDialogue;
    }

    /// <summary>
    /// 显示对话
    /// </summary>
    /// <param name="dialogue">要显示的对话</param>
    private void ShowDialogue(string dialogue)
    {
        panel.SetActive(dialogue != string.Empty);  //设置对话panel启用状态
        dialogueText.text = dialogue;               //显示对话
    }
}
