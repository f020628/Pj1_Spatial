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

            Player.Instance.allowed = false;

            Title.Instance.Display(content);
            full = false;
            //sfx ºÈË®
            Invoke(nameof(BlackOut), 1f);
        }
        else
        {
            Title.Instance.Display("Hmm..");
        }
    }

    private void BlackOut()
    {
        GameManager.Instance.Blackout();
    }

}
