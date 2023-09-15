using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMODUnity;
using FMOD.Studio;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentScene = 0;
    public RawImage blackout;
    public Volume volume;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(volume);
    }

    public void LoadNextLevel()
    {
        currentScene++;
        Debug.Log(currentScene);
        if(currentScene == 1)
        {
            
            Player.Instance.transform.localScale = new Vector3(1, 0.7f, 1);
        }
        else if(currentScene == 2)
        {
            Level2.DAY.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            Player.Instance.transform.localScale = new Vector3(1, 1, 1);
        }
        else if(currentScene == 3)
        {
            Level3.NIGHT.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            Player.Instance.allowed = false;
        }
        
        Blackout();
        Invoke(nameof(LoadS), 3f);
        
    }

    public void DrinkBlackout()
    {
        blackout.gameObject.SetActive(true);
        var value = blackout.DOColor(Color.black, 3.1f).SetLoops(2, LoopType.Yoyo).OnComplete( () => { blackout.gameObject.SetActive(false); Player.Instance.allowed = true; } );
        Drinking.Instance.Drunk();
    }


    public void Blackout()
    {
        blackout.gameObject.SetActive(true);
        var value = blackout.DOColor(Color.black, 3.1f).SetLoops(2, LoopType.Yoyo).OnComplete(() => { blackout.gameObject.SetActive(false); Player.Instance.allowed = true; });
    }

    public void BlackoutEnd()
    {
        blackout.gameObject.SetActive(true);
        var value = blackout.DOColor(Color.black, 3.1f).OnComplete(() => { Application.Quit(); });
    }

    public void LoadS()
    {
        SceneManager.LoadScene(currentScene);
    }
}
