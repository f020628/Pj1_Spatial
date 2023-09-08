using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : Item
{
    private bool rev = false;
    public static bool flag = false;
    public Sprite image;
    private bool drop = false;
    void Update()
    {
        if (flag && drop)
        {
            float dir = rev ? 2 : -2;
            transform.position += Time.deltaTime * new Vector3(0, dir, 0);
        }
    }

    public override void OnInteract()
    {
        if (flag)
        {
            drop = true;
            rev = !rev;
            Level2.Instance.Reverse();
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

    public void OnCollisionEnter(Collision collision)
    {
        drop = false;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
