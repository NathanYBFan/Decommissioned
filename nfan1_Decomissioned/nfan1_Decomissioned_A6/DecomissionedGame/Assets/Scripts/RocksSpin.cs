using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocksSpin : MonoBehaviour
{
    public Vector3 spin;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(spin);
    }
}
