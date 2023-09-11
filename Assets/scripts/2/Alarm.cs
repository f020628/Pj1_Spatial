using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : Item
{

    Tween tween1;
    Tween tween2;

    void Start()
    {
        tween1 = transform.DOShakePosition(0.2f, 0.07f, 7, 60, false, false).SetLoops(-1);
        tween2 = CameraControl.Instance.characterCam.DOShakePosition(0.4f, 0.03f, 4, 60, false).SetLoops(-1).OnStepComplete(() => { Title.Instance.DisplayEnvironment("*ring ring ring*", 0.4f); tween2.Restart(); }) ;
        
    }

    public override void OnInteract()
    {
        tween1.Kill();
        tween2.Kill();
        Title.Instance.DisplayEnvironment("",0);
        Curtain.flag = true;
    }

}
