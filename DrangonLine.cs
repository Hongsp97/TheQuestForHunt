using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrangonLine : MonoBehaviour
{
    LineRenderer line;
    Vector3 pos1, pos2;

    public Vector3 Pos1_Plus, Pos2_Plus;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        pos1 = gameObject.GetComponent<Transform>().position;
    }

    void Update()
    {
        line.SetPosition(0, pos1 + Pos1_Plus);
        line.SetPosition(1, GameObject.Find("Unka Poly Art").GetComponent<Transform>().position + Pos2_Plus); 
    }
}
