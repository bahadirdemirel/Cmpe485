using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceApplier : MonoBehaviour
{
    public Rigidbody rb;
    public float forceAmount = 10f;

    void FixedUpdate()
    {
        if (rb != null)
        {
            rb.AddForce(Vector3.forward * forceAmount);
        }
    }
}