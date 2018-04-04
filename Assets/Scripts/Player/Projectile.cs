using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IHealth
{
    [SerializeField] float damage;

    public float Damage
    { 
        get{ return damage; } 
        set{ damage = value; }
    }

    public void TakeDamage(GameObject enemy)
    {
        var enemyHealth = enemy.GetComponent<Health>();
        if (enemyHealth.hp.armor > 0f)
            enemyHealth.hp.armor -= Damage;
        else if (enemyHealth.hp.armor <= 0f)
            enemyHealth.hp.health -= Damage;

        if (enemyHealth.hp.health <= 0f)
            Destroy(enemy);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
            Destroy(gameObject);
    }
}
