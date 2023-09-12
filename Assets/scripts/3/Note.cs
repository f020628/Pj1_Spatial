using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Note : Item
{
    public static bool flag;
    public TextMeshPro textMeshPro;
    public bool notUsed = true;
    public override void OnInteract()
    {
        if (flag && notUsed)
        {
            Phone.Instance.flag = true;
            Phone.Instance.NewMessage();
            Laptop.Instance.turnOff();
            flag = false;
            notUsed = false;
        }
    }
}
