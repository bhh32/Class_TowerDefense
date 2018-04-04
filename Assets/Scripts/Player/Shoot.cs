using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Rigidbody projectileRb;
    [SerializeField, Tooltip("Less Is Faster")] float fireRate;
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] List<GameObject> enemiesList;

    GameObject ene;

    void Awake()
    {
        enemiesList = new List<GameObject>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesList.Add(other.gameObject);
        }
    }
	// Use this for initialization
    void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Enemy") && !IsInvoking())
        {
            InvokeRepeating("Shooting", 1f, fireRate);
        }

        // Check to see if the list is empty
        if (isListEmpty())
            CancelInvoke();
	}

    bool isListEmpty()
    {
        foreach (GameObject e in enemiesList)
        {
            if (e == null)
            {}
            else
                return false;
        }

        return true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesList.Remove(other.gameObject);
        }
    }

    void Update()
    {
        Debug.DrawLine(transform.position, transform.forward.normalized * 25f);
    }

    void Shooting()
    {

        GameObject proj = Instantiate(projectilePrefab, transform.position, new Quaternion(90f, 0f, 0f, 0f)) as GameObject;
        proj.transform.up = transform.forward;
        proj.GetComponent<Rigidbody>().AddForce(transform.forward * 100f, ForceMode.Impulse);

    }
}
