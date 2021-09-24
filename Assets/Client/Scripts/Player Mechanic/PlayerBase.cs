
    using System;
    using System.Collections;
    using Mirror;
    using UnityEngine;

    public class PlayerBase: MonoBehaviour
    {
        [SerializeField]
        private Transform placeOfAttachment;
        
        private Ball _detectedBall;
        private Ball _ballInHand;
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.TryGetComponent(out Ball ball))
            {
                _detectedBall = ball;
            }
        }

        private void OnCollisionExit(Collision other)
        {
            if (other.transform.TryGetComponent(out Ball ball))
            {
                _detectedBall = null;
            }
        }

        private void TakeBall()
        {
            if (_detectedBall == null) return;
            _ballInHand = _detectedBall;
            _detectedBall.AttachToPlayer(placeOfAttachment);
        }

        private void DropBall()
        {
            if (_ballInHand == null) return;
            _ballInHand.ClearToPlayer();
            _ballInHand = null;
        }

        private void OnEnable()
        {
            MainInputController.Instance.OnTapUse += TakeBall;
            MainInputController.Instance.OnClick += DropBall;
        }
        private void OnDisable()
        {
            MainInputController.Instance.OnTapUse -= TakeBall;
            MainInputController.Instance.OnClick -= DropBall;
        }
    }
