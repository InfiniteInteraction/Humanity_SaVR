using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testfire : MonoBehaviour
{
    #region Public Test Varibles
    public float damage;
    public GameObject player;
    public Transform spawnPoint;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damage = 5;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(spawnPoint.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                hit.collider.GetComponent<Health>().TakeDamage(4);
                Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.Log("Miss");
            }

        }
    }
}

