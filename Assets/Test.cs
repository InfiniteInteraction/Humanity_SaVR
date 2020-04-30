using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    [Tooltip("The target to follow")]
    public GameObject target;
    public bool followTarget = true;
    [Tooltip("The speed the object will move at")]
    public float speed = 5f;
    public float stoppingDistance = 0;
    public bool destroyOnCollision = false;
    [Tooltip("How much time (in seconds) must elapse before the object destroys itself, after colliding")]
    public float delay = 0f;
    public bool orbit = false;
    float t = 0;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        speed = 2;
    }
    // Update is called once per frame
    void Update()
    {
        if (followTarget)
        {
            Seek();
            ObstacleAvoidance(target.transform);
        }

        if (orbit)
        {
            Orbit();
        }
    }
    private void Seek()
    {
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance > stoppingDistance)
        {
            Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 12 * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }

    }
    private void Orbit()
    {
        float newX = Mathf.Cos(t);
        float newZ = Mathf.Sin(t);

        transform.position = new Vector3(newX, transform.position.y, newZ);
        t += 0.03f;
    }
    void OnTriggerEnter(Collider collider)
    {
        //Check if destroyOnCollision is enabled and check if collided object is the target. 
        if (destroyOnCollision && collider.gameObject == target.gameObject)
        {
            Debug.Log("Collided with: " + collider.gameObject.name);
            Destroy(gameObject);
        }
    }

    private void ObstacleAvoidance(Transform Target)
    {
        Vector3 dir = (Target.position - transform.position).normalized;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 20))
        {
            if (hit.transform != transform && hit.transform != Target.transform)
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
                dir += hit.normal * 50;
            }
        }

        Vector3 left = transform.position;
        Vector3 right = transform.position;

        left.x -= 2;
        right.x += 2;
        if (Physics.Raycast(left, transform.forward, out hit, 20))
        {
            if (hit.transform != transform && hit.transform != Target.transform)
            {
                Debug.DrawLine(left, hit.point, Color.red);
                dir += hit.normal * 50;

            }
        }

        if (Physics.Raycast(right, transform.forward, out hit, 20))
        {
            if (hit.transform != transform && hit.transform != Target.transform)
            {
                Debug.DrawLine(right, hit.point, Color.red);
                dir += hit.normal * 50;
            }
        }
        Quaternion rot = Quaternion.LookRotation(dir);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime);
        transform.position += transform.forward * 5 * Time.deltaTime;

    }
}
