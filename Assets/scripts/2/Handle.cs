using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handle : Item
{
    private bool rev = false;
    public static bool flag = false;
    public Sprite image;
    public Sprite backImage;
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
            Reverse();
        }
    }
    public override bool OnLook()
    {
        if (flag)
        {
            Title.Instance.image.sprite = rev ? backImage : image;
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

    float zRotation = 0;
    public void Reverse()
    {
        zRotation = zRotation == 0 ? 180 : 0;
        Player.Instance.allowed = false;
        Vector3 target = new(Player.Instance.transform.rotation.eulerAngles.x, Player.Instance.transform.rotation.eulerAngles.y, zRotation);
        Player.Instance.transform.DOLocalRotate(target, 1, RotateMode.Fast).OnComplete(() => Player.Instance.allowed = true);
    }
}
