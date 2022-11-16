using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomInit : MonoBehaviour
{
    public GameObject senser;
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            senser.SetActive(true);
        }
    }
}
