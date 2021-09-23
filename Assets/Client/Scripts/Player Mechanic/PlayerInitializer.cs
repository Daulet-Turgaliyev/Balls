
    using Mirror;
    using UnityEngine;

    public class PlayerInitializer: MonoBehaviour
    {
        [SerializeField]
        private PlayerBase playerBase;
        
        [SerializeField] 
        private GameObject cameraObject;

        [SerializeField] 
        private MeshRenderer meshRenderer;
        
        private void Start()
        {
            Debug.Log(playerBase.isLocalPlayer);
            if (playerBase.isLocalPlayer) LocalPlayerInit();
            else NotLocalPlayerInit();
        }

        private void LocalPlayerInit()
        {
            Initialized();
        }
        
        private void NotLocalPlayerInit()
        {
            Destroy(cameraObject);
            meshRenderer.materials[0].color = Color.grey;
            Initialized();
        }

        private void Initialized()
        {
            Destroy(gameObject);
        }
    }
