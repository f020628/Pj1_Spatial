using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Basketball.flag = true;
            Bag.flag = true; 
            cap.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 180));
        }
    }
}
