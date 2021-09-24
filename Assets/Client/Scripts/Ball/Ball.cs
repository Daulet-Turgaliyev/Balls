using Mirror;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isFree { get; private set; }
    private Rigidbody _rigidbody;
    private Collider _collider;
    
    private void Awake()
    {
        isFree = true;
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void AttachToPlayer(Transform parent)
    {
        if(isFree == false) return;
        isFree = false;
            
        transform.parent = parent;
        transform.localPosition = Vector3.zero;
        transform.rotation = new Quaternion(0,0,0,0);
        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
    }
    
    public void ClearToPlayer()
    {
        if(isFree == true) return;
        isFree = true;

        transform.parent = null;
        _collider.isTrigger = false;
        _rigidbody.isKinematic = false;
        _rigidbody.AddRelativeForce(Vector3.forward * 170);
    }
}
