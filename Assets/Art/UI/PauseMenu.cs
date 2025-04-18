using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseButton, pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Pause();
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        pauseButton.SetActive(true);
        Time.timeScale = 1;
        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource a in audios)
        {
            a.Play();
        }
    }

    public void Home()
    {
        SceneManager.LoadScene("Menuprinciipal");
        Time.timeScale = 1;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
