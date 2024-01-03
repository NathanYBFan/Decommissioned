using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setShip : MonoBehaviour
{
    public bool OnShipCollider;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().m_onShip = OnShipCollider;
        }
    }
}
