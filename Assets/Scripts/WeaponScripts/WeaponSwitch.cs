using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.SceneManagement;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject Pistol;
    public List<GameObject> LoadoutWeapons;
    public List<GameObject> AvailableWeapons = new List<GameObject>();
    public string CurrentWeapon;
    public int WeaponPlace = 0;
    public List<KeyCode> NumKeys = new List<KeyCode>()
    {
        KeyCode.Alpha1,
        KeyCode.Alpha2,
        KeyCode.Alpha3
    };
    //public Image Icon; //Uncomment when adding Icon to Player UI
    public GameObject WeapSelector;
    public string Actscene;

    public void Start()
    {
        AvailableWeapons.Add(Pistol);
        AvailableWeapons.Add(LoadoutWeapons[0]);
        AvailableWeapons.Add(LoadoutWeapons[1]);

        CurrentWeapon = AvailableWeapons[0].name;
        AvailableWeapons[WeaponPlace].gameObject.SetActive(true);
        Actscene = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        //Icon.sprite = AvailableWeapons[WeaponPlace].GetComponent<GunTestVR>().WeapIcon;
    }
    public void Update()
    {
        if (Actscene == "WeapSelect")
        {
            AvailableWeapons[WeaponPlace].gameObject.SetActive(false);
            WeapSelector.SetActive(true);
            //Debug.LogError(Actscene);
        }
        else
        {


            if (/*Input.GetKeyDown(KeyCode.E) || */OVRInput.GetDown(OVRInput.RawButton.X))
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
                //Icon.sprite = AvailableWeapons[WeaponPlace].GetComponent<GunTestVR>().WeapIcon;
            }
            foreach (KeyCode key in NumKeys)
            {
                //if(Input.GetKeyDown(key))
                //{
                //    Debug.Log(key);
                //}
                if (Input.GetKeyDown(key))
                {
                    AvailableWeapons[WeaponPlace].gameObject.SetActive(false);
                    WeaponPlace = NumKeys.IndexOf(key);
                    CurrentWeapon = AvailableWeapons[WeaponPlace].name;
                    AvailableWeapons[WeaponPlace].gameObject.SetActive(true);
                    //Icon.sprite = AvailableWeapons[WeaponPlace].GetComponent<GunTestVR>().WeapIcon;
                }
            }
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
        AvailableWeapons.Clear();
        AvailableWeapons.Add(Pistol);
        AvailableWeapons.Add(LoadoutWeapons[0]);
        AvailableWeapons.Add(LoadoutWeapons[1]);
        AvailableWeapons[WeaponPlace].gameObject.SetActive(true);
    }
}
