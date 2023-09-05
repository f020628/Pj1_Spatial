using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : Item
{

    Tween tween;
    void Start()
    {
        tween = CameraControl.Instance.characterCam.DOShakeRotation(2, 10, 10, 70, true).SetLoops(-1);
    }

    public override void OnInteract()
    {
        tween.Kill();
    }

}
