using Mirror;

public class WorldInitializer : NetworkBehaviour
{
    private void Awake()
    {
        MainInputController.Instance.Initialize();
    }
}
