using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Item
{
    public Vector3 startPos;
    public Vector3 endPos;
    public bool open = false;
    public static bool flag = false;

    public override void OnInteract()
    {
        if (flag)
        {
            Vector3 target = open ? startPos : endPos;
            transform.DOLocalMove(target, 1.5f);
            open = !open;
            FMODUnity.RuntimeManager.PlayOneShot("event:/drawer", transform.position);
        }
        else if(Curtain.flag)
        {
            Title.Instance.Display("Have to put my cloth on.");
        }
    }
}
