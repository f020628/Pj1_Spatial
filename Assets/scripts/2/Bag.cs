using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : Item
{
    public static bool flag = false;

    void Start()
    {
        
    }

    public override void OnInteract()
    {
        if (flag)
        {
            Title.Instance.Display("Won't miss my daily shooting practice.");
        }
        else if(Drawer.flag)
        {
            Title.Instance.Display("I need my pencil case.");
        }
    }
}
