using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2AReset : Interactive
{
    private Transform gearTransform;    //����

    private void Awake()
    {
        gearTransform = transform.GetChild(0);
    }

    public override void EmptyClicked()
    {
        //������Ϸ
        GameController.Instance.ResetGame();
        //��ת����
    }
}
