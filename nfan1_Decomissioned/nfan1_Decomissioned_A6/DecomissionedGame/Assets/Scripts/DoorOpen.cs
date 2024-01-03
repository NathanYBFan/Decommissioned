using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorOpen : MonoBehaviour
{
    [SerializeField] public GameObject leftDoor;
    [SerializeField] public GameObject rightDoor;
    private Animator[] anim;
    public ParticleSystem partSys1;
    public ParticleSystem partSys2;

    private AudioSource doorOpen;
    [SerializeField] private bool endGameDoor = false;
    [SerializeField] public TMP_Text doorText;
    [SerializeField] public string textToShow = "Door is locked! Pickup the keycard to unlock";
    private void Start()
    {
        anim = GetComponentsInChildren<Animator>();
        doorOpen = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) // Open doors
    {
        if (other.CompareTag("Player") && other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().passACollected)
        {
            if (!anim[1].GetBool("InTrigger"))
            {
                if (endGameDoor)
                {
                    if (!other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().hasLifeSupport)
                    {
                        foreach (Animator a in anim)
                        {
                            partSys1.Emit(50);
                            a.SetBool("InTrigger", true);
                            doorOpen.pitch = (Random.Range(0.7f, 1f));
                            doorOpen.Play();
                        }
                    }
                    else
                    {
                        StartCoroutine(displayText());
                    }
                }
                else
                {
                    foreach (Animator a in anim)
                    {
                        partSys1.Emit(50);
                        a.SetBool("InTrigger", true);
                        doorOpen.pitch = (Random.Range(0.7f, 1f));
                        doorOpen.Play();
                    }
                }
            }
        }
        else
        {
            StartCoroutine(displayText());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().passACollected)
        {
            if (endGameDoor)
            {
                if (!other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().hasLifeSupport)
                {
                    foreach (Animator a in anim)
                    {
                        partSys1.Emit(50);
                        a.SetBool("InTrigger", true);
                        doorOpen.pitch = (Random.Range(0.7f, 1f));
                        doorOpen.Play();
                    }
                }
            }
            else
            {
                foreach (Animator a in anim)
                {
                    partSys1.Emit(50);
                    a.SetBool("InTrigger", true);
                    doorOpen.pitch = (Random.Range(0.7f, 1f));
                    doorOpen.Play();
                }
            }
        }
    }

    private void OnTriggerExit(Collider other) // Close doors
    {
        if (other.CompareTag("Player") && other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().passACollected)
        {
            if (endGameDoor)
            {
                if (other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().hasLifeSupport)
                {
                    foreach (Animator a in anim)
                    {
                        partSys2.Emit(40);
                        a.SetBool("InTrigger", false);
                    }
                }
            }
            else
            {
                foreach (Animator a in anim)
                {
                    partSys2.Emit(40);
                    a.SetBool("InTrigger", false);
                }
            }
        }
    }

    private IEnumerator displayText()
    {
        doorText.text = textToShow;
        yield return new WaitForSeconds(2.5f);
        doorText.text = "";
    }

}
