using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laptop : Item
{
    public static Laptop Instance;
    public static bool on = false;
    public static bool flag = false;
    public GameObject screen;
    public Material onMat;
    public Material offMat;
    public static bool end = false;
    private void Awake()
    {
        Instance= this;
    }

    public override void OnInteract()
    {
        if (flag && !on && !end)
        {
            Note.flag = true;
            turnOn();
            Player.Instance.moveFlag = true;
        }
        else if (flag && on &&!end)
        {
            turnOff();
        }
        if (end)
        {
            GameManager.Instance.LoadNextLevel();
        }
    }

    public void turnOff()
    {
        on = false;
        screen.GetComponent<Renderer>().material = offMat;
    }

    public void turnOn()
    {
        on = true;
        screen.GetComponent<Renderer>().material = onMat;
    }

}
