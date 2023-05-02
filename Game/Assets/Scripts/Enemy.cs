using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using StarterAssets;
using UnityEditor.Build.Content;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    // HP = Hit points - amount of damage that an object can sustain before it is destroyed or defeated
    public int HP = 60;
    public Animator animator;
    public HealthBar healthBar;
    public Collider armCollider;

    private void Start()
    {
        healthBar.SetMaxHealth(HP);
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        healthBar.SetHealth(HP);
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
        // Disable the extra collider on the enemy arm
        armCollider.gameObject.SetActive(false);
        // Delay destruction of the game object
        StartCoroutine(DestroyAfterDelay(3f)); 
    }

    private IEnumerator DestroyAfterDelay(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Destroy(gameObject);
    }
    private void GetHit()
    {
        // Play Get Hit Animation
        AudioManager.instance.Play("GolemDamage");
        animator.SetTrigger("damage");
    }
}