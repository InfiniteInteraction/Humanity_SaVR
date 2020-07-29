using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBullet : MonoBehaviour
{
    GunTest gtScript;
    GunTestVR gtScriptVR;
    Quaternion camRot;
    bool collided = false;
    Transform collisionPos = null;
    Vector3 posOffset = new Vector3(0, 0, -0.1f);
    Rigidbody rb;
    GameManager gmScript;
    ENemyHealth ehScript;

    private void Awake()
    {
        gmScript = FindObjectOfType<GameManager>();
        ehScript = FindObjectOfType<ENemyHealth>();
        rb = GetComponent<Rigidbody>();
        if (FindObjectOfType<GunTest>())
        {
            gtScript = FindObjectOfType<GunTest>();
            gtScriptVR = null;
        }
        if (FindObjectOfType<GunTestVR>())
        {
            gtScriptVR = FindObjectOfType<GunTestVR>();
            gtScript = null;
        }
        if (FindObjectOfType<CameraMovement>())
            camRot = FindObjectOfType<CameraMovement>().gameObject.transform.rotation;

        //StartCoroutine("RecalculateAccuracy");
    }
    private void Start()
    {
        gmScript.shotsFired++;

        if (gtScript)
            transform.rotation = camRot * Quaternion.Euler(0, 90, 0);
    }

    private void FixedUpdate()
    {
        if (!collided)
        {
            BulletGo();
        }
        else
        {
            StartCoroutine("AfterCollision");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collided = true;
        collisionPos = transform;
        //if (GameManager.gameManager.pause.isPaused == false)
        //{
        //    //Debug.LogError("Damage Dealt by Plasma");
        //    if (collision.collider.gameObject.layer.Equals("Alien"))
        //    {
        //        if (gtScript)
        //        {
        //            collision.collider.GetComponent<Health>().TakeDamage(gtScript.damageValue);
        //        }
        //        if (gtScriptVR)
        //        {
        //            collision.collider.GetComponent<Health>().TakeDamage(gtScriptVR.damageValue);

        //        }
        //    }
        //}      
    }

    void BulletGo()
    {
        if (rb)
        {
            rb.AddForce(transform.right * -150);
            //if(gameObject.tag == "PR")
            //{

            //}
            StartCoroutine("Countdown");
        }
    }

    IEnumerator AfterCollision()
    {
        collided = false;
        transform.position += transform.position * 0;
        if (tag.Equals("GreenBullet"))
        {
            GameObject splash = Resources.Load(("Prefabs/GreenSplashEffect"), typeof(GameObject)) as GameObject;
            Instantiate(splash, collisionPos.position + posOffset, Quaternion.identity);
        }
        else
        {
            GameObject splash = Resources.Load(("Prefabs/RedSplashEffect"), typeof(GameObject)) as GameObject;
            Instantiate(splash, collisionPos.position + posOffset, Quaternion.identity);

        }

        Destroy(gameObject.GetComponent<Rigidbody>());
        Destroy(gameObject.GetComponent<BoxCollider>());
        Destroy(gameObject.GetComponentInChildren<ParticleSystem>());
        yield return new WaitForSeconds(0.15f);
        collisionPos = null;
        //Debug.Log("COLLISION");
        Destroy(gameObject);
    }

    IEnumerator Countdown()
    {
        collisionPos = transform;
        yield return new WaitForSeconds(3f);
        //if (tag.Equals("GreenBullet"))
        //{
        //    GameObject splash = Resources.Load(("Prefabs/GreenSplashEffect"), typeof(GameObject)) as GameObject;
        //    //Instantiate(splash, collisionPos.position + posOffset, Quaternion.identity);
        //}
        //else
        //{
        //    GameObject splash = Resources.Load(("Prefabs/RedSplashEffect"), typeof(GameObject)) as GameObject;
        //    //Debug.Log(splash);
        //    //Instantiate(splash, collisionPos.position + posOffset, Quaternion.identity); 
        //}
        collisionPos = null;
        //Debug.Log("TIMED OUT");
        Destroy(gameObject);
    }

    //IEnumerator RecalculateAccuracy()
    //{
    //    yield return new WaitForSeconds(2f);
    //    ehScript.enemyHit = true;
    //    yield return new WaitForSeconds(0.1f);
    //    ehScript.enemyHit = false;
    //}
}