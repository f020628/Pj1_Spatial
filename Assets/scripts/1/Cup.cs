using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup : Item
{
    public bool full = true;
    public override void OnInteract()
    {
        if (full)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
            Title.Instance.Display(content);
            full = false;
        }
        else
        {
            Title.Instance.Display("Hmm..");
        }
    }

}
