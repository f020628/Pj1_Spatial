using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int currentScene = 0;
    public RawImage blackout;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadNextLevel()
    {
        if(currentScene == 0)
        {
            Drinking.Instance.CleanV();
        }
        else if(currentScene == 1)
        {

        }
        else if(currentScene == 2)
        {

        }


        Blackout();
        currentScene++;
        SceneManager.LoadScene(currentScene);
        
    }

    public void Blackout()
    {
        blackout.gameObject.SetActive(true);
        var value = blackout.color.a;
        Tween tween = DOTween.To(() => value, x => value = x, 1f, 2.5f).SetLoops(1, LoopType.Yoyo).OnComplete(()=>blackout.gameObject.SetActive(false));
        
    }
}
