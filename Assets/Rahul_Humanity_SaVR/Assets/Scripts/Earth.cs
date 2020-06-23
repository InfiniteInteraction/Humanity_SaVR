using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine;

public class Earth : MonoBehaviour
{
    public GameObject EarthModel;
    public GameObject OS;
    public GameObject LSButton;

    public TextMeshProUGUI textBox;

    // Start is called before the first frame update
    void Start()
    {
        EarthModel.transform.DOScale(100,0.5f);
        OS.transform.DOScale(1, 0.5f);
        LSButton.transform.DOScale(1, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RightArrow()
    {
        textBox.text = "Antarctica";
        EarthModel.transform.DOMove(new Vector3(-197.2886f, -66.64333f, 3530.233f), 0.5f);
        EarthModel.transform.DORotate(new Vector3(86.257f, -259.702f, 140.284f),0.5f);
    }

    public void LeftArrow()
    {
        textBox.text = "Africa";
        EarthModel.transform.DOMove(new Vector3(-272.5825f, -182.4947f, 3630.66f), 0.5f);
        EarthModel.transform.DORotate(new Vector3(-11.929f, -65.1f, 12.595f), 0.5f);
    }
}
