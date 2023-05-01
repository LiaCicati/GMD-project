using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCustomController : MonoBehaviour
{
    public int maxHealth = 800;
    public int currentHealth;
    public int damageAmount = 100;
    public Animator animator;
    public HeartSystemManager heartSystemManager; // Reference to the HeartSystemManager

    void Start()
    {
        currentHealth = maxHealth;
        heartSystemManager.SetHeartVisibility(currentHealth, maxHealth); // Set initial heart visibility
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        heartSystemManager.SetHeartVisibility(currentHealth, maxHealth); // Update heart visibility

        if (currentHealth <= 0)
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
        animator.SetTrigger("die");
        GameState.isGameOver = true;
        RestartGame restartGame = FindObjectOfType<RestartGame>();
        restartGame.EndGame();
    } 

    private void GetHit()
    {
        animator.SetTrigger("damage");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyHit")
        {
            TakeDamage(damageAmount);
        }
    } 
}