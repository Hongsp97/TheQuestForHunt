using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public GameObject ItemWindow;
    public GameObject GoldImage;
    public Text GoldValue;
    public PlayerHasCoin playercoin;
    public bool isGold;

    void Start()
    {
        playercoin = gameObject.GetComponentInParent<PlayerHasCoin>();
        isGold = false;
    }
    void Update()
    {
        if (ItemWindow.activeSelf == false)
        {
            GoldImage.SetActive(false);
        }
        else 
        {
            GoldImage.SetActive(true);
            isGold = false;
        }


        if (GoldImage.activeSelf == true && isGold == false )
        {
            GoldValue.text = string.Format("{0:n0}", playercoin.coin);
            isGold = true;
        }
    }
}
