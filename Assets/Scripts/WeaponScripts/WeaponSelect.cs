using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WeaponSelect : MonoBehaviour
{
    public WeaponSwitch GM;
    public GameObject Pistol;
    public GameObject Load;
    public GameObject Text1, Text2;
    public bool PSelect = false;
    [Header("Current Weapons")]
    public GameObject CurrPistol;
    public Image CurrPImage;
    public List<GameObject> CurrLoadOut; //Players current Primary, Secondary Weapons
    [Header("Pistol")]    
    public List<GameObject> PistolButtons; //Button Player clicks for specific weapon
    public List<GameObject> PistolChoices; //Line up with the Buttons for when clicked makes the current pistol this.
    public List<Image> PChoiImages; //Pistol Images from the Buttons
    [Header("Loadout")]
    public List<GameObject> PrimSecond; //Buttons for the CurrLoadOut
    public List<Image> PrimSecIcon; //Sprites for the Prim and Secondary weapons
    public List<GameObject> ARButtons; //Same as PistolButtons
    public List<GameObject> ARChoices; // Same as PistolChoices
    public List<Image> ARImages; //Holds the Images of the AR Buttons
    private int SelectedSlot;
    public string SceneName;
    //public Transform GunSpawn; //Uncomment when Gunspawn is fixed

    public void Start()
    {
        GM = GameManager.gameManager.GetComponent<WeaponSwitch>();
        LoadoutSelect();       
       
       //Instantiate(CurrPistol, GunSpawn);
    }

    public void LoadoutSelect()
    {
        PSelect = !PSelect;
        if (PSelect == false)
        {
            Pistol.SetActive(false);
            Load.SetActive(true);
            Text1.SetActive(false);
            Text2.SetActive(true);
            for (int i = 0; i < PrimSecIcon.Count; i++)
            {
                PrimSecIcon[i].sprite = CurrLoadOut[i].GetComponent<GunTestVR>().WeapIcon;
            }

            for (int i = 0; i < ARImages.Count; i++)
            {
                ARImages[i].sprite = ARChoices[i].GetComponent<GunTestVR>().WeapIcon;
            }
        }
        else 
        {
            Pistol.SetActive(true);
            Load.SetActive(false);
            Text1.SetActive(true);
            Text2.SetActive(false);
            for (int i = 0; i < PistolChoices.Count; i++)
            {
                PChoiImages[i].sprite = PistolChoices[i].GetComponent<GunTestVR>().WeapIcon;
            }
        }
        CurrPistol = GM.Pistol;
        CurrPImage.sprite = CurrPistol.GetComponent<GunTestVR>().WeapIcon;
        CurrLoadOut = GM.LoadoutWeapons;
    }

    public void Clicked()
    {
        //foreach(Transform child in GunSpawn.transform)
        //{
        //    Destroy(child.gameObject);
        //}

        //Debug.Log(EventSystem.current.currentSelectedGameObject.name);       
        if(PSelect)
        {
            int Click = PistolButtons.IndexOf(EventSystem.current.currentSelectedGameObject);
            //Debug.Log("Pistol selected " + PistolChoices[Click].name);
            //Instantiate(PistolChoices[Click], GunSpawn);
            GM.Pistol = PistolChoices[Click];
            GM.CurrPistol = PistolChoices[Click];           
        }
        else
        {
            int Click = ARButtons.IndexOf(EventSystem.current.currentSelectedGameObject);
            //Debug.Log("AR selected " + ARChoices[Click].name);
            //Instantiate(ARChoices[Click], GunSpawn);
            GM.LoadoutWeapons[SelectedSlot] = ARChoices[Click];
            GM.CurrLoad[SelectedSlot] = ARChoices[Click];
            PrimSecIcon[SelectedSlot].sprite = ARChoices[Click].GetComponent<GunTestVR>().WeapIcon;
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
        CurrPImage.sprite = CurrPistol.GetComponent<GunTestVR>().WeapIcon;
        CurrLoadOut = GM.LoadoutWeapons;
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneName);
    }
}
