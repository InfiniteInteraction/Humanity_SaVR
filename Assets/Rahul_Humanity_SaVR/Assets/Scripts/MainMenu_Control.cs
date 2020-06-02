using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu_Control : MonoBehaviour
{

    public Animator MenuAnim;
    public bool isLoaded = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isLoaded && Input.GetKeyDown(KeyCode.Mouse0))
        {
            MenuAnim.SetTrigger("isPressed");
        }
    }

    public void TitletoMenu()
    {
        isLoaded = true;
    }
}
