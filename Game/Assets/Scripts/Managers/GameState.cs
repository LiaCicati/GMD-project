using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Manages the game state
public class GameState : MonoBehaviour
{
    // Flag to indicate if the game is over
    public static bool isGameOver;

    // Flag to indicate if the game has been won
    public static bool isGameWon;
    
    // Reference to the Cinemachine brain component attached to the main camera
    public CinemachineBrain cinemachineBrain;
    
    private void Awake()
    {
        isGameOver = false;
        isGameWon = false;
        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
    }

    // Disable camera movement
    public void DisableCameraMovement()
    {
        cinemachineBrain.enabled = false;
    }

    // Show the game over scene or win game scene after a delay
    private IEnumerator ShowGameOverOrWinScreenWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (isGameWon)
        {
            // Load the game over scene
            SceneManager.LoadScene("WinGame");
        }
        else
        {
            // Load the game over scene
            SceneManager.LoadScene("GameOver");
        }

        Time.timeScale = 0;
        DisableCameraMovement();
    }

    // Check if the game is over or won and show the game over scene or win scene if it is
    void Update()
    {
        if (isGameOver || isGameWon)
        {
            StartCoroutine(ShowGameOverOrWinScreenWithDelay(2f));
        }
    }
}