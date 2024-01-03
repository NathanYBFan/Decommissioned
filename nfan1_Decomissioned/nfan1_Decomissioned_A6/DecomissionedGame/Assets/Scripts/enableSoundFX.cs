using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableSoundFX : MonoBehaviour
{
    [SerializeField] private GameObject powerDownSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (powerDownSFX.GetComponent<AudioSource>().mute == true)
        {
            powerDownSFX.GetComponent<AudioSource>().mute = false;
        }
    }
}
