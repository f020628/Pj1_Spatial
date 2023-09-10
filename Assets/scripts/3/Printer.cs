using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Printer : Item
{
    public static bool flag;
    public GameObject[] papers;
    public Transform[] trans;
    void Start()
    {
        
    }

    public override void OnInteract()
    {
        if (flag)
        {
            Fly();
            Title.Instance.Display("Oh my...");
        }

    }

    public void Fly()
    {
        for(int i = 0; i < papers.Length; i++)
        {
            papers[i].transform.DOMove(trans[i].position,1.5f);
            papers[i].transform.DOShakeRotation(1.5f);
        }
    }

}
