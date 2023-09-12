using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    static int count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/cheer", transform.position);
        if (collision.collider.CompareTag("Basketball"))
        {
            count++;
            Destroy(gameObject);
        }
        if (count == 3)
        {
            Basketball.Instance.transform.DOMove(CameraControl.Instance.transform.position, 1.2f).OnComplete(Fall);
        }
    }

    private void Fall()
    {   
        Player.Instance.allowed = false;
        Title.Instance.DisplayEnvironment("*Punch*",1);
        Player.Instance.transform.DORotate(new Vector3(-90, 90, 0), 0.8f).OnComplete(GameManager.Instance.LoadNextLevel);
    }
}
