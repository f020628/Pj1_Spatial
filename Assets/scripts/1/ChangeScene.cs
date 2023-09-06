using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChangeScene : MonoBehaviour
{
    GameObject player;
    private static bool drop = false;
    private float speed = 0f;
    void Start()
    {
        player = Player.Instance.gameObject;

    }
    private void FixedUpdate()
    {
        if (drop)
        {
            Player.Instance.characterController.Move(speed * Time.deltaTime * Vector3.up);

            speed += Time.deltaTime * 4.8f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Player.Instance.moveFlag = false;
        Player.Instance.rotateFlag = false;
        player.transform.DOMove(transform.position, 1).OnComplete(() => player.transform.DORotate(new Vector3(180, 0, 0), 2, RotateMode.Fast).OnComplete(() => { drop = true; Player.Instance.rotateFlag = true; }));
        
    }

    public static void Stop()
    {
        drop = false;
        GameManager.Instance.LoadNextLevel();
    }
}
