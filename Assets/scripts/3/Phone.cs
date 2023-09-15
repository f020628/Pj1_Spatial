using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    public TextMeshPro text;
    public TMP_Text laptopText;
    public Color color;
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
                    TText(text);
                    laptopText.text += "\nReply";
                    count++;
                    hasWord = true;
                    Laptop.Instance.turnOn();
                    flag = false;   
                    break;
                case 1:
                    Debug.Log(flag.ToString() + count.ToString());
                    text.text = ("Haven't you finished yet? $%$%#!!$#%..");
                    TText(text);
                    laptopText.text += "\nReply";
                    count++;
                    hasWord = true;
                    flag = false;
                    break;
                case 2:
                    text.text = ("Your rent &*@$*#@!#@..");
                    TText(text);
                    laptopText.text += "\nReply";
                    count++;
                    hasWord = true;
                    flag = false;
                    break;
               case 3:
                    text.text = ("You are fired.");
                    laptopText.text += "\nError\nError\nError\nError\nError\nError";
                    laptopText.color = Color.red;
                    count++;
                    hasWord = true;
                    Laptop.end = true;
                    Laptop.Instance.turnOn();
                    break;

            }
            
        }
        else if(flag && hasWord && !reply)
        {
            hasWord = false;
            reply = true;
            switch(count)
            {
                case 1:
                    text.color = Color.green;
                    text.text = "No problem.";
                    laptopText.text += "\nSend";
                    break;
                case 2:
                    text.color = Color.green;
                    text.text = "Almost done.";
                    laptopText.text += "\nSend";
                    break;
                case 3:
                    text.color = Color.green;
                    text.text = "Just give me one more day.";
                    laptopText.text += "\nSend";
                    break;
                default:
                    break;
            }
        }
        else if (reply)
        {
            switch (count)
            {
                case 1:
                    laptopText.text += "\nPrint materials for meeting";
                    Printer.flag = true;
                    tween.Kill(true);
                    break;
                case 2:
                    laptopText.text += "\nCollect papers";
                    Paper.flag = true;
                    tween.Kill(true);
                    break;
                case 3:
                    laptopText.text += "\nCollect papers";
                    Paper.flag = true;
                    tween.Kill(true);
                    break;
                default:
                    break;
            }
            tween.Kill();
            text.color = new Vector4(229, 123, 33, 255);
            text.text = "";
            material.DOColor(Color.black, 1);
            reply = false;
            flag = false;
        }

        
    }

    public void NewMessage()
    {
        text.color = color;
        text.text = "You have a new message";
        material.color = Color.white;
        flag = true;

        FMODUnity.RuntimeManager.PlayOneShot("event:/notify", transform.position);
    }

    Tween tween;
    public void TText(TMP_Text content)
    {
        string text = content.text;
        tween = DOTween.To(() => string.Empty, value => content.text = value, text, 2).OnComplete(()=> flag = true);
    }
}
