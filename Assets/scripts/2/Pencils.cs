using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pencils : Item
{
    public GameObject penCase;
    public static bool flag;
    public Vector3 slot;
    public static int count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void OnInteract()
    {
        if (flag)
        {
            transform.parent = penCase.transform;
            transform.GetComponent<Collider>().enabled = false;
            transform.localPosition = slot;
            count++;
        }
        if(count == 4)
        {
            Case.flag = true;
        }
        
    }
}
