using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour {

	public GameObject player;

	private CharacterController cc;
	[SerializeField] public UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpc;
	public Transform reciever;
	public bool envPlane = false;
	private bool playerIsOverlapping = false;

    private void Awake()
    {
		cc = player.GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void LateUpdate () {
		if (playerIsOverlapping)
		{
			Vector3 portalToPlayer = player.transform.position - transform.position;
			float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

			// If this is true: The player has moved across the portal
			if (dotProduct < 0f)
			{
				Debug.Log("Go through");
				// Teleport him!
				cc.enabled = false;
				float rotationDiff = -Quaternion.Angle(transform.rotation, reciever.rotation);
				rotationDiff += 180;
				player.transform.Rotate(Vector3.up, rotationDiff);

				Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;

				player.transform.position = reciever.position + positionOffset;
				cc.enabled = true;
				playerIsOverlapping = false;
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = true;
			fpc.m_onShip = !envPlane;
		}
	}

	void OnTriggerExit (Collider other)
	{
		if (other.tag == "Player")
		{
			playerIsOverlapping = false;
		}
	}
}
