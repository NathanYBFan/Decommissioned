using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneChange : MonoBehaviour
{
    [SerializeField] private string sceneToChangeTo = "Decomissioned_TitleScreen01";
    public void changeScene()
    {
        SceneManager.LoadScene(sceneToChangeTo, LoadSceneMode.Single);
    }
}
