using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public static CameraControl Instance;
    public GameObject hint;
    public Camera characterCam;
    void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(gameObject);
    }


    private void Update()
    {
        GetTarget();
    }


    private void GetTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2 , Screen.height/2));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 1.9f, 1 << 6))
        {
            //Debug.Log(hit.collider.gameObject.GetComponent<Item>());
            if (hit.collider.gameObject.GetComponent<Item>() != null)
            {
                hint.SetActive(true);
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("interacted");
                    hit.collider.gameObject.GetComponent<Item>().OnInteract();
                }
                if (hit.collider.gameObject.GetComponent<Item>().OnLook())
                {
                    Title.Instance.DisplayImage();
                }
                else { Title.Instance.HideImage(); }
            }
            else
            {
                hint.SetActive(false);
                Title.Instance.HideImage();
            }
        }
        else
        {
            hint.SetActive(false);
            Title.Instance.HideImage();
        }
    }
}
