using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : Item
{
    public static bool on = false;
    public static bool flag = false;
    void Start()
    {
        
    }

    public override void OnInteract()
    {
        if (flag && !on)
        {
            on = true;
            
        }
        else if(flag && on)
        {
            Printer.flag = true;
        }
    }
}
