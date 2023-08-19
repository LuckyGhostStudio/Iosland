using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "Dialogue/DialogueData")]
public class DialogueData_SO : ScriptableObject
{
    public List<string> dialogueList;   //保存角色所有对话
}
