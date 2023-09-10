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
    public Image image;
    public Canvas canvas;
    public Color color;
    void Awake()
    {   
        color = text.color;
        Instance = this;
        DontDestroyOnLoad(canvas);
        
    }


    Tween tween;
    public Tween tween2;
    public void Display(string content)
    {
        tween.Kill();
        text.text = "";
        tween = text.DOText(content, 2).OnComplete(async () => { await Task.Delay(2000); text.text = ""; });
    }

    public void DisplayEnvironment(string content)
    {
        tween2.Kill();
        environmentTitle.text = "";
        tween2 = environmentTitle.DOText(content, 2).OnComplete(async () => { await Task.Delay(2500);environmentTitle.text = ""; });
    }

    public void DisplayImage()
    {
        image.gameObject.SetActive(true);
    }

    public void HideImage()
    {
        image.gameObject.SetActive(false);
    }
}
