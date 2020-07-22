using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GunTestVR : MonoBehaviour
{
    public static GunTestVR gunTestVR;

    public Transform spawnPoint; //Point the raycast will originate from
    public LayerMask layerMask; //The layer mask that detects enemy
    public float damageValue = 0;
    [Header("Ammo")]
    public int currAmmo;
    public int maxAmmo;
    public int ammoReturn = 3;
    [Header("Weapon Firing")]
    public bool canShoot = true;
    public bool fullAutoMode = false;
    public bool ammoChanged = false;
    bool rifleTrigger = false;
    public float currTime = 0;
    public float shootTime = 0;
    public float fullAutoTime;
    public float semiAutoTime = 0;
    public float rifleCharging;

    public bool isGreenFireMode;
    public GameObject redBullet;
    public GameObject greenBullet;

    public GameObject green;
    public GameObject red;
    //GameObject redRailgunBullet;
    //GameObject greenRailgunBullet;
    //GameObject greenPistolBullet;
    //GameObject redPistolBullet;
    //GameObject greenRifleBullet;
    //GameObject redRifleBullet;
    //GameObject waveBullet;
    public List<GameObject> emissiveObjects = new List<GameObject>();
    public Animator wheelSpin;
    //AudioSource audioSource;
    //AudioClip pistolShot;

    public Sprite WeapIcon;

    private void Awake()
    {
        gunTestVR = this;
        green = GetComponentInChildren<ID_Green>().gameObject;
        if (green != null)
        {
            //Debug.Log("green is found.");
            green.SetActive(false);
        }

        red = GetComponentInChildren<ID_Red>().gameObject;
        if (red != null)
        {
            //Debug.Log("red in GunTestVR found.");
            red.SetActive(true);
        }
        //greenPistolBullet = Resources.Load(("Prefabs/PlasmaBulletGreen"), typeof(GameObject)) as GameObject;
        ////greenPistolBullet = Resources.Load(("Prefabs/LaserBulletGreen"), typeof(GameObject)) as GameObject;
        //redPistolBullet = Resources.Load(("Prefabs/PlasmaBulletRed"), typeof(GameObject)) as GameObject;
        ////redPistolBullet = Resources.Load(("Prefabs/LaserBulletRed"), typeof(GameObject)) as GameObject;
        //greenRifleBullet = Resources.Load(("Prefabs/GreenRifleBullet"), typeof(GameObject)) as GameObject;
        //redRifleBullet = Resources.Load(("Prefabs/RedRifleBullet"), typeof(GameObject)) as GameObject;
        ////redRailgunBullet = Resources.Load(("Prefabs/LaserBulletRed), typeof(GameObject)) as GameObject;
        //redRailgunBullet = Resources.Load(("Prefabs/RailgunBulletRed"), typeof(GameObject)) as GameObject;
        ////greenRailgunBullet = Resources.Load(("Prefabs/LaserBulletRed), typeof(GameObject)) as GameObject;
        //greenRailgunBullet = Resources.Load(("Prefabs/RailgunBulletGreen"), typeof(GameObject)) as GameObject;
        fullAutoTime = 0.1f;
        wheelSpin = gameObject.GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
        //pistolShot = Resources.Load(("SFX/Pistol_Shot"), typeof(AudioClip)) as AudioClip;

    }

    void Start()
    {
        damageValue = 2;
        //green.SetActive(false);
        if (gameObject.name.Equals("PlasmaRifleVR"))
        {
            damageValue = 4;
            foreach (GameObject detail in emissiveObjects)
            {
                detail.GetComponent<Renderer>().material = Resources.Load(("Materials/PlasmaRifleBarrelEmissionRed"), typeof(Material)) as Material;
            }

            redBullet = Resources.Load(("Prefabs/Rifle_BulletRed"), typeof(GameObject)) as GameObject;
            greenBullet = Resources.Load(("Prefabs/GreenRifleBullet"), typeof(GameObject)) as GameObject;
        }
        if (gameObject.name.Equals("RailGun_Chris"))
        {
            damageValue = 4;
            GetComponent<Renderer>().material = Resources.Load(("Materials/RailGunChris_MatR"), typeof(Material)) as Material;

            redBullet = Resources.Load(("Prefabs/RailgunBulletRed"), typeof(GameObject)) as GameObject;
            greenBullet = Resources.Load(("Prefabs/RailgunBulletGreen"), typeof(GameObject)) as GameObject;
        }
        if (gameObject.name.Equals("TommyGun"))
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Renderer>().material = Resources.Load(("Materials/TommyGunR"), typeof(Material)) as Material;
            }

            redBullet = Resources.Load(("Prefabs/TommyGunBulletRed"), typeof(GameObject)) as GameObject;
            greenBullet = Resources.Load(("Prefabs/TommyGunBulletGreen"), typeof(GameObject)) as GameObject;

        }
        if (gameObject.name.Equals("Musket_DuskSky"))
        {
            damageValue = 4;
            redBullet = Resources.Load(("Prefabs/RailgunBulletRed"), typeof(GameObject)) as GameObject;
            greenBullet = Resources.Load(("Prefabs/RailgunBulletGreen"), typeof(GameObject)) as GameObject;
        }
        if (gameObject.name.Equals("Pistola22_green"))
        {

            redBullet = Resources.Load(("Prefabs/LaserBulletRed"), typeof(GameObject)) as GameObject;
            greenBullet = Resources.Load(("Prefabs/LaserBulletGreen"), typeof(GameObject)) as GameObject;
        }
        if (gameObject.name.Equals("PlasmaGunVR") || gameObject.name.Equals("FNXScifi_Low"))
        {

            redBullet = Resources.Load(("Prefabs/PlasmaBulletRed"), typeof(GameObject)) as GameObject;
            greenBullet = Resources.Load(("Prefabs/PlasmaBulletGreen"), typeof(GameObject)) as GameObject;
        }
        if (gameObject.name.Equals("Rifleobj_green"))
        {

            redBullet = Resources.Load(("Prefabs/Rifle_BulletRed"), typeof(GameObject)) as GameObject;
            greenBullet = Resources.Load(("Prefabs/Rifle_GreenRifleBullet"), typeof(GameObject)) as GameObject;
        }
        if (gameObject.name.Equals("syfy_shotgun"))
        {
            damageValue = 4;
            redBullet = Resources.Load(("Prefabs/syfy_shotgunBulletRed"), typeof(GameObject)) as GameObject;
            greenBullet = Resources.Load(("Prefabs/syfy_shotgunBulletGreen"), typeof(GameObject)) as GameObject;
        }

    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    WeaponShoot();
        //}
        string Actscene = FindObjectOfType<WeaponSwitch>().Actscene;
        if (Actscene != "WeapSelect")
        {
            if (gameObject.name.Equals("PlasmaRifleVR"))
            {
                if (rifleTrigger)
                    Timer();
                float triggerPress;
                triggerPress = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
                if (triggerPress >= 0.95f && !rifleTrigger)
                {
                    rifleTrigger = true;
                    StartCoroutine("RifleWheelGo");
                }
                if (triggerPress <= 0.05f && rifleTrigger)
                {
                    rifleTrigger = false;
                    StartCoroutine("RifleWheelStop");
                }
            }
            if ((gameObject.name.Equals("Rifle obj_green") || gameObject.name.Equals("TommyGun") || gameObject.name.Equals("FNXScifi_Low")) && !fullAutoMode)
            {
                fullAutoMode = true;
            }
            else
            {
                if (fullAutoMode)
                {
                    if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && canShoot && currAmmo > 0)
                    {
                        StartCoroutine("AutoShot");
                    }
                }
                else
                {
                    if ((OVRInput.Get(OVRInput.RawButton.RIndexTrigger)) && canShoot && currAmmo > 0)
                    {
                        StartCoroutine("OneShot");
                        return;
                    }
                    else if ((OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)) && !canShoot)
                    {
                        canShoot = true;
                        return;
                    }
                    //if ((OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger)) && canShoot && currAmmo > 0)
                    //{
                    //    StartCoroutine("OneShot");
                    //    return;
                    //}
                    //if ((OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger)) && !canShoot)
                    //{
                    //    canShoot = true;
                    //    return;

                    //}
                }
            }

            if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger) && currAmmo <= 0)
            {
                Debug.Log("Out of Ammo");
                Audiomanager.audiomanager.Play("OutOfAmmo");
            }

            if (OVRInput.GetDown(OVRInput.RawButton.B))
            {
                SwitchBullets();
                if (isGreenFireMode == false)
                {
                    isGreenFireMode = true;
                }
                else
                {
                    isGreenFireMode = false;
                }

            }
        }
    }


    void ReduceAmmo()
    {
        currAmmo--;
        currAmmo = Mathf.Clamp(currAmmo, 0, maxAmmo);
        //ammoChanged = true;
    }

    public void RegainAmmo()
    {
        currAmmo = maxAmmo;
        currAmmo = Mathf.Clamp(currAmmo, 0, maxAmmo);
        //ammoChanged = true;
    }

    //void SwitchFireMode()
    //{
    //    fullAutoMode = !fullAutoMode;
    //    if (fullAutoMode == true)
    //    {
    //        shootTime = fullAutoTime;
    //    }
    //    else
    //    {
    //        shootTime = semiAutoTime;
    //    }
    //}

    void SwitchBullets()
    {
        if (!green.activeSelf)
        {
            red.SetActive(false);
            green.SetActive(true);
            if (gameObject.name.Equals("PlasmaRifleVR"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    detail.GetComponent<Renderer>().material = Resources.Load(("Materials/PlasmaRifleBarrelEmissionGreen"), typeof(Material)) as Material;
                }
            }
            if (gameObject.name.Equals("RailGun_Chris"))
            {
                GetComponent<Renderer>().material = Resources.Load(("Materials/RailGunChris_MatG"), typeof(Material)) as Material;
            }
            if (gameObject.name.Equals("TommyGun"))
            {
                foreach (Transform child in transform)
                {
                    child.GetComponent<Renderer>().material = Resources.Load(("Materials/TommyGunG"), typeof(Material)) as Material;
                }
            }
            if (gameObject.name.Equals("syfy_shotgun"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    Material[] mats = detail.GetComponent<Renderer>().materials;
                    Material temp = Resources.Load(("Materials/Mat_plazmaColor_green"), typeof(Material)) as Material;
                    mats[1] = temp;
                    detail.GetComponent<Renderer>().materials = mats;
                    //detail.GetComponent<Renderer>().material = Resources.Load(("Weapon_6_scifi_shotgun/Materials_shotgun_green/Mat_plazmaColor_green"), typeof(Material)) as Material;
                }
            }
            if (gameObject.name.Equals("Musket_DuskSky"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    Material temp = Resources.Load(("Materials/Mat_beamWire_green"), typeof(Material)) as Material;
                    detail.GetComponent<Renderer>().material = temp;

                }
            }
            if (gameObject.name.Equals("Rifle obj_green"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    detail.GetComponent<Renderer>().material = Resources.Load(("Materials/Mat_Rifle_Green"), typeof(Material)) as Material;
                }
            }
            if (gameObject.name.Equals("Pistola22_green"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    detail.GetComponent<Renderer>().material = Resources.Load(("Materials/Mat_SciFiPistolEmmissionMat_green"), typeof(Material)) as Material;
                }
            }
            if (gameObject.name.Equals("FNXScifi_Low"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    detail.GetComponent<Renderer>().material = Resources.Load(("Materials/Mat_FNX_Green"), typeof(Material)) as Material;
                }
            }
            if(gameObject.name.Equals("PlasmaGunVR"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    detail.GetComponent<Renderer>().material = Resources.Load(("Materials/Gun 1"), typeof(Material)) as Material;
                }
            }
        }
        else
        {
            green.SetActive(false);
            red.SetActive(true);
            if (gameObject.name.Equals("PlasmaRifleVR"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    detail.GetComponent<Renderer>().material = Resources.Load(("Materials/PlasmaRifleBarrelEmissionRed"), typeof(Material)) as Material;
                }
            }
            if (gameObject.name.Equals("RailGun_Chris"))
            {
                GetComponent<Renderer>().material = Resources.Load(("Materials/RailGunChris_MatR"), typeof(Material)) as Material;
            }
            if (gameObject.name.Equals("TommyGun"))
            {
                foreach (Transform child in transform)
                {
                    child.GetComponent<Renderer>().material = Resources.Load(("Materials/TommyGunR"), typeof(Material)) as Material;
                }
            }
            if (gameObject.name.Equals("syfy_shotgun"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    Material[] mats = detail.GetComponent<Renderer>().materials;
                    Material temp = Resources.Load(("Materials/Mat_plazmaColor_red"), typeof(Material)) as Material;
                    mats[1] = temp;
                    detail.GetComponent<Renderer>().materials = mats;
                    //detail.GetComponent<Renderer>().material = Resources.Load(("Weapon_6_scifi_shotgun/Materials_shotgun_red/Mat_plazmaColor_red"), typeof(Material)) as Material;
                }
            }
            if (gameObject.name.Equals("Musket_DuskSky"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    Material temp = Resources.Load(("Materials/Mat_beamWire_red"), typeof(Material)) as Material;
                    detail.GetComponent<Renderer>().material = temp;
                }
            }
            if (gameObject.name.Equals("Rifle obj_green"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    detail.GetComponent<Renderer>().material = Resources.Load(("Materials/Mat_Rifle_Red"), typeof(Material)) as Material;
                }
            }
            if (gameObject.name.Equals("Pistola22_green"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    detail.GetComponent<Renderer>().material = Resources.Load(("Materials/Mat_SciFiPistolEmmissionMat_red"), typeof(Material)) as Material;
                }
            }
            if (gameObject.name.Equals("FNXScifi_Low"))
            {
                foreach (GameObject detail in emissiveObjects)
                {
                    detail.GetComponent<Renderer>().material = Resources.Load(("Materials/Mat_FNX_Red"), typeof(Material)) as Material;
                }
            }
            if(gameObject.name.Equals("PlasmaGunVR"))
            {
                foreach(GameObject detail in emissiveObjects)
                {
                    detail.GetComponent<Renderer>().material = Resources.Load(("Materials/Gun"), typeof(Material)) as Material;
                }
            }
        }
    }

    void WeaponShoot()
    {
        //Replace everything calling Shoot function with WeaponShoot
        if (isGreenFireMode)
        {
            Instantiate(greenBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
        }
        else
        {
            Instantiate(redBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
        }
        StartCoroutine(PlayGunSound());
        //audioSource.PlayOneShot(pistolShot);
        ReduceAmmo();
        currTime = 0;
    }

    //  void Shoot()
    //  {
    //      RaycastHit hit;
    //      if (Physics.Raycast(spawnPoint.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
    //      {
    //          if (green.activeSelf)
    //          {
    //              if (gameObject.name.Equals("PlasmaRifleVR"))
    //              {
    //                  Instantiate(greenRifleBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
    //              }
    //              else
    //              {
    //                  Instantiate(greenPistolBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
    //                  audioSource.PlayOneShot(pistolShot);
    //              }
    //          }
    //          if (red.activeSelf)
    //          {
    //              if (gameObject.name.Equals("PlasmaRifleVR"))
    //              {
    //                  Instantiate(redRifleBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
    //              }
    //              else
    //              {
    //                  Instantiate(redPistolBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
    //                  audioSource.clip = pistolShot;
    //                  audioSource.PlayOneShot(pistolShot);
    //              }
    //          }
    //          Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
    //          ReduceAmmo();
    //          Debug.Log("Did Hit");
    //      }
    //      else
    //      {
    //          if (green.activeSelf)
    //          {
    //              if (gameObject.name.Equals("PlasmaRifleVR"))
    //              {
    //                  Instantiate(greenRifleBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
    //              }
    //              else
    //              {
    //                  Instantiate(greenPistolBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
    //                  audioSource.PlayOneShot(pistolShot);
    //              }
    //          }
    //          if (red.activeSelf)
    //          {
    //              if (gameObject.name.Equals("PlasmaRifleVR"))
    //              {
    //                  Instantiate(redRifleBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
    //              }
    //              else
    //              {
    //                  Instantiate(redPistolBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
    //                  audioSource.clip = pistolShot;
    //                  audioSource.PlayOneShot(pistolShot);
    //              }
    //          }
    //          Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
    //          ReduceAmmo();
    //          Debug.Log("Did not Hit");
    //
    //          //RailgunBulletsStartHere
    //     }
    //      currTime = 0;
    // }
    void Timer()
    {
        rifleCharging += Time.fixedDeltaTime;
    }

    IEnumerator PlayGunSound()
    {
        if (gameObject.name.Equals("PlasmaGunVR"))
        {
            Audiomanager.audiomanager.Play("Pistol");
        }
        else if (gameObject.name.Equals("TommyGun"))
        {
            Audiomanager.audiomanager.Play("TommyGun");
        }
        else if (gameObject.name.Equals("RailGun_Chris"))
        {
            Audiomanager.audiomanager.Play("RailGun");
        }
        else if (gameObject.name.Equals("FNXScifi_Low"))
        {
            Audiomanager.audiomanager.Play("SmallPistol");
        }
        else if (gameObject.name.Equals("syfy_shotgun"))
        {
            Audiomanager.audiomanager.Play("Shotgun");
        }
        else if (gameObject.name.Equals("Musket_DuskSky"))
        {
            Audiomanager.audiomanager.Play("Musket");
        }
        else if (gameObject.name.Equals("Pistola22_green"))
        {
            Audiomanager.audiomanager.Play("Pistola");
        }
        else if (gameObject.name.Equals("Rifle obj_green"))
        {
            Audiomanager.audiomanager.Play("Rifle");
        }
        else if (gameObject.name.Equals("PlasmaRifleVR"))
        {
            Audiomanager.audiomanager.Play("PlasmaRifle");
        }
        yield return new WaitForSeconds(0.1f);
    }


    IEnumerator OneShot()
    {
        WeaponShoot();
        canShoot = false;
        yield return new WaitForSeconds(0.01f);
    }

    IEnumerator AutoShot()
    {
        WeaponShoot();
        canShoot = false;
        yield return new WaitForSeconds(.2f);
        canShoot = true;
    }

    IEnumerator RifleWheelGo()
    {
        if (green.activeSelf)
        {
            ParticleSystem psg = green.GetComponentInChildren<ParticleSystem>();
            var main = psg.main;
            main.startSpeed = 2f;
            main.simulationSpeed = 2f;
            var emit = psg.emission;
            emit.rateOverTime = 200;
        }
        else
        {
            ParticleSystem psr = red.GetComponentInChildren<ParticleSystem>();
            var main = psr.main;
            main.startSpeed = 2f;
            main.simulationSpeed = 2f;
            var emit = psr.emission;
            emit.rateOverTime = 200;
        }
        wheelSpin.speed = 1f;
        yield return new WaitForSeconds(0.2f);
        wheelSpin.speed = 1.25f;
        yield return new WaitForSeconds(0.2f);
        wheelSpin.speed = 1.5f;
    }

    IEnumerator RifleWheelStop()
    {
        if (rifleCharging >= 0.5f)
            WeaponShoot();
        rifleCharging = 0;
        if (green.activeSelf)
        {
            ParticleSystem psg = green.GetComponentInChildren<ParticleSystem>();
            var main = psg.main;
            main.startSpeed = 1f;
            main.simulationSpeed = 1f;
            var emit = psg.emission;
            emit.rateOverTime = 100;
        }
        else
        {
            ParticleSystem psr = red.GetComponentInChildren<ParticleSystem>();
            var main = psr.main;
            main.startSpeed = 1f;
            main.simulationSpeed = 1f;
            var emit = psr.emission;
            emit.rateOverTime = 100;
        }
        wheelSpin.speed = 1.25f;
        yield return new WaitForSeconds(0.1f);
        wheelSpin.speed = 1f;
        yield return new WaitForSeconds(0.1f);
        wheelSpin.speed = 0.7f;
    }
}