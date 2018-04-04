using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour 
{
    Rigidbody projectileRb;
    [SerializeField] GameObject projectilePrefab;

	// Use this for initialization
    void OnTriggerStay(Collider other) 
    {
        if (other.CompareTag("Enemy"))
            StartCoroutine(Shooting(projectilePrefab));
        else
            StopAllCoroutines();
	}

    void Update()
    {
        Debug.DrawLine(transform.position, transform.forward.normalized * 25f);
    }

    IEnumerator Shooting(GameObject projectile)
    {
        
        float count = 0;
        float delay = 0;

        while (delay < 2f)
        {
            delay++;
            yield return new WaitForSeconds(1f);
        }

        GameObject proj = Instantiate(projectile, transform.position, new Quaternion(90f, 0f, 0f, 0f)) as GameObject;
        proj.transform.up = transform.forward;
        proj.GetComponent<Rigidbody>().AddForce(transform.forward * 100f, ForceMode.Impulse);

        while(count < 10f)
        {
            count++;
            yield return new WaitForSeconds(1f);
        }

        StartCoroutine(Shooting(projectile));
    }
}
