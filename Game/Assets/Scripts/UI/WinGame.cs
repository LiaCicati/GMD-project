using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinGame : MonoBehaviour
{
    // Restart the game
    public void RestartGame()
    {
        // Set the time scale back to 1
        Time.timeScale = 1; 
        
        // Load Game scene
        SceneManager.LoadScene("SampleScene");
    }
    
    // Quit the game
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    // Start the MiniGame scene
    public void StartMiniGame()
    {
        // Load MiniGame scene
        Time.timeScale = 1; 
        SceneManager.LoadScene("MiniGame");
    }
}