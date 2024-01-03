using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessTasks : MonoBehaviour
{
    [SerializeField] private GameObject tasks;
    private bool questMenuIsOpen;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (questMenuIsOpen)
            {
                close();
            }
            else
            {
                open();
            }
        }
    }

    private void open()
    {
        questMenuIsOpen = !questMenuIsOpen;
        tasks.SetActive(true);
    }

    private void close()
    {
        questMenuIsOpen = !questMenuIsOpen;
        tasks.SetActive(false);
    }



}
