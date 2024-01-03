using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FlipLever : MonoBehaviour
{
    [SerializeField] public GameObject player;
    private Animator anim;
    public GameObject[] list;

    private bool isActive = false;
    private bool isHovering = false;

    [SerializeField] private AudioSource lever;
    [SerializeField] public TMP_Text taskText;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        lever = GetComponent<AudioSource>();
        taskText.color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHovering && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0))) {
            isActive = !isActive;
            anim.SetBool("Clicked", isActive);
            lever.Play();
            taskText.color = Color.green;
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
