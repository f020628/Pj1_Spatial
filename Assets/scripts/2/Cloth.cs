using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloth : Item
{
    public static bool flag = false;
    public override void OnInteract()
    {
        Debug.Log(flag);
        Level2.Instance.WearingCheck();
        if(flag)
            Destroy(gameObject);
    }
}
