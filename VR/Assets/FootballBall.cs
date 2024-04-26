using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballBall : InteractionObject
{
    private Rigidbody rb;

    public override void Initialize()
    {
        base.Initialize();
        rb = GetComponent<Rigidbody>();
    }

    public void DeactivateImpulse()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
