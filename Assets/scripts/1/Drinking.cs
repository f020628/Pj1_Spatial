using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Drinking : MonoBehaviour
{
    public bool full = true;
    public Cup cup;
    public static Drinking Instance;
    public GameObject[] bottles;
    private bool[] emptyChecks;
    private int drunkLevel = 0;

    public Volume volume;
    public GameObject bag;
    public Collider shell;

    private bool flag1 = false;
    private bool flag2 = false;
    private float value = 0;
    private void Start()
    {
        Instance = this;
        emptyChecks = new bool[5] { false, false, false, false, false };
    }
    void Update()
    {
        if (flag1)
        {
            ((LensDistortion)volume.profile.components[2]).intensity.SetValue(new FloatParameter(value, true));
        }
        
        if (flag2)
        {
            Vector3 camRotation = new Vector3(rotateX, 0, rotateZ) * Time.deltaTime;
            CameraControl.Instance.transform.rotation *= Quaternion.Euler(camRotation);
        }
        
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
                    Title.Instance.Display("Let's have some more.");
                    bottle.transform.GetChild(0).gameObject.SetActive(false);
                }
                else if (!emptyChecks[i] && cup.full)
                {
                    Title.Instance.Display("Finish what I have got, just like what they say at work.");
                }
                else
                {
                    Title.Instance.Display("It's empty...like my wallet.");
                }
                   
            }
        }    
      
    }

    Tween tween1;
    Tween tween2;
    Tween tween3;
    float rotateX = -2f;
    float rotateZ = -2f;
    public void Drunk()
    {
        Invoke(nameof(Drunk2), 3);
    }

    private void Drunk2()
    {
        drunkLevel++;
        switch (drunkLevel)
        {
            case 1:
                volume.profile.components[1].active = true;
                break;
            case 2:
                volume.profile.components[2].active = true;
                value = -0.3f;
                tween1 = DOTween.To(() => value, x => value = x, 0.4f, 2.5f).SetLoops(-1, LoopType.Yoyo);
                flag1 = true;
                break;
            case 3:
                volume.profile.components[3].active = true;
                break;
            case 4:
                flag2 = true;
                tween2 = DOTween.To(() => rotateX, (x) => rotateX = x, 2f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuint);
                tween3 = DOTween.To(() => rotateZ, (x) => rotateZ = x, 2f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutQuint);
                break;
            case 5:
                volume.profile.components[4].active = true;
                break;
            case 6:
                bag.SetActive(true);
                shell.enabled = false;
                break;
        }
    }

    public void CleanV()
    {
        tween1.Kill();
        tween2.Kill();
        tween3.Kill();
        volume.profile.components[1].active = false;
        volume.profile.components[2].active = false; 
        volume.profile.components[3].active = false;
        volume.profile.components[4].active = false;
        Debug.Log(volume.profile.components[1].active);
    }
}
