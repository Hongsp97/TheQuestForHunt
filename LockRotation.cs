using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockRotation : MonoBehaviour
{
    void Update()
    {
        if(transform.rotation != Quaternion.Euler(0,0,0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

    }
}
