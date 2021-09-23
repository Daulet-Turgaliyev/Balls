
using UnityEngine;

public class MainInputController
{
	private MainActions _actions;

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

	public Vector2 Movement
	{
		get
		{
			if (_actions != null) return _actions.PlayerController.Movement.ReadValue<Vector2>();

			_actions = new MainActions();
			return _actions.PlayerController.Movement.ReadValue<Vector2>();
		}
	}

	public Vector2 Mouse
	{
		get
		{
			if (_actions != null) return _actions.PlayerController.Mouse.ReadValue<Vector2>();

			_actions = new MainActions();
			return _actions.PlayerController.Mouse.ReadValue<Vector2>();
		}
	}

	public void Initialize()
	{
		_actions = new MainActions();
		_actions.Enable();
	}
}