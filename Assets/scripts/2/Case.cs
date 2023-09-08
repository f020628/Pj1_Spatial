using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Case : Item
{
    public static bool flag;
    public GameObject cap;
    void Start()
    {
        
    }

    public override void OnInteract()
    {
        if (flag)
        {   
            Bag.flag = true; 
            cap.transform.DOLocalRotate(new Vector3(0, 0, 180), 1.5f);
        }
        else if(Pencils.flag)
        {
            Title.Instance.Display("Still something missing.");
        }
    }
}
