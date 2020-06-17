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
    public int currAmmo = 10;
    public int maxAmmo = 20;
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

    GameObject green;
    GameObject red;
    GameObject redRailgunBullet;
    GameObject greenRailgunBullet;
    GameObject greenPistolBullet;
    GameObject redPistolBullet;
    GameObject greenRifleBullet;
    GameObject redRifleBullet;
    GameObject waveBullet;
    public List<GameObject> emissiveObjects = new List<GameObject>();
    public Animator wheelSpin;
    AudioSource audioSource;
    AudioClip pistolShot;

    public Sprite WeapIcon;

    private void Awake()
    {
        gunTestVR = this;
        green = GetComponentInChildren<ID_Green>().gameObject;
        if (green == null)
        {
            Debug.Log("green in GunTestVR not found.");
        }
        red = GetComponentInChildren<ID_Red>().gameObject;
        if (red == null)
        {
            Debug.Log("red in GunTestVR not found.");
        }
        greenPistolBullet = Resources.Load(("Prefabs/PlasmaBulletGreen"), typeof(GameObject)) as GameObject;
        //greenPistolBullet = Resources.Load(("Prefabs/LaserBulletGreen"), typeof(GameObject)) as GameObject;
        redPistolBullet = Resources.Load(("Prefabs/PlasmaBulletRed"), typeof(GameObject)) as GameObject;
        //redPistolBullet = Resources.Load(("Prefabs/LaserBulletRed"), typeof(GameObject)) as GameObject;
        greenRifleBullet = Resources.Load(("Prefabs/GreenRifleBullet"), typeof(GameObject)) as GameObject;
        redRifleBullet = Resources.Load(("Prefabs/RedRifleBullet"), typeof(GameObject)) as GameObject;
        //redRailgunBullet = Resources.Load(("Prefabs/LaserBulletRed), typeof(GameObject)) as GameObject;
        redRailgunBullet = Resources.Load(("Prefabs/RailgunBulletRed"), typeof(GameObject)) as GameObject;
        //greenRailgunBullet = Resources.Load(("Prefabs/LaserBulletRed), typeof(GameObject)) as GameObject;
        greenRailgunBullet = Resources.Load(("Prefabs/RailgunBulletGreen"), typeof(GameObject)) as GameObject;
        fullAutoTime = 0.1f;
        wheelSpin = gameObject.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        pistolShot = Resources.Load(("SFX/Pistol_Shot"), typeof(AudioClip)) as AudioClip;
        
    }

    void Start()
    {
        damageValue = 5;
        green.SetActive(false);
        if (gameObject.name.Equals("PlasmaRifleVR"))
        {
            damageValue = 5;
            foreach (GameObject detail in emissiveObjects)
            {
                detail.GetComponent<Renderer>().material = Resources.Load(("Materials/PlasmaRifleBarrelEmissionRed"), typeof(Material)) as Material;
                
            }
        }
        if (gameObject.name.Equals("RailGun_Chris"))
        {
            damageValue = 3;
            GetComponent<Renderer>().material = Resources.Load(("Materials/RailGunChris_MatR"), typeof(Material)) as Material;
            redBullet = redRailgunBullet;
            greenBullet = greenRailgunBullet;
         

        }
        if (gameObject.name.Equals("TommyGun"))
        {
            foreach (Transform child in transform)
            {
                child.GetComponent<Renderer>().material = Resources.Load(("Materials/TommyGunR"), typeof(Material)) as Material;
            }
            damageValue = 3;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            WeaponShoot();
        }


        string Actscene = FindObjectOfType<WeaponSwitch>().Actscene;
        if (Actscene != "WeapSelect")
        {
            if (gameObject.name.Equals("PlasmaRifleVR"))
            {
                if (rifleTrigger)
                    Timer();
                float triggerPress;
                triggerPress = OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger);
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
            else
            {
                if (fullAutoMode)
                {
                    if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && canShoot && currAmmo > 0 && tag!= "RGun")
                    {
                        StartCoroutine("AutoShot");
                    }
                }
                else
                {
                    if ((OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger)) && canShoot && currAmmo > 0&& tag!= "RGun")
                    {
                        StartCoroutine("OneShot");
                        return;
                    }
                    if ((OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger)) && !canShoot)
                    {
                        canShoot = true;
                        return;
                    }
                    if ((OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger)) && canShoot && currAmmo > 0 && tag == "RGun")
                    {
                        StartCoroutine("OneShot");
                        return;
                    }
                    if ((OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)) && !canShoot && tag == "RGun")
                    {
                        canShoot = true;
                        return;

                    }
                }
            }

            if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && currAmmo <= 0)
            {
                Debug.Log("Out of Ammo");
            }

            if (OVRInput.GetDown(OVRInput.RawButton.Y))
            {
                SwitchBullets();
                if(isGreenFireMode==false)
                {
                    isGreenFireMode = true;
                }
                else
                {
                    isGreenFireMode = false;
                }
               
            }
        }
        //if (OVRInput.GetDown(OVRInput.RawButton.X))
        //{
        //    SwitchFireMode();
        //}
    }


    void ReduceAmmo()
    {
        currAmmo--;
        currAmmo = Mathf.Clamp(currAmmo, 0, maxAmmo);
        ammoChanged = true;
    }

    public void RegainAmmo()
    {
        currAmmo = maxAmmo;
        currAmmo = Mathf.Clamp(currAmmo, 0, maxAmmo);
        ammoChanged = true;
    }

    void SwitchFireMode()
    {
        fullAutoMode = !fullAutoMode;
        if (fullAutoMode == true)
        {
            shootTime = fullAutoTime;
        }
        else
        {
            shootTime = semiAutoTime;
        }
    }

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
        audioSource.PlayOneShot(pistolShot);
        ReduceAmmo();
        //Set currTime to 0
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(spawnPoint.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            if (green.activeSelf)
            {
                if (gameObject.name.Equals("PlasmaRifleVR"))
                {
                    Instantiate(greenRifleBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                else
                {
                    Instantiate(greenPistolBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                    audioSource.PlayOneShot(pistolShot);
                }
            }
            if (red.activeSelf)
            {
                if (gameObject.name.Equals("PlasmaRifleVR"))
                {
                    Instantiate(redRifleBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                else
                {
                    Instantiate(redPistolBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                    audioSource.clip = pistolShot;
                    audioSource.PlayOneShot(pistolShot);
                }
            }
            Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            ReduceAmmo();
            Debug.Log("Did Hit");
        }
        else
        {
            if (green.activeSelf)
            {
                if (gameObject.name.Equals("PlasmaRifleVR"))
                {
                    Instantiate(greenRifleBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                else
                {
                    Instantiate(greenPistolBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                    audioSource.PlayOneShot(pistolShot);
                }
            }
            if (red.activeSelf)
            {
                if (gameObject.name.Equals("PlasmaRifleVR"))
                {
                    Instantiate(redRifleBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                }
                else
                {
                    Instantiate(redPistolBullet, spawnPoint.position, transform.rotation * Quaternion.Euler(0, 90, 0));
                    audioSource.clip = pistolShot;
                    audioSource.PlayOneShot(pistolShot);
                }
            }
            Debug.DrawRay(spawnPoint.position, transform.TransformDirection(Vector3.forward) * 1000, Color.red);
            ReduceAmmo();
            Debug.Log("Did not Hit");

            //RailgunBulletsStartHere
        }
        currTime = 0;
    }
    void Timer()
    {
        rifleCharging += Time.fixedDeltaTime;
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
        yield return new WaitForSeconds(0.1f);
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