using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;
    public GameObject pauseMenuUI;
    public bool GameIsPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1f;
        fpc.GameIsPaused = false;

        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }

    void Pause ()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        fpc.GameIsPaused = true;
    }
}
