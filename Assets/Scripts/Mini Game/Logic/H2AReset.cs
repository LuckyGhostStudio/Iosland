using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2AReset : Interactive
{
    private Transform gearTransform;    //³İÂÖ

    private void Awake()
    {
        gearTransform = transform.GetChild(0);
    }

    public override void EmptyClicked()
    {
        //ÖØÖÃÓÎÏ·
        GameController.Instance.ResetGame();
        //Ğı×ª³İÂÖ
    }
}
