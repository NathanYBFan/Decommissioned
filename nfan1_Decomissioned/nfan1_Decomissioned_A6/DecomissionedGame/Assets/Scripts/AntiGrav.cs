using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AntiGrav : MonoBehaviour
{
    [SerializeField] private GameObject winZone;
    [SerializeField] private AudioSource BGM;
    [SerializeField] public TMP_Text tasksText;

    private void Start()
    {
        tasksText.color = Color.red;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            tasksText.color = Color.green;
            winZone.SetActive(true);
            other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_GravityMultiplier = 0f;
            other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_onShip = false;
            other.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<Rigidbody>().AddForce(transform.up * 6f);
            other.GetComponent<Rigidbody>().AddForce(transform.forward * 20f);
            StartCoroutine(ChangeVolumeCoroutine());
        }
    }

    private IEnumerator ChangeVolumeCoroutine()
    {
        while (BGM.volume < 0.3f)
        {
            BGM.volume += 0.005f;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
