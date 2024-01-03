using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalControlLever : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject portalScreen;

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("Clicked"))
        {
            portalScreen.SetActive(true);
        } else
        {
            if (portalScreen.activeSelf)
            {
                portalScreen.SetActive(false);
            }
        }
    }
}
