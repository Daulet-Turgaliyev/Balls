using System;
using UnityEngine;


    public class NonLocalPlayerCanvas : APlayerCanvas
    {
        private void FixedUpdate()
        {
            transform.LookAt(Camera.main.gameObject.transform);
        }
    }
