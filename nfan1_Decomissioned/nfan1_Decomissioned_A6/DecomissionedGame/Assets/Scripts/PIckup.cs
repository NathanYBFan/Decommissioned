using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PIckup : MonoBehaviour
{
    public GameObject[] list;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;
    private bool isHovering = false;
    [SerializeField] public TMP_Text taskText;

    private void Start()
    {
        taskText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHovering && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)))
        {
            fpc.passACollected = true;
            foreach (GameObject g in list)
            {
                taskText.color = Color.green;
                g.SetActive(false);
            }
            Destroy(this.gameObject);
        }
    }

    private void OnMouseEnter()
    {
        isHovering = true;
        // Enable GUI
        foreach (GameObject g in list)
        {
            g.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        isHovering = false;
        foreach (GameObject g in list)
        {
            g.SetActive(false);
        }
    }
}
