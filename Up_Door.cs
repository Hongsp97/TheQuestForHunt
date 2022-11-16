using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_Door : MonoBehaviour
{
    public Animator anim;
    public GameObject Go_door1;
    public GameObject Go_door2;
    public void SetDoorOpen()
    {
        if (anim.GetBool("is_open") == false)
        {
            anim.SetBool("is_open", true);
        }
        else
        {
            anim.SetBool("is_open", false);
        }
    }

    public void offCameraStateObject()
    {
        Go_door1.SetActive(false);
    }

    public void onCameraStateObject()
    {
        Go_door2.SetActive(true);
    }
}
