using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class BallSync : NetworkBehaviour
{
    public Rigidbody rigidbody;
    public override void OnStartServer()
    {
        base.OnStartServer();
    }
    
    [ServerCallback]
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out PlayerMovement playerMovement))
        {
            rigidbody.AddRelativeForce(Vector3.forward * 50);
        }
    }
}
