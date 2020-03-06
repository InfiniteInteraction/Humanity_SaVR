using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public Camera eyes;
    float moveFB;
    float moveLR;
    float mouseX;
    float mouseY;
    CharacterController controller;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();       
    }

    // Update is called once per frame
    void Update()
    {
        //// get input data from keyboard or controller
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        //// update player position based on input
        //Vector3 position = transform.position;
        //position.x += moveHorizontal * speed * Time.deltaTime;
        //position.z += moveVertical * speed * Time.deltaTime;
        //transform.position = position;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        moveFB = Input.GetAxis("Vertical");
        moveLR = Input.GetAxis("Horizontal");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    }
}