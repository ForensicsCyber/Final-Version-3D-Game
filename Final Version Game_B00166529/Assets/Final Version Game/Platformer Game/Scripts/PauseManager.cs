using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseButton;

    private bool isPaused = false;

    void Update()
    {
        // Toggle pause state with the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // Pause the game
    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            pauseMenu.SetActive(true);
            pauseButton.SetActive(false);
            Time.timeScale = 0f; // Freeze game time
            AudioListener.pause = true; // Pause all audio
        }
    }

    // Resume the game
    public void ResumeGame()
    {
        if (isPaused)
        {
            isPaused = false;
            pauseMenu.SetActive(false);
            pauseButton.SetActive(true);
            Time.timeScale = 1f; // Resume game time
            AudioListener.pause = false; // Resume all audio
        }
    }

    // Restart the game
    public void RestartGame()
    {
        Time.timeScale = 1f; // Ensure game time is normal
        AudioListener.pause = false; // Resume all audio
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Quit the game and redirect to the Menu scene
    public void QuitGame()
    {
        Time.timeScale = 1f; // Ensure game time is normal
        AudioListener.pause = false; // Resume all audio
        SceneManager.LoadScene("Menu"); // Load the Menu scene
    }
}
