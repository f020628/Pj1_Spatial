using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
public class Alarm2 : Item
{
    Tween tween1;
    Tween tween2;
    EventInstance myEventInstance1;
    void Start()
    {
        myEventInstance1 = RuntimeManager.CreateInstance("event:/alarm_dig");
        myEventInstance1.start();
        tween1 = transform.DOShakePosition(0.5f, 0.5f, 10, 60, false, false).SetLoops(-1);
        tween2 = CameraControl.Instance.characterCam.DOShakePosition(0.4f, 0.05f, 4, 60, false).SetLoops(-1).OnStepComplete(() => { Title.Instance.DisplayEnvironment("*Beep Beep*", 0.4f); tween2.Restart();
        
        });

    }

    public override void OnInteract()
    {
        tween1.Kill();
        tween2.Kill();
        Title.Instance.DisplayEnvironment("",0);
        Laptop.flag = true;
        transform.localPosition = new Vector3(-3.408913f, 3.08f, -3.118796f);
        myEventInstance1.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        
    }
}
