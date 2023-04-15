using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    // HP = Hit points - amount of damage that an object can sustain before it is destroyed or defeated
    public int HP = 60;
    public Animator animator;

    public void TakeDamage(int damageAmount)
    {
        Debug.Log("INITIAL"+HP);
        Debug.Log("Enemy taking damage: " + damageAmount + " HP = " + HP);
        HP -= damageAmount;
        if (HP <= 0)
        {
            Die();
        }
        else
        {
            GetHit();
        }
    }
    
    private void Die()
    {
        // Play Death Animation
        AudioManager.instance.Play("GolemDeath");
        animator.SetTrigger("die");
        GetComponent<Collider>().enabled = false;
        enabled = false;
    }

    private void GetHit()
    {
        // Play Get Hit Animation
        AudioManager.instance.Play("GolemDamage");
        animator.SetTrigger("damage");
    }
}