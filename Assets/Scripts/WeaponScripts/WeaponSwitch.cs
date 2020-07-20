using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject Pistol;
    [HideInInspector] public GameObject CurrPistol;
    public List<GameObject> LoadoutWeapons;
    [HideInInspector] public List<GameObject> CurrLoad;
    public List<GameObject> AvailableWeapons = new List<GameObject>();
    public string CurrentWeapon;
    public int WeaponPlace = 0;
    [HideInInspector] public List<KeyCode> NumKeys = new List<KeyCode>()
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3
    };
    //public Image Icon; //Uncomment when adding Icon to Player UI
    public GameObject WeapSelector;
    public string Actscene;

    public void Awake()
    {
        SetWeap();
    }   
    public void SetWeap()
    {
        CurrPistol = Pistol;
        for (int i = 0; i < LoadoutWeapons.Count; i++)
        {
            if (!CurrLoad.Contains(LoadoutWeapons[i]))
            {
                CurrLoad.Add(LoadoutWeapons[i]);
            }
        }
    }
    public void Update()
    {
       
        if (Actscene == "WeapSelect")
        {
            WeapSelector.SetActive(true);
            //Debug.LogError(Actscene);
        }
        else
        {
            if (/*Input.GetKeyDown(KeyCode.E) || */OVRInput.GetDown(OVRInput.RawButton.RHandTrigger))
            {
                AvailableWeapons[WeaponPlace].gameObject.SetActive(false);
                WeaponPlace++;
                //Debug.LogError(WeaponPlace);
                if (WeaponPlace >= AvailableWeapons.Count)
                {
                    WeaponPlace = 0;
                }

                CurrentWeapon = AvailableWeapons[WeaponPlace].name;
                AvailableWeapons[WeaponPlace].gameObject.SetActive(true);
                GameManager.gameManager.RECHARGE();
                //Icon.sprite = AvailableWeapons[WeaponPlace].GetComponent<GunTestVR>().WeapIcon;
            }
            //foreach (KeyCode key in NumKeys)
            //{
                //if(Input.GetKeyDown(key))
                //{
                //    Debug.Log(key);
                //}
                //if (Input.GetKeyDown(key))
                //{
                //    AvailableWeapons[WeaponPlace].gameObject.SetActive(false);
                //    WeaponPlace = NumKeys.IndexOf(key);
                //    CurrentWeapon = AvailableWeapons[WeaponPlace].name;
                //    AvailableWeapons[WeaponPlace].gameObject.SetActive(true);
                    //Icon.sprite = AvailableWeapons[WeaponPlace].GetComponent<GunTestVR>().WeapIcon;
                //}
            //}
        }
        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    AvailableWeapons[WeaponPlace].gameObject.SetActive(false);
        //    WeaponPlace = 0;
        //    CurrentWeapon = AvailableWeapons[WeaponPlace].name;
        //    AvailableWeapons[WeaponPlace].gameObject.SetActive(true);            
        //}
        //if(Input.GetKeyDown(KeyCode.Alpha2))
        //{
        //    AvailableWeapons[WeaponPlace].gameObject.SetActive(false);
        //    WeaponPlace = 1;
        //    CurrentWeapon = AvailableWeapons[WeaponPlace].name;
        //    AvailableWeapons[WeaponPlace].gameObject.SetActive(true);
        //}
        //if(Input.GetKeyDown(KeyCode.Alpha3))
        //{
        //    AvailableWeapons[WeaponPlace].gameObject.SetActive(false);
        //    WeaponPlace = 2;
        //    CurrentWeapon = AvailableWeapons[WeaponPlace].name;
        //    AvailableWeapons[WeaponPlace].gameObject.SetActive(true);
        //}
    }

    public void Swap()
    {
        //SetWeap();
        AvailableWeapons.Clear();
        AvailableWeapons.Add(Pistol);
        AvailableWeapons.Add(LoadoutWeapons[0]);
        AvailableWeapons.Add(LoadoutWeapons[1]);
        Actscene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        if (Actscene == "WeapSelect")
        {
            AvailableWeapons[0].gameObject.SetActive(false);
        }
        else
        {
            AvailableWeapons[0].gameObject.SetActive(true);
        }
        GameManager.gameManager.AmmoReset();
    }
}
