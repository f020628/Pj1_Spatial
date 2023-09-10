using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : Item
{
    public static bool on = true;
    public static bool flag = false;
    void Start()
    {
        
    }

    public override void OnInteract()
    {
        if (flag)
        {
            Printer.flag = true;
        }
    }
}
