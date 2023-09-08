using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : Item
{
    public static bool flag = false;
    public Vector3 playerPos;
    public bool hold = false;
    void Start()
    {

    }

    public override void OnInteract()
    {
        hold = true;

    }

    private void Update()
    {
        if (hold)
        {

            transform.position = CameraControl.Instance.gameObject.transform.position + CameraControl.Instance.gameObject.transform.forward * 0.7f;
            if (Input.GetMouseButtonDown(0))
            {
                transform.GetComponent<Rigidbody>().AddForce(CameraControl.Instance.gameObject.transform.forward * 1f);
                hold = false;
            }
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hold)
        {
            transform.position = playerPos;
            hold = false;
        }
    }
    //public override void OnLook()
    //{
    //    if (flag && Input.GetMouseButton(0))
    //    {
    //        Player.Instance.moveFlag = false;
    //        Player.Instance.transform.position = playerPos;

    //        Player.Instance.transform.localRotation = Quaternion.Euler(0, 90, 0);
    //    }
    //    else if(flag && Input.GetMouseButtonUp(0))
    //    {
    //        Player.Instance.moveFlag = true;
    //        transform.GetComponent<Rigidbody>().AddForce(CameraControl.Instance.gameObject.transform.forward * 1f);
    //    }
    //}
}
