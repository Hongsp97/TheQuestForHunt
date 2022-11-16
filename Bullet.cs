using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool isMelee;
   
    public void DystroyMine()
    {
            Destroy(gameObject);
    }

}
