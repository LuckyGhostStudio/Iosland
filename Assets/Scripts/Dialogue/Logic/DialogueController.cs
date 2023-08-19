using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    public DialogueData_SO dialogueEmpty;       //没有拿到物品时的对话数据
    public DialogueData_SO dialogueFinish;      //拿到物品时的对话数据

    private Stack<string> dialogueEmptyStack;
    private Stack<string> dialogueFinishStack;

    private bool isTalking;     //是否正在对话

    private void Awake()
    {
        FillDialogueStack();
    }

    /// <summary>
    /// 将对话文本数据入栈
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
    /// 显示没有得到要求物品时的对话
    /// </summary>
    public void ShowDialogueEmpty()
    {
        if (!isTalking)
        {
            StartCoroutine(DialogueRoutine(dialogueEmptyStack));
        }
    }

    /// <summary>
    /// 显示拿到要求物品时的对话
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
        isTalking = true;   //正在对话
        
        if(data.TryPop(out string dialogue))  //获取栈顶元素并移除
        {
            EventHandler.CallShowDialogueEvent(dialogue);   //调用显示对话事件
            yield return null;

            isTalking = false;  //改句对话结束

            EventHandler.CallGameStateChangedEvent(GameState.Pause);    //调用游戏状态改变事件 暂停
        }
        else
        {
            EventHandler.CallShowDialogueEvent(string.Empty);   //对话栈空

            FillDialogueStack();    //对话重新入栈
            isTalking = false;

            EventHandler.CallGameStateChangedEvent(GameState.GamePlay);    //调用游戏状态改变事件 继续
        }
    } 
}
