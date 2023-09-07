using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    [HideInInspector]
    public static Level2 Instance;
    [HideInInspector]
    public int wearing = 0;
    [HideInInspector]
    public GameObject player;

    public Light pointLight;
    public Light pointLight2;
    public void Awake()
    {
        player = Player.Instance.gameObject;
        Instance = this;
    }

    void Start()
    {
        Player.Instance.transform.SetPositionAndRotation(new Vector3(-3.14f, 1.14f, -1.58f), Quaternion.Euler(new Vector3(0, 90, -91.2f)));
        Player.Instance.moveFlag = false;
        player.transform.DORotate(new Vector3(0, 90, 0), 2).OnComplete(() => { Player.Instance.moveFlag = true; }).SetDelay(2);
    }

    void Update()
    {
        
    }

    public void WearingCheck()
    {
        
        if(Cloth.flag == false)
        {
            Title.Instance.Display("It's too dark");
        }
        else if(wearing != 4)
        {
            Title.Instance.Display("Still something missing.");
            wearing++;
        }
        else
        {
            Title.Instance.DisplayEnvironment("Pack your bag, hurry up!");
            Drawer.flag = true;
        }
    }

    //public void LightOn()
    //{
    //    pointLight.gameObject.SetActive(true);
    //    pointLight2.gameObject.SetActive(true);
    //}
}
