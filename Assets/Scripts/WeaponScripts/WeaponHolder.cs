using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public List<GameObject> Weapons;
    public WeaponSwitch WGM;

    public void Start()
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i].SetActive(false);
        }
        
        WGM = FindObjectOfType<WeaponSwitch>();

       foreach(GameObject Gun in Weapons)
       {
            string PName = WGM.Pistol.name;
            if(Gun.name == PName)
            {
                WGM.Pistol = Gun;
            }

            foreach(GameObject LoadoutGun in Weapons)
            {
                for (int i = 0; i < WGM.LoadoutWeapons.Count; i++)
                {
                    string WName = WGM.LoadoutWeapons[i].name;
                    if(LoadoutGun.name == WName)
                    {
                        WGM.LoadoutWeapons[i] = LoadoutGun;
                    }
                }
            }            
       }

        WGM.Swap();
    }
}
