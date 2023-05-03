using System.Collections;
using UnityEngine;

public class PlayerCustomController : MonoBehaviour
{
    [SerializeField]
    public int maxHealth = 100;
    [SerializeField]
    public int currentHealth;
    [SerializeField]
    private int damageAmount = 25;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private HeartSystemManager heartSystemManager; // Reference to the HeartSystemManager
    [SerializeField]
    private bool isTakingDamage = false;
    
    void Start()
    {
        currentHealth = maxHealth;
        heartSystemManager.SetHeartVisibility(currentHealth, maxHealth); // Set initial heart visibility
    }
    
    public void TakeDamage(int damageAmount)
    {
        if (!isTakingDamage) // Check if the player is currently taking damage
        {
            isTakingDamage = true; // Set the flag to indicate that the player is taking damage

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

            // Reset the flag after a short delay to prevent multiple hits in quick succession
            StartCoroutine(ResetTakingDamageFlag());
        }
    }

    IEnumerator ResetTakingDamageFlag()
    {
        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds
        isTakingDamage = false; // Reset the flag
    }

    private void Die()
    {
        AudioManager.instance.Play("GameOver");
        animator.SetTrigger("die");
        
        // Set the game state to indicate that the game has been lost
        GameState.isGameOver = true;
    } 

    private void GetHit()
    {
        animator.SetTrigger("damage");
        AudioManager.instance.Play("Damage");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyHit")
        {
            TakeDamage(damageAmount);
        }
    } 
    
    public void IncreaseHealth(int amount) 
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
        heartSystemManager.SetHeartVisibility(currentHealth, maxHealth); // Update heart visibility
    }
}