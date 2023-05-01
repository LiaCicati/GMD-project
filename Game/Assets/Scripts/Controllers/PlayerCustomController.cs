using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PlayerCustomController : MonoBehaviour
{ 
    public int health = 600; // Initialize health to 600
    public int damageAmount = 100;
    public Animator animator;
    public void TakeDamage(int damageAmount)
    {
        // Subtract damage from health here
        health -= damageAmount;
        
        // Check if player is dead
        if (health <= 0)
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
        Animator animator = GetComponent<Animator>();
        // Play death animation here
        animator.SetTrigger("die");
        GameState.isGameOver = true;
       RestartGame restartGame =  FindObjectOfType<RestartGame>();
       restartGame.EndGame();

    } 
    
    private void GetHit()
    {
        // Play Get Hit Animation
        animator.SetTrigger("damage");
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyHit")
        {
            // Inflict damage on the player
            TakeDamage(damageAmount);
        }
    } 
}