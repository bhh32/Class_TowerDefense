using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public HP hp;

    void Awake()
    {
        if (gameObject.name == "Enemy1(Clone)")
        {
            hp.health = 50f;
            hp.armor = 0f;
        }
        else if (gameObject.name == "Enemy2(Clone)")
        {
            hp.health = 75f;
            hp.armor = 25f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            var proj = other.GetComponent<Projectile>();
            proj.TakeDamage(gameObject);
            Destroy(other.gameObject);
        }
    }
}

public struct HP
{
    public float health;
    public float armor;
}
