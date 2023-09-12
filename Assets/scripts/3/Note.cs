using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : Item
{
    public static bool flag;
    public override void OnInteract()
    {
        if (flag)
        {
            Phone.Instance.NewMessage();
        }
    }
}
