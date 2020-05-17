using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] GameObject deathVfx = null;
    [SerializeField] Animator animator = null;

    int currentHealth;
       
    public void Start()
    {
        currentHealth = maxHealth;
    }

    public void DoDamage(int amt)
    {
        currentHealth -= amt;
        animator.SetTrigger("Hit");
    }

    public void Die()
    {
        var obj = Instantiate(deathVfx, transform.position, Quaternion.identity);
        Destroy(obj, 1.0f);
        Destroy(gameObject);
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }
}