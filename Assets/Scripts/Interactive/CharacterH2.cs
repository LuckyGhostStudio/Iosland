using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueController))]
public class CharacterH2 : Interactive
{
    private DialogueController dialogueController;  //对话控制器

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    public override void EmptyClicked()
    {
        if (isDone) //互动已完成
        {
            dialogueController.ShowDialogueFinish();    //显示有要求物品的对话
        }
        else
        {
            dialogueController.ShowDialogueEmpty();     //显示没有要求物品的对话
        }
    }

    protected override void OnClickedAction()
    {
        dialogueController.ShowDialogueFinish();    //显示有要求物品的对话
    }
}
