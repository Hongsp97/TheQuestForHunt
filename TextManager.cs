using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    public Sprite[] sprites;
    public Image image;

    public void StartChat2(int index)
    {
        Sprite select = sprites[index];
        image.sprite = select;

    }

}
