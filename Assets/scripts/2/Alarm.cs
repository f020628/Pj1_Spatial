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
        tween1 = transform.DOShakePosition(0.3f, 0.1f, 5, 60, false, false).SetLoops(-1);
        tween2 = CameraControl.Instance.characterCam.DOShakePosition(2f, 0.1f, 7, 70, false).SetLoops(-1).OnStepComplete(() => { Title.Instance.DisplayEnvironment("*ring ring ring*"); tween2.Restart(); }) ;
        
    }

    public override void OnInteract()
    {
        tween1.Kill();
        tween2.Kill();
        Title.Instance.DisplayEnvironment("");
        Curtain.flag = true;
    }

}
