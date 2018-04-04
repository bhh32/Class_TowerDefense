using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSelect : MonoBehaviour 
{
    [SerializeField] Place[] placeObj;
    [SerializeField] GameObject selectedObject;
    void OnMouseUp()
    {
        foreach (Place p in placeObj)
        {
            p.turret = selectedObject;
        }
    }
}
