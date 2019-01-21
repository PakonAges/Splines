using UnityEngine;
using Zenject;

public class UISystemController : MonoBehaviour
{
    IUiManager _uiManager;

    [Inject]
    public void Construct(IUiManager uiManager)
    {
        _uiManager = uiManager;
        _uiManager.InitViewsAsync();
    }

    void Start()
    {
        //_uiManager.ShowWindowAsync(ViewType.HUDView);
    }
}

public enum ViewType
{
    Invalid,
    HUDView,
    MenuView,
    SubMenuView
}