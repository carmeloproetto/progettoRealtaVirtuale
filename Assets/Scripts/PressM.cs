using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PressM : MonoBehaviour
{
    public GameObject MUI;

    public Transform teleportTarget;
    public GameObject thePlayer;
    public Transform teleportTarget2;
    public GameObject thePlayer2;

    void Start()
    {
        MUI = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            PauseGame();
        }
        
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        MUI.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        MUI.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        FindObjectOfType<AudioManager>().Play("BottoneAscensore");
    }

    public void OnTriggerEnter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        FindObjectOfType<AudioManager>().Play("BottoneAscensore");
        /*thePlayer.transform.position = teleportTarget.transform.position;
        thePlayer2.transform.position = teleportTarget2.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
        MUI.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
        FindObjectOfType<AudioManager>().Play("BottoneAscensore");*/
    }

   
}
