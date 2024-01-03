using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextSceneOnclick : MonoBehaviour
{
    public AudioSource sounds;
    public AudioClip hoverSound;
    public AudioClip clickSound;

    public void onMouseHover ()
    {
        sounds.PlayOneShot(hoverSound);
    }

    public void ClickSound ()
    {
        sounds.PlayOneShot(clickSound);
    }

    public void changeScene()
    {
        SceneManager.LoadScene("Decomissioned_MainLevel01", LoadSceneMode.Single);
    }
}
