using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOff : MonoBehaviour
{

    private Light directionalLight;
    static float t = 0f;
    public Material deathSkybox;

    // Start is called before the first frame update
    void Start()
    {
        directionalLight = GetComponent<Light>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Damage.damage.playerHealth <= 0 && directionalLight.intensity > 0f)
        {
            t += Time.deltaTime;
            directionalLight.intensity = Mathf.Lerp(0.9f, 0.0f, t/5);
            RenderSettings.reflectionIntensity = Mathf.Lerp(1f,0f,t/5);
            //RenderSettings.skybox = deathSkybox;
        }
        else
        {
            Debug.Log("Directional light off");
        }
        
    }
}
