using UnityEngine;
using Zenject;

public class UISystemController : MonoBehaviour
{
    IUiManager _uiManager;

    [Inject]
    public void Construct(IUiManager uiManager)
    {
        _uiManager = uiManager;
    }

    void Start()
    {
        _uiManager.ShowWindow(ViewType.HUD);
    }
}

public enum ViewType
{
    Invalid,
    HUD,
    Menu,
    Submenu
}