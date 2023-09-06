using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cap : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(123);
        ChangeScene.Stop();
    }
}
