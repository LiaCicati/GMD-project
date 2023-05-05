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
    }

    public void GoToStartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}