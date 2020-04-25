using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public float health = 50f;

    public void TakeDamage(float damage_taken)
    {
        health -= damage_taken;

        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
