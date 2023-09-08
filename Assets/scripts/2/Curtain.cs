using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curtain : Item
{
    public GameObject open;
    public static bool flag = false;

    public override void OnInteract()
    {
        if (flag)
        {
            open.SetActive(true);
            gameObject.SetActive(false);
            Cloth.flag = true;
        }
            
        
    }
}
