using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
        FindObjectOfType<AudioManager>().Play("Musica");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManager>().Play("BottoneAscensore");
        FindObjectOfType<AudioManager>().StopPlaying("Musica");
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        FindObjectOfType<AudioManager>().Play("BottoneAscensore");
        Application.Quit();
    }
}
