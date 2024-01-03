using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConUnlocked : MonoBehaviour
{
    [SerializeField] private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;
    [SerializeField] private GameObject winConText;
    [SerializeField] private GameObject winGameZone;

    // Update is called once per frame
    void Update()
    { 
        if (!fpc.hasLifeSupport)
        {
            winConText.SetActive(true);
            winGameZone.SetActive(true);
        }
        else
        {
            winConText.SetActive(false);
            winGameZone.SetActive(false);
        }
    }
}
