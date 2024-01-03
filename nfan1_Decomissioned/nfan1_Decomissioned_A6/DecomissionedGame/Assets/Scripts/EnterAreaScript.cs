using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnterAreaScript : MonoBehaviour
{
    [SerializeField] public string textToShow;
    [SerializeField] public TMP_Text areaEnterTxt;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(displayText());
        }
    }

    private IEnumerator displayText ()
    {
        areaEnterTxt.text = textToShow;
        yield return new WaitForSeconds(4f);
        areaEnterTxt.text = "";
    }

}
