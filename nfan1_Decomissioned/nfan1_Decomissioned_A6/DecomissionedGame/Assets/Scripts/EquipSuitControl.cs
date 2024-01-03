using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipSuitControl : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject suitOverlay;
    [SerializeField] private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;
    [SerializeField] private AudioSource airPressure;

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("Clicked"))
        {
            if (suitOverlay.activeSelf == false)
            {
                suitOverlay.SetActive(true);
                fpc.m_GravityMultiplier = fpc.m_GravityMultiplier / 2;
                fpc.m_JumpSpeed = 6;
                airPressure.Play();
            }
        }
        else
        {
            if (suitOverlay.activeSelf == true)
            {
                suitOverlay.SetActive(false);
                fpc.m_GravityMultiplier = fpc.m_GravityMultiplier * 2;
                fpc.m_JumpSpeed = 10;
            }
        }
    }
}
