using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Item
{
    public static int count = 0;
    public static bool flag = false;
    public Sprite image;
    private bool used = false;
    public Vector3 pos;
    public override void OnInteract()
    {
        if (flag && !used)
        {
            if (count == 2)
            {
                Phone.Instance.count++;
                Phone.Instance.NewMessage();
                flag = false;
            }
            else if (count == 4)
            {
                Phone.Instance.count++;
                Phone.Instance.NewMessage();
                flag = false;
            }
            else if(count == 6)
            {
                Phone.Instance.count++;
                Phone.Instance.NewMessage();
                flag = false;
            }
            count++;
            used = true;
            transform.localPosition = pos;
        }
        else
        {
            Title.Instance.Display("Not now...");
        }
    }

    public override bool OnLook()
    {
        if (flag)
        {
            Title.Instance.image.sprite = image;
            return true;
        }
        return false;
    }
}
