using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public static Title Instance;
    public Text text;
    public Text environmentTitle;
    public Canvas canvas;

    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(canvas);
        
    }


    Tween tween;
    public void Display(string content)
    {
        tween.Kill();
        text.text = "";
        tween = text.DOText(content, 2).OnComplete(async () => { await Task.Delay(2000); text.text = ""; });
    }
}
