using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBehaviour : MonoBehaviour
{
    //public GameObject GameUI;
    public GameObject PauseUI;

    void Start() 
    {
        PauseUI = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            PauseGame();
            
        }
    }

    public void PauseGame() {
        Cursor.lockState = CursorLockMode.None;
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
        Cursor.visible = true;
    }

    public void ResumeGame() {
        Cursor.lockState = CursorLockMode.Locked;
        PauseUI.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        FindObjectOfType<AudioManager>().Play("BottoneAscensore");
        Cursor.visible = true;
    }

    public void QuitGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        FindObjectOfType<AudioManager>().Play("BottoneAscensore");
        AudioListener.pause = false;
    }
}
