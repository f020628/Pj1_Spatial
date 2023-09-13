using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sketch : Item
{
    public Sprite image;
    public override bool OnLook()
    {
        Title.Instance.image.sprite = image;
        return true;
    }
}
