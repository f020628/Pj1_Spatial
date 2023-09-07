using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : Item
{
    public static bool flag = false;
    public override void OnInteract()
    {
        if (flag)
        {
            Level2.Instance.WearingCheck();
            Destroy(gameObject);
        }
        
    }
}
