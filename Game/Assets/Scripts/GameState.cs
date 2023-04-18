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

    // Reference to the game over screen UI element
    public GameObject gameOverScreen;

    // Reference to the Cinemachine brain component attached to the main camera
    public CinemachineBrain cinemachineBrain;
    
    private void Awake()
    {
        isGameOver = false;
        cinemachineBrain = Camera.main.GetComponent<CinemachineBrain>();
        gameOverScreen.SetActive(false);
    }

    // Disable camera movement
    public void DisableCameraMovement()
    {
        cinemachineBrain.enabled = false;
    }

    // Show the game over screen after a delay
    private IEnumerator ShowGameOverScreenWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameOverScreen.SetActive(true);
        Time.timeScale = 0;
        DisableCameraMovement();
    }

    // Check if the game is over and show the game over screen if it is
    void Update()
    {
        if (isGameOver)
        {
            StartCoroutine(ShowGameOverScreenWithDelay(2f));
        }
    }
}