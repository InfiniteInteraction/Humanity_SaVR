using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public int pelletCount; //Amount of pellets fired
    public float spreadAngle;
    public GameObject pellet;//bulletPrefab
    public float pelletFireVel = 1;
    public Transform BulletSpawn;
    List<Quaternion> pellets;

     void Awake()
    {
        pellets = new List<Quaternion>(pelletCount);
        for(int i = 0; i<pelletCount; i++)
        {
            pellets.Add(Quaternion.Euler(Vector3.zero));//EmptySlot
        }

    }
  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown ("Fire1"))
        {
            Fire();
        }
    }
    void Fire()
    {
        /*int i = 0;
       foreach (Quaternion quat in pellets)*/
       for (int i = 0; i< pelletCount; i++)

        pellets[i] = Random.rotation;
        GameObject p = Instantiate(pellet, BulletSpawn.position, BulletSpawn.rotation);

        p.transform.rotation = Quaternion.RotateTowards(p.transform.rotation, pellets[i], spreadAngle);
        p.GetComponent<Rigidbody>().AddForce(p.transform.right * pelletFireVel);

          // i++;

    }

}
