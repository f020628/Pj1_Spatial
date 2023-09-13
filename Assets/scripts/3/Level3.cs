using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using FMODUnity;
using FMOD.Studio;
public class Level3 : MonoBehaviour
{
    // Start is called before the first frame update
    public static EventInstance NIGHT;
    void Start()
    {
        NIGHT = RuntimeManager.CreateInstance("event:/day");
        NIGHT.start();
        Player.Instance.allowed = false;
        Player.Instance.transform.position = new Vector3(-0.434f, 0.946f, 0.884f);
        CameraControl.Instance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        CameraControl.Instance.transform.DORotate(new Vector3(-0.434f, 0.946f, 0.884f), 1.5f).OnComplete(()=>{ CameraControl.Instance.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0)); Player.Instance.allowed = true;
            Player.Instance.moveFlag = false; }).SetDelay(2);
    }

    
    void Update()
    {
        
    }
}
