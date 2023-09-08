using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Item : MonoBehaviour
{
    public string itemName = "N/A";

    public string content = "Interacted";
    public virtual void OnInteract()
    {
        Title.Instance.Display(content);
    }

    public virtual bool OnLook()
    {
        return false;
    }
}
