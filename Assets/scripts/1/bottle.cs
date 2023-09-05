using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottle : Item
{

    public override void OnInteract()
    {
        Drinking.Instance.Refill(gameObject);
    }
}
