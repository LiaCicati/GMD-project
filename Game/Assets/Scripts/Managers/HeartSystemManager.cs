using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartSystemManager : MonoBehaviour
{
    [SerializeField] 
    public Image[] hearts; // Array to store heart images

    public void SetHeartVisibility(int currentHealth, int maxHealth)
    {
        // Calculate the health per heart
        float healthPerHeart = maxHealth / (float)hearts.Length;

        // Iterate through the hearts and set their visibility based on the current health
        for (int i = 0; i < hearts.Length; i++)
        {
            if (currentHealth >= (i + 1) * healthPerHeart)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}