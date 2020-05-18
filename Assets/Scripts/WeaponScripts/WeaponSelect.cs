using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WeaponSelect : MonoBehaviour
{
    public WeaponSwitch GM;
    public GameObject Pistol;
    public GameObject Load;
    public bool PSelect = true;
    public GameObject CurrPistol;
    public List<GameObject> CurrLoadOut; //Players current Primary, Secondary Weapons
    public List<GameObject> PrimSecond; //Buttons for the CurrLoadOut
    public List<GameObject> PistolButtons; //Button Player clicks for specific weapon
    public List<GameObject> PistolChoices; //Line up with the Buttons for when clicked makes the current pistol this.
    public List<GameObject> ARButtons; //Same as PistolButtons
    public List<GameObject> ARChoices; // Same as PistolChoices
    public int SelectedSlot;
    public string SceneName;
    public Transform GunSpawn;

    void Awake()
    {
        GM = FindObjectOfType<WeaponSwitch>();
        Pistol.SetActive(true);
        CurrPistol = GM.Pistol;
        CurrLoadOut = GM.LoadoutWeapons;
        Load.SetActive(false);
    }

    public void LoadoutSelect()
    {
        PSelect = !PSelect;
        if (!PSelect)
        {
            Pistol.SetActive(false);
            Load.SetActive(true);
        }
        else 
        {
            Pistol.SetActive(true);
            Load.SetActive(false);
        }
    }

    public void Clicked()
    {
        foreach(Transform child in GunSpawn.transform)
        {
            Destroy(child.gameObject);
        }

        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);       
        if(PSelect)
        {
            int Click = PistolButtons.IndexOf(EventSystem.current.currentSelectedGameObject);
            //Debug.Log("Pistol selected " + PistolChoices[Click].name);
            Instantiate(PistolChoices[Click], GunSpawn);
            GM.Pistol = PistolChoices[Click];
        }
        else
        {
            int Click = ARButtons.IndexOf(EventSystem.current.currentSelectedGameObject);
            //Debug.Log("AR selected " + ARChoices[Click].name);
            Instantiate(ARChoices[Click], GunSpawn);
            GM.LoadoutWeapons[SelectedSlot] = ARChoices[Click];
        }
        CurrUpdate();
    }

    public void LoadOut()
    {
        //Debug.Log(EventSystem.current.currentSelectedGameObject);
        int Load = PrimSecond.IndexOf(EventSystem.current.currentSelectedGameObject);
        SelectedSlot = Load;
        //Debug.Log(Load);
    }

    public void CurrUpdate()
    {
        CurrPistol = GM.Pistol;
        CurrLoadOut = GM.LoadoutWeapons;
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneName);
    }
}
