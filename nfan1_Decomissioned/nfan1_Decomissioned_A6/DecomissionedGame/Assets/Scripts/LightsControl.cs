using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsControl : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject[] lights;
    [SerializeField] private Material[] materials;
    [SerializeField] private GameObject playerLight;
    [SerializeField] private GameObject sunLight;
    [SerializeField] private GameObject fillLight;
    [SerializeField] private GameObject powerDownSFX;

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetBool("Clicked"))
        {
            foreach (GameObject g in lights)
            {
                if (g.activeSelf == false)
                {
                    g.SetActive(true);
                }
            }

            foreach (Material m in materials)
            {
                m.EnableKeyword("_EMISSION");
            }
            playerLight.SetActive(false);
            sunLight.GetComponent<Light>().intensity = 1;
            fillLight.GetComponent<Light>().intensity = 0.44f;
            powerDownSFX.GetComponent<AudioSource>().Play();
            
        }
        else
        {
            foreach (GameObject g in lights)
            {
                g.SetActive(false);
            }
            foreach (Material m in materials)
            {
                m.DisableKeyword("_EMISSION");
            }
            playerLight.SetActive(true);
            sunLight.GetComponent<Light>().intensity = 0.5f;
            fillLight.GetComponent<Light>().intensity = 0.22f;
        }
    }
}
