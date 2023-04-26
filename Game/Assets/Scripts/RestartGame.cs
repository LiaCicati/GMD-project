using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public KeyCode restartKey = KeyCode.R; // Key to press to restart the game

    public bool gameEnded ; // Check if the game has ended

    public bool gameWon; // Check if the game has been won

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ResetGame; // Subscribe to the scene loaded event
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetGame; // Unsubscribe from the scene loaded event
    }

    private void Update()
    {
        if ((gameEnded || gameWon) && Input.GetKeyDown(restartKey))
        {
            Debug.Log("Restarting game...");
            Restart();
        }
    }

    public void EndGame()
    {
        Debug.Log("Game ended");
        gameEnded = true;
    }

    public void WinGame()
    {
        Debug.Log("Game won");
        gameWon = true;
    }

    private void Restart()
    {
        Debug.Log("Reloading scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    private void ResetGame(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Resetting game:");
        gameEnded = false;
        gameWon = false;
        Time.timeScale = 1;
        // Reset other game state here
    }
}