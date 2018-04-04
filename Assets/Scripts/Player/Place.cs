using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Place : MonoBehaviour 
{
    public GameObject turret;
    bool canPlace;

    void Awake()
    {
        canPlace = true;

    }

    void Update()
    {
        Debug.DrawLine(transform.position, transform.forward * 20f, Color.red);
    }

    void OnMouseUp()
    {
        if (canPlace)
        {
            GameObject newTurret = Instantiate(turret, transform.position, Quaternion.identity) as GameObject;
            newTurret.transform.forward = -transform.forward;
        }
    }
}
