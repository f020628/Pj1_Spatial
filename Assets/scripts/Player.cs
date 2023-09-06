using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;
    public static Player Instance;

    public float speed = 5;
    public bool allowed = true;
    public bool moveFlag = true;
    public bool rotateFlag = true;

    private float xRotation = 0;
    private float yRotation = 0;
    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (allowed)
        {
            if(moveFlag)
                Move();
            if (rotateFlag)
                Rotate();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            Cursor.visible = !Cursor.visible;
            if(Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void FixedUpdate()
    {
    }

    public void Move()
    {
        Vector3 move = new(Input.GetAxis("Horizontal"), -1, Input.GetAxis("Vertical"));
        if (characterController.isGrounded) { move.y = 0; }

        move = transform.rotation * move;
        characterController.Move(speed * Time.deltaTime * move);
    }
    public void Rotate()
    {
        xRotation = Input.GetAxis("Mouse X") * 30 * 0.03f;
        yRotation = -Input.GetAxis("Mouse Y") * 30 * 0.03f;
        
        Vector3 camRotation = new Vector3(yRotation, 0, 0);
        Vector3 bodyRotation = new Vector3(0, xRotation, 0);

        

        CameraControl.Instance.transform.rotation *= Quaternion.Euler(camRotation);
        transform.rotation *= Quaternion.Euler(bodyRotation);

        camRotation = CameraControl.Instance.transform.localRotation.eulerAngles;
        //CameraControl.Instance.transform.localRotation = Quaternion.Euler(new Vector3(Mathf.Clamp(camRotation.x, -75, 75), camRotation.y, camRotation.z));
    } 

    
}
