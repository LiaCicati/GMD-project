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

    // Reference to the game over screen UI element
    public GameObject gameOverScreen;

    // Reference to the win screen UI element
    public GameObject winScreen;

    // Reference to the Cinemachine brain component attached to the main camera
    public CinemachineBrain cinemachineBrain;
    
    private void Awake()
    {
        isGameOver = false;
        isGameWon = false;
        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
    }

    // Disable camera movement
    public void DisableCameraMovement()
    {
        cinemachineBrain.enabled = false;
    }

    // Show the game over screen or win screen after a delay
    private IEnumerator ShowGameOverOrWinScreenWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (isGameWon)
        {
            winScreen.SetActive(true);
        }
        else
        {
            gameOverScreen.SetActive(true);
        }

        Time.timeScale = 0;
        DisableCameraMovement();
    }

    // Check if the game is over or won and show the game over screen or win screen if it is
    void Update()
    {
        if (isGameOver || isGameWon)
        {
            StartCoroutine(ShowGameOverOrWinScreenWithDelay(2f));
        }
    }
}