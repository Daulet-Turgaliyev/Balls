
    using System;
    using Mirror;
    using UnityEngine;

    public class PlayerBase: NetworkBehaviour
    {
        public bool IsLocal { get; private set; }

        private void Awake()
        {
            IsLocal = isLocalPlayer;
        }
    }
