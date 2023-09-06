using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : Item
{
    public override void OnInteract()
    {
        Drinking.Instance.Refill(gameObject);
    }
}
