using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone2 : Item
{
    private bool hold = false;
    private bool picked = false;
    public Vector3 pos1;
    public Vector3 pos2;
    public override void OnInteract()
    {
        if (!picked)
        {
            picked = true;
            hold = false;
            transform.parent = Player.Instance.transform;
        }
        
    }
    private void Update()
    {
        if (picked)
        {
            if (hold)
            {
                transform.localPosition = pos2;

            }
            else
            {
                transform.localPosition = pos1;
                
            }
        }
        if(Input.GetMouseButtonDown(0) && picked)
        {
            hold = !hold;
            if (hold)
            {
                transform.localRotation = Quaternion.Euler(-89.2f, 0, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        
    }


}
