using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level4 : MonoBehaviour
{
    private void Update()
    {
        if (!Phone2.picked)
        {
            Debug.Log(123);
            Player.Instance.transform.position = new Vector3(-6.695f, 1.08f, 1.406f);
        }
            Player.Instance.allowed = true;
        
    }
}
