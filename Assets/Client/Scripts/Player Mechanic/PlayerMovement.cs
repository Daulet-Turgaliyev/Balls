using Mirror;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : NetworkBehaviour
{
    private MainActions _actions;
    private Rigidbody _rigidbody;

    [SerializeField] 
    private float speed;

    private Vector2 _direction
    {
        get
        {
            if (MainInputController.Instance != null)
            {
                return MainInputController.Instance.GetActions.PlayerController.Movement.ReadValue<Vector2>();
            }

            return Vector2.zero;
        }
    }
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _actions = MainInputController.Instance.GetActions;
    }

    private void FixedUpdate()
    {
       /* if (isLocalPlayer)*/
       Movement();
    }

    private void Movement()
    {
        _rigidbody.velocity = new Vector3
                             (_direction.x, 0, _direction.y)
                             * speed;
    }
}
