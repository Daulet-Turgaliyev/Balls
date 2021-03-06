using UnityEngine;

namespace Mirror.Examples.Pong
{
    public class Player : NetworkBehaviour
    {
        public float speed = 30;
        public Rigidbody2D rigidbody2d;

        // need to use FixedUpdate for rigidbody
        void FixedUpdate()
        {
            // only let the local player control the racket.
            // don't control other player's rackets
            Debug.Log(MainInputController.Instance.Movement.x);
            if (isLocalPlayer)
                rigidbody2d.velocity = new Vector2(0, MainInputController.Instance.Movement.x * speed * Time.fixedDeltaTime);
        }
    }
}
