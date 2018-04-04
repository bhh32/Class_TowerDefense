using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour 
{
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
            transform.LookAt(other.transform);
    }
}
