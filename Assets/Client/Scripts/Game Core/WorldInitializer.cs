using System;
using UnityEngine;

public class WorldInitializer : MonoBehaviour
{
    private void Awake()
    {
        MainInputController.Instance.Initialize();
    }
}
