using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DialogueController))]
public class CharacterH2 : Interactive
{
    private DialogueController dialogueController;  //�Ի�������

    private void Awake()
    {
        dialogueController = GetComponent<DialogueController>();
    }

    public override void EmptyClicked()
    {
        if (isDone) //���������
        {
            dialogueController.ShowDialogueFinish();    //��ʾ��Ҫ����Ʒ�ĶԻ�
        }
        else
        {
            dialogueController.ShowDialogueEmpty();     //��ʾû��Ҫ����Ʒ�ĶԻ�
        }
    }

    protected override void OnClickedAction()
    {
        dialogueController.ShowDialogueFinish();    //��ʾ��Ҫ����Ʒ�ĶԻ�
    }
}
