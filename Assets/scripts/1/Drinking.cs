using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Drinking : MonoBehaviour
{
    public bool full = true;
    public Cup cup;
    public static Drinking Instance;
    public GameObject[] bottles;
    private bool[] emptyChecks;
    private int drunkLevel = 0;

    public Volume volume;
    private void Start()
    {
        Instance = this;
        emptyChecks = new bool[5] { false, false, false, false, false };
    }
    void Update()
    {
        
    }

    public void Refill(GameObject bottle)
    {
        for (int i = 0; i < 5; i++)
        {
            if (bottle == bottles[i])
            {
                if(!emptyChecks[i] && !cup.full)
                {
                    emptyChecks[i] = true;
                    cup.transform.GetChild(1).gameObject.SetActive(true);
                    cup.full = true;
                    Title.Instance.Display("Need some more.");
                    
                    Drunk();
                }
                else if (!emptyChecks[i] && cup.full)
                {
                    Title.Instance.Display("Finish what I have got, just like what they say at work.");
                }
                else
                {
                    Title.Instance.Display("It's empty...so does my wallet.");
                }
                   
            }
        }    
      
    }

    Tween tween1;
    Tween tween2;
    public void Drunk()
    {
        drunkLevel++;
        switch (drunkLevel)
        {
            case 1:
                volume.profile.components[1].active = true;
                break;
            case 2:
                volume.profile.components[2].active = true;
                float value = volume.profile.components[2].parameters[2].GetValue<float>();
                tween1 = DOTween.To(() => value, x => value = x, 0.4f, 2.5f).SetLoops(-1,LoopType.Yoyo);
                break;
            case 3:
                volume.profile.components[3].active = true;
                break;
            case 4:
                Transform x = CameraControl.Instance.transform;
                
                break;
            case 5:
                volume.profile.components[4].active = true;

                break;

        }
    }

    public void CleanV()
    {
        tween1.Kill();
        tween2.Kill();
        volume.profile.components[1].active = false;
        volume.profile.components[2].active = false; 
        volume.profile.components[3].active = false;
        volume.profile.components[4].active = false;

    }
}
