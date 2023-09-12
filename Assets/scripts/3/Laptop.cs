using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : Item
{
    public static bool on = false;
    public static bool flag = false;
    public Material material;
    public Material onMat;
    void Start()
    {
        
    }

    public override void OnInteract()
    {
        if (flag && !on)
        {
            on = true;
            material = onMat;
            
        }
        else if(flag && on)
        {
            Printer.flag = true;
        }
    }
}
