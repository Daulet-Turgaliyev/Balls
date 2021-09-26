using System;
using Mirror;
using Mirror.Experimental;
using UnityEngine;

[RequireComponent(typeof(BallDate)), RequireComponent(typeof(Rigidbody)), RequireComponent(typeof(Collider))]

public class BallInteraction : NetworkBehaviour
{
    [SyncVar] 
    private bool _isFree;

    private readonly Vector3 c_fixingBallVector = new Vector3(-0.76f, 1.01f, 0.7f);
    
    private Rigidbody _rigidbody;
    private Collider _collider;
    
    public BallDate ballDate { get; private set;}
    private PlayerDate _ballOwner;

    private bool _isBallInHands;

    [SyncVar] 
    private Transform _targetPosition;

    [SerializeField] 
    private NetworkLerpRigidbody networkLerpRigidbody;
    
    private void Awake()
    {
        _isFree = true;
        networkLerpRigidbody = GetComponent<NetworkLerpRigidbody>();
        ballDate = GetComponent<BallDate>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        /*if(_isBallInHands)
        {
            transform.position = _targetPosition.position;
            networkLerpRigidbody.targetPosition = transform.position; 
        }*/
    }

    public void AttachToPlayer(Transform parent, PlayerDate playerDate)
    {
        if(_isFree == false) return;
        _isFree = false;
        _ballOwner = playerDate;
        _targetPosition = parent;
        _isBallInHands = true;
        transform.rotation = Quaternion.identity;
        SetTriggerAndKinematic(true);
    }
    
    public void ClearToPlayer(Transform parent, float force)
    {
        if(_isFree == true) return;
        transform.parent = null;
        SetTriggerAndKinematic(false);
        _isBallInHands = false;
        _rigidbody.AddRelativeForce(parent.forward * force);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.TryGetComponent(out PlayerDate playerDate))
        {
            if(_rigidbody.velocity.magnitude < 13f) return;
            if(_ballOwner == playerDate) return;
            playerDate.ToDamage(ballDate.GetElectricCharge, this);
        }

        if (other.transform.GetComponent<Ground>() == false) return;
        _ballOwner = null;
        _isFree = true;
    }

    private void SetTriggerAndKinematic(bool isBool)
    {
        _collider.isTrigger = isBool;
        _rigidbody.isKinematic = isBool;
    }
}
