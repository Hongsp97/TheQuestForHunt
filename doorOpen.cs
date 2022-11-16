using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRigit;

    public void openDoor()
    {
        doorLeft.transform.rotation = Quaternion.Euler(0, 85, 0);
    }

}

