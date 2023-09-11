using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paper : Item
{
    public static int count = 0;
    public static bool flag = false;
    public Sprite image;
    public override void OnInteract()
    {
        if (flag)
        {
            if (count == 2)
            {
                Phone.Instance.count++;
                Phone.Instance.NewMessage();
            }
            else if (count == 4)
            {
                Phone.Instance.count++;
                Phone.Instance.NewMessage();
            }
            else if(count == 6)
            {
                Phone.Instance.count++;
                Phone.Instance.NewMessage();
            }
            count++;
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
