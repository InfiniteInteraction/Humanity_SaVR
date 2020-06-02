using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_Turn : MonoBehaviour
{

    public float rotX;
    public float rotY;
    public int RotSpeed;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.Rotate(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rotX += Input.GetAxis("Mouse X") * RotSpeed;
        rotY += Input.GetAxis("Mouse Y") * RotSpeed;

        rotY = Mathf.Clamp(rotY, -90f, 90f);

        //Camera rotation only allowed if game us not paused
        cam.transform.rotation = Quaternion.Euler(-rotY, 0f, 0f);
        transform.rotation = Quaternion.Euler(0f, rotX, 0f);
    }

    //public float speedH = 2.0f;
    //public float speedV = 2.0f;

    //private float yaw = 0.0f;
    //private float pitch = 0.0f;



    //// Use this for initialization
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    yaw += speedH * Input.GetAxis("Mouse X");
    //    pitch -= speedV * Input.GetAxis("Mouse Y");

    //    transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

    //}
}
