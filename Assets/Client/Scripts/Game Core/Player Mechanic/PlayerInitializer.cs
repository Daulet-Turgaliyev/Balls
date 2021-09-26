using Mirror;
    using UnityEngine;

public class PlayerInitializer : MonoBehaviour
{
    [SerializeField] 
    private NetworkIdentity networkIdentity;

    [SerializeField] 
    private GameObject cameraObject;

    [SerializeField] 
    private MeshRenderer meshRenderer;

    [SerializeField] 
    private APlayerCanvas[] playerCanvas;

    [Space] [Header("Canvases")] [SerializeField]
    private GameObject nonLocalPlayerCanvasObject;

    [SerializeField] 
    private GameObject screenCanvas;

    private void Start()
    {
        if (networkIdentity.isLocalPlayer) LocalPlayerInit();
        else NotLocalPlayerInit();
    }

    private void LocalPlayerInit()
    {
        playerCanvas[0].Init();
        Destroy(nonLocalPlayerCanvasObject);
        Initialized();
    }

    private void NotLocalPlayerInit()
    {
        playerCanvas[1].Init();
        Destroy(cameraObject);
        meshRenderer.materials[0].color = Color.grey;
        Destroy(screenCanvas);
        Initialized();
    }

    private void Initialized()
    {
        Destroy(gameObject);
    }
}
