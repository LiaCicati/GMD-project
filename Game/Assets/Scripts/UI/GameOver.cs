using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Restart the game
    public void RestartGame()
    {
        // Set the time scale back to 1
        Time.timeScale = 1; 
        SceneManager.LoadScene("SampleScene");
    }
    
    // Quit the game
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
