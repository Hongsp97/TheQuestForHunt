using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Stone : Bullet
{
    public float fireballSpeed;
    public Rigidbody rig;
    public Transform target;
    public float maxDigDel;

    void Update()
    {
        if(target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    void FixedUpdate()
    {
        rig.velocity = transform.forward * fireballSpeed;
        var targetRotation = Quaternion.LookRotation((target.position + new Vector3(0, 1f, 0)) - transform.position);
        rig.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, maxDigDel));
    }

}
