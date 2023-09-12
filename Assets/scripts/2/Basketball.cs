using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basketball : Item
{
    public static Basketball Instance;
    public static bool flag = false;
    public Vector3 playerPos;
    public bool hold = false;
    void Start()
    {
        Instance = this;
    }

    public override void OnInteract()
    {
        if (flag)
        {
            if (hold)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if(Player.Instance.transform.position.x <= -1)
                    {
                        transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                        transform.GetComponent<Rigidbody>().AddForce(CameraControl.Instance.gameObject.transform.forward * 140f);
                        hold = false;
                        FMODUnity.RuntimeManager.PlayOneShot("event:/shootBasket", transform.position); 
                    }
                    else
                    {
                        Title.Instance.Display("Why not make a long shot?");
                    }
                }
            }
            else
            {
                hold = true;
            }
            
        }

    }

    private void Update()
    {
        if (hold)
        {

            transform.position = CameraControl.Instance.gameObject.transform.position + CameraControl.Instance.gameObject.transform.forward * 0.7f;
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hold && !collision.gameObject.CompareTag("Player"))
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
