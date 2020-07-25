using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    public List<GameObject> Weapons;
    public GameObject RightController;
    public WeaponSwitch WGM;

    public void OnEnable()
    {
        for (int i = 0; i < Weapons.Count; i++)
        {
            Weapons[i].SetActive(false);
        }
        WeapLoad();
    }
    public void WeapLoad()
    {        
        WGM = GameManager.gameManager.GetComponent<WeaponSwitch>();

        foreach (GameObject Gun in Weapons)
        {
            string PName = WGM.CurrPistol.name;
            if (Gun.name == PName)
            {
                WGM.Pistol = Gun;
            }

            foreach (GameObject LoadoutGun in Weapons)
            {
                for (int i = 0; i < WGM.CurrLoad.Count; i++)
                {
                    string WName = WGM.CurrLoad[i].name;
                    if (LoadoutGun.name == WName)
                    {
                        WGM.LoadoutWeapons[i] = LoadoutGun;
                    }
                }
            }
        }
        WGM.WeapSelector = RightController;
        WGM.Swap();
    }
}
