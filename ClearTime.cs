using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Invector.vCharacterController;

public class ClearTime : MonoBehaviour
{
    public Sprite[] sprites;
    public Image myImage;
    public int num;

    void Awake()
    {
        num = 1;
        Invoke("ChangeSprite", 1.0f);
    }

    void ChangeSprite()
    {
        if (num < 10)
        {
            myImage.sprite = sprites[num];
            num++;
            Invoke("ChangeSprite", 1.0f);
        }
        else
        {
            //ChangeMap
        }
    }
   
        
}
