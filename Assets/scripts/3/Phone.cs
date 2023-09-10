using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Phone : Item
{
    public static Phone Instance;
    public bool flag = false;
    private bool hasWord = false;
    private bool reply = false;
    public int count = 0;
    public Material material;
    public TextMesh text;
    void Start()
    {
        Instance = this;
    }

    public override void OnInteract()
    {
        if (flag && !hasWord && !reply)
        {
            switch (count)
            {
                case 0:
                    text.text = "The deadline has been advanced by two days! Prepare materials for the meeting now.";
                    count++;
                    hasWord = true;
                    Laptop.on = true;
                    break;
                case 1:
                    text.text = ("Haven't you finished yet? $%$%#!!$#%..");
                    count++;
                    hasWord = true;
                    break;
                case 2:
                    text.text = ("Your rent &*@$*#@!#@..");
                    count++;
                    hasWord = true;
                    break;
            }
            
        }
        else if(flag && hasWord && !reply)
        {
            hasWord = false;
            reply = true;
            switch(count)
            {
                case 0:
                    text.color = Color.blue;
                    text.text = "No problem.";
                    break;
                case 1:
                    text.color = Color.blue;
                    text.text = "Almost done.";
                    break;
                case 2:
                    text.color = Color.blue;
                    text.text = "Just give me one more day.";
                    break;
            }
        }
        else if (reply)
        {
            text.color = new Vector4(229, 123, 33, 255);
            text.text = "";
            material.DOColor(Color.black, 1);
            reply = false;
            flag = false;
        }

        
    }

    public void NewMessage()
    {
        text.text = "You have a new message";
        material.color = Color.white;
        flag = true;
    }
}
