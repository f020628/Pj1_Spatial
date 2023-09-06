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
        currentScene++;
        Blackout();
        Invoke(nameof(BlackoutLoad), 3f);
        
    }

    public void Blackout()
    {
        blackout.gameObject.SetActive(true);
        var value = blackout.DOColor(Color.black, 3.1f).SetLoops(2, LoopType.Yoyo).OnComplete( () => { blackout.gameObject.SetActive(false); Player.Instance.allowed = true; Drinking.Instance.Drunk(); } ); 
    }

    public void BlackoutLoad()
    {
        SceneManager.LoadScene(currentScene);
    }
}