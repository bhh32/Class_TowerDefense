using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    float Damage
    { get; set;}
    void TakeDamage(GameObject damager);
}
