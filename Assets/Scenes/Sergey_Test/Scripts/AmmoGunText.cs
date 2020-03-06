using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoGunText : MonoBehaviour
{
    GunTestVR gtScriptVR;
    GunTest gtScript;
    Material numMat;

    private void Awake()
    {
        if (gtScriptVR = FindObjectOfType<GunTestVR>())
            gtScriptVR = FindObjectOfType<GunTestVR>();
        if (gtScript = FindObjectOfType<GunTest>())
            gtScript = FindObjectOfType<GunTest>();
        numMat = GetComponent<Renderer>().material;
        gtScriptVR.ammoChanged = true;
    }
    private void FixedUpdate()
    {
        if (gtScriptVR.ammoChanged)
        {
            int ag = gtScriptVR.currAmmo;
            int ag1 = ag / 100;
            int ag1to2 = ag - ag1 * 100;
            int ag2 = ag1to2 / 10;
            int ag3 = ag % 10;

            if (name.Equals("Digit1"))
            {
                numMat = Resources.Load(("Materials/NumsT/" + ag1), typeof(Material)) as Material;
            }
            if (name.Equals("Digit2"))
            {
                numMat = Resources.Load(("Materials/NumsT/" + ag2), typeof(Material)) as Material;
            }
            if (name.Equals("Digit3"))
            {
                numMat = Resources.Load(("Materials/NumsT/" + ag3), typeof(Material)) as Material;
            }
            GetComponent<Renderer>().material = numMat;
            StartCoroutine("Wait");
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForEndOfFrame();
        gtScriptVR.ammoChanged = false;
    }
}
