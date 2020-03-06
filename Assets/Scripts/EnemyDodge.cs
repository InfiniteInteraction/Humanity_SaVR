using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDodge : EnemyMovement
{
    public float speed;
    public float xRange;
    public float yRange;
    public float zRange;

    public float rate;
    private float teleportTimer = 2;

    [SerializeField]
    bool canTeleport = true;


    void Start()
    {
        //player = GameObject.Find("OfficialPlayerMesh").transform;
        transform.LookAt(Camera.main.transform);
        rate = teleportTimer;
    }
    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (!canTeleport)
        {

            rate -= 1 * Time.deltaTime;
            if (rate <= 0)
            {
                canTeleport = true;
                rate = teleportTimer;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TeleportEnemy();
        }
    }

    void TeleportEnemy()
    {
        //Random.Range()
        //player = GameObject.Find("OfficialPlayerMesh").transform;
        if (canTeleport)
        {
            
            float newX = Random.Range(-xRange, xRange);
            float newY = Random.Range(0, yRange);
            float newZ = Random.Range(-zRange, zRange);

            transform.position = new Vector3(newX, newY, newZ);

            transform.LookAt(Camera.main.transform);

            canTeleport = false;
        }
    }
}
