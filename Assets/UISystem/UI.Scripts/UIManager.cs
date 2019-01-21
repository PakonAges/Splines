using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class UIManager : IUiManager
{ 
    readonly CanvasBuilder _canvasBuilder;
    CanvasFacade<HUDView> _HUDView;

    public UIManager(   CanvasBuilder canvasBuilder)
    {
        _canvasBuilder = canvasBuilder;
    }

    public async Task InitViewsAsync()
    {
        _HUDView = await _canvasBuilder.BuildAsync<HUDView>();
        _HUDView.CanvasMV.Initialize(/* data */);
        //Sorting Order
    }

    public Task ShowWindowAsync<T>() where T : GenericView
    {
        _canvasBuilder.BuildAsync<T>();
    }

    //public async Task ShowWindowAsync(ViewType type)
    //{
    //    try
    //    {
    //        var Window = await getWindowPrefabAsync(type);
    //        GameObject.Instantiate(Window);
    //        _HUDViewModel._HUDView = (HUDView)Window.GetComponent<GenericView>();
    //    }
    //    catch (Exception e)
    //    {
    //        Debug.LogError(e);
    //    }
    //}
}