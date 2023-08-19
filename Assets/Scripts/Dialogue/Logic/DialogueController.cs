using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueData_SO dialogueEmpty;       //û���õ���Ʒʱ�ĶԻ�����
    public DialogueData_SO dialogueFinish;      //�õ���Ʒʱ�ĶԻ�����

    private Stack<string> dialogueEmptyStack;
    private Stack<string> dialogueFinishStack;

    private bool isTalking;     //�Ƿ����ڶԻ�

    private void Awake()
    {
        FillDialogueStack();
    }

    /// <summary>
    /// ���Ի��ı�������ջ
    /// </summary>
    private void FillDialogueStack()
    {
        dialogueEmptyStack = new Stack<string>();
        dialogueFinishStack = new Stack<string>();

        for (int i = dialogueEmpty.dialogueList.Count - 1; i >= 0; i--)
        {
            dialogueEmptyStack.Push(dialogueEmpty.dialogueList[i]);
        }

        for (int i = dialogueFinish.dialogueList.Count - 1; i >= 0; i--)
        {
            dialogueFinishStack.Push(dialogueFinish.dialogueList[i]);
        }
    }

    /// <summary>
    /// ��ʾû�еõ�Ҫ����Ʒʱ�ĶԻ�
    /// </summary>
    public void ShowDialogueEmpty()
    {
        if (!isTalking)
        {
            StartCoroutine(DialogueRoutine(dialogueEmptyStack));
        }
    }

    /// <summary>
    /// ��ʾ�õ�Ҫ����Ʒʱ�ĶԻ�
    /// </summary>
    public void ShowDialogueFinish()
    {
        if (!isTalking)
        {
            StartCoroutine(DialogueRoutine(dialogueFinishStack));
        }
    }

    private IEnumerator DialogueRoutine(Stack<string> data)
    {
        isTalking = true;   //���ڶԻ�
        
        if(data.TryPop(out string dialogue))  //��ȡջ��Ԫ�ز��Ƴ�
        {
            EventHandler.CallShowDialogueEvent(dialogue);   //������ʾ�Ի��¼�
            yield return null;

            isTalking = false;  //�ľ�Ի�����

            EventHandler.CallGameStateChangedEvent(GameState.Pause);    //������Ϸ״̬�ı��¼� ��ͣ
        }
        else
        {
            EventHandler.CallShowDialogueEvent(string.Empty);   //�Ի�ջ��

            FillDialogueStack();    //�Ի�������ջ
            isTalking = false;

            EventHandler.CallGameStateChangedEvent(GameState.GamePlay);    //������Ϸ״̬�ı��¼� ����
        }
    } 
}
