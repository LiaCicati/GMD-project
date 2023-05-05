using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    public Button backButton;

    void Start()
    {
        backButton.gameObject.SetActive(false); // hide button at the start
    }

    public void FoundPotion()
    {
        backButton.gameObject.SetActive(true); // show button when potion found
       Time.timeScale = 0f;

    }

    public void GoToStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
         Time.timeScale = 1f; // resume the game
    }
}