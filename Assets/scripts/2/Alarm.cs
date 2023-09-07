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
        tween1 = transform.DOShakePosition(1,1,10,70).SetLoops(-1);
        tween2 = CameraControl.Instance.characterCam.DOShakeRotation(2, 10, 10, 70, true).SetLoops(-1).OnStepComplete(()=> Title.Instance.DisplayEnvironment("*ring ring ring*"));
    }

    public override void OnInteract()
    {
        tween1.Kill();
        tween2.Kill();
        Cloth.flag = true;
    }

}
