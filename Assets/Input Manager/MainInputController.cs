
public class MainInputController
{
	private MainActions _actions;
	public MainActions GetActions => _actions;

	private static MainInputController _instance;
	
	public static MainInputController Instance
	{
		get
		{
			if (_instance != null) return _instance;
			_instance = new MainInputController();
			return _instance;
		}
	}
	
	public void Initialize()
	{
		_actions = new MainActions();
		_actions.Enable();
	}
}