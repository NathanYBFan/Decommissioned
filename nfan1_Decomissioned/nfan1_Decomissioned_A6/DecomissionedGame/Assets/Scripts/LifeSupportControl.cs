using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeSupportControl : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject warning;
    [SerializeField] private AudioSource ambience;
    [SerializeField] private AudioSource shutDownSFX;
    [SerializeField] private GameObject suit;
    [SerializeField] private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;

    private bool isClicked = false;
    // Update is called once per frame
    void Update()
    {
        if (!suit.activeSelf && !fpc.hasLifeSupport)
        {
            SceneManager.LoadScene("Decomissioned_GameOver");
        }

        if (anim.GetBool("Clicked"))
        {
            if (!isClicked)
            {
                fpc.lifeSupportCounter++;
                shutDownSFX.Play();
                isClicked = true;
            }

            if (fpc.lifeSupportCounter == 1 && ambience.isPlaying)
            {
                shutDownSFX.Play();
                ambience.Stop();
            }
            else if (fpc.lifeSupportCounter >= 2)
            {
                if (!warning.GetComponent<Timer>().timerIsSet)
                {
                    warning.SetActive(true);
                    warning.GetComponent<Timer>().timeValue = 10f;
                    StartCoroutine(DisableText(11));
                    shutDownSFX.Play();
                    warning.GetComponent<Timer>().timerIsSet = true;
                }
            }
        }
        else if (!anim.GetBool("Clicked"))
        {
            if (isClicked)
            {
                if (warning.GetComponent<Timer>().timerIsSet)
                {
                    StopAllCoroutines();
                    warning.SetActive(false);
                    warning.GetComponent<Timer>().timerIsSet = false;
                }
                if (fpc.lifeSupportCounter == 2)
                {
                    ambience.Play();
                    ambience.loop = true;
                }
                if (fpc.lifeSupportCounter == 1 && !ambience.isPlaying)
                {
                    shutDownSFX.Play();
                    ambience.Play();
                }
                fpc.lifeSupportCounter--;
                isClicked = false;
                fpc.hasLifeSupport = true;
            }
        }
    }

    private IEnumerator DisableText(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (warning.GetComponent<Timer>().timerIsSet)
        {
            fpc.hasLifeSupport = false;
            if (!suit.activeSelf)
            {
                SceneManager.LoadScene("Decomissioned_GameOver");
            }
        }
        warning.SetActive(false);

        yield return new WaitForSeconds(5f);

    }

}
