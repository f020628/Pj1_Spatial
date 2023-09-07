using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawer : Item
{
    public Transform startPos;
    public Transform endPos;
    public bool open = false;

    public override void OnInteract()
    {
        Vector3 target = open ? endPos.position : startPos.position;
        transform.DOMove(target, 1.5f);
        open = !open;
    }
}
