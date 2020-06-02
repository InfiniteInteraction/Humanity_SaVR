using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cam_Shake : MonoBehaviour
{
    public float power = 0.7f;
    public float duration = 1.07f;
    public Transform Cam;
    public float slowDownAmount = 1.0f;
    public bool shouldShake = false;

    Vector3 startPosition;
    float initialDuration;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main.transform;
        startPosition = Cam.localPosition;
        initialDuration = duration;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldShake)
        {
            if (duration > 0)
            {
                Cam.localPosition = startPosition + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldShake = false;
                duration = initialDuration;
                Cam.localEulerAngles = startPosition;
            }
        }
    }
}
