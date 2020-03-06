using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBall : MonoBehaviour
{
    GameObject green;
    GameObject red;

    GameObject greenBullet;
    GameObject redBullet;

    private void Awake()
    {
        green = GetComponentInChildren<ID_Green>().gameObject;
        red = GetComponentInChildren<ID_Red>().gameObject;
        greenBullet = Resources.Load(("Prefabs/PlasmaBulletGreen"), typeof(GameObject)) as GameObject;
        redBullet = Resources.Load(("Prefabs/PlasmaBulletRed"), typeof(GameObject)) as GameObject;
    }

    private void Start()
    {
        red.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.G) && !green.activeSelf)
        {
            red.SetActive(false);
            green.SetActive(true);
        }
        if (Input.GetKey(KeyCode.R) && !red.activeSelf)
        {
            green.SetActive(false);
            red.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (green.activeSelf)
            {
                Instantiate(greenBullet, new Vector3(0, 0, 0.5f), Quaternion.Euler(90, 0, -90));
            }
            if (red.activeSelf)
            {
                Instantiate(redBullet, new Vector3(0, 0, 0.5f), Quaternion.Euler(90, 0, -90));
            }
        }
    }
}
