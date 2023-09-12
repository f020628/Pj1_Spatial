using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;
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
            FMODUnity.RuntimeManager.PlayOneShot("event:/drink", transform.position);
            Invoke(nameof(BlackOut), 1f);
        }
        else
        {
            Title.Instance.Display("Hmm..");
        }
    }

    private void BlackOut()
    {
        GameManager.Instance.DrinkBlackout();
    }

}
