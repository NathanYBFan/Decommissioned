using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIntro : MonoBehaviour
{
    [SerializeField] private GameObject gameIntroObj;
    [SerializeField] private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;

    private void Awake()
    {
        gameIntroObj.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
        fpc.GameIsPaused = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameIntroObj.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
            fpc.GameIsPaused = false;
        }
    }
}
